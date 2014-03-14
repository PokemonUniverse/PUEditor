using System;
using System.Net.Sockets;

namespace PokeEditorV3.Net
{
    public class Packet
    {
        public int MsgSize { get; private set; }
        public int ReadPos { get; private set; }

        private readonly byte[] buffer;

        const int PACKET_MAXSIZE = 16384;

        public Packet()
        {
            buffer = new byte[PACKET_MAXSIZE];
            Reset();
        }

        public void Reset()
        {
            MsgSize = 0;
            ReadPos = 2;
        }

        public void Send(Socket socket)
        {
            buffer[0] = (byte)(MsgSize);
            buffer[1] = (byte)(MsgSize >> 8);

            var toSend = new byte[MsgSize + 2];
            Buffer.BlockCopy(buffer, 0, toSend, 0, MsgSize + 2);

            socket.Send(toSend);
        }

        public bool ReceiveFromServer(Socket socket)
        {
            bool toReturn = false;
            Reset();

            socket.Receive(buffer, 0, 2, SocketFlags.None);
            var datasize = (buffer[0] | (buffer[1] << 8));
            if (datasize > 0)
            {
                MsgSize = datasize;
                int readBytes = 0;

                while (true)
                {
                    int nextByte = socket.Receive(buffer, readBytes + 2, datasize - readBytes, SocketFlags.None);
                    if (nextByte == -1 || nextByte == 0)
                        break;

                    readBytes += nextByte;
                    if (readBytes == datasize)
                        break;
                }

                if (readBytes == datasize)
                {
                    toReturn = true;
                }
            }

            return toReturn;
        }

        public bool CanAdd(int size)
        {
            if (size + ReadPos < PACKET_MAXSIZE - 16)
            {
                return true;
            }

            return false;
        }

        public void AddByte(byte value)
        {
            if (!CanAdd(1))
            {
                return;
            }

            buffer[ReadPos++] = value;
            MsgSize++;
        }

        public void AddByte(int value)
        {
            if (!CanAdd(1))
            {
                return;
            }

            buffer[ReadPos++] = (byte)value;
            MsgSize++;
        }

        public void AddInt(int value)
        {
            if (!CanAdd(2))
            {
                return;
            }

            buffer[ReadPos++] = (byte)(value);
            buffer[ReadPos++] = (byte)(value >> 8);
            MsgSize += 2;
        }

        public void AddLong(long value)
        {
            if (!CanAdd(4))
            {
                return;
            }

            buffer[ReadPos++] = (byte)(value);
            buffer[ReadPos++] = (byte)(value >> 8);
            buffer[ReadPos++] = (byte)(value >> 16);
            buffer[ReadPos++] = (byte)(value >> 24);
            MsgSize += 4;
        }

        public void AddString(String value)
        {
            AddInt(value.Length);
            char[] array = value.ToCharArray();
            foreach (char ch in array)
            {
                buffer[ReadPos++] = (byte)ch;
            }
            MsgSize += value.Length;
        }

        //TEST TODO
        public void AddByteArray(byte[] value)
        {
            //TEST TODO
            AddInt(value.Length);
            foreach (var b in value)
            {
                buffer[ReadPos++] = b;
                MsgSize++;
            }
        }

        public byte ReadByte()
        {
            return buffer[ReadPos++];
        }

        public short ReadInt()
        {
            var v = (short)(buffer[ReadPos] | (buffer[ReadPos + 1] << 8));

            ReadPos += 2;
            return v;
        }

        public long ReadLong()
        {
            long v = ((buffer[ReadPos]) |
                    (buffer[ReadPos + 1] << 8) |
                    (buffer[ReadPos + 2] << 16) |
                    (buffer[ReadPos + 3] << 24));

            ReadPos += 4;
            return v;
        }

        public String ReadString()
        {
            String value = "";
            int stringlength = ReadInt();
            for (int i = 0; i < stringlength; i++)
            {
                value = value + (char)buffer[ReadPos++];
            }
            return value;
        }
    }
}
