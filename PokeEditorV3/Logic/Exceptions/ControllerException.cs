using System;
using NoNameLib;

namespace PokeEditorV3.Logic.Exceptions
{
    public class ControllerException : NoNameLibException
    {
        public ControllerException(Enum errorEnumValue) : base(errorEnumValue)
        {
        }

        public ControllerException(Enum errorEnumValue, Exception ex) : base(errorEnumValue, ex)
        {
        }

        public ControllerException(Enum errorEnumValue, string message, params object[] args) : base(errorEnumValue, message, args)
        {
        }

        public ControllerException(Enum errorEnumValue, Exception ex, string message, params object[] args) : base(errorEnumValue, ex, message, args)
        {
        }
    }
}
