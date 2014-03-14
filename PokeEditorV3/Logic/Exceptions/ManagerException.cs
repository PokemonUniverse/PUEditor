using System;
using NoNameLib;

namespace PokeEditorV3.Logic.Exceptions
{
    public class ManagerException : NoNameLibException
    {
        public ManagerException(Enum errorEnumValue) : base(errorEnumValue)
        {
        }

        public ManagerException(Enum errorEnumValue, Exception ex) : base(errorEnumValue, ex)
        {
        }

        public ManagerException(Enum errorEnumValue, string message, params object[] args) : base(errorEnumValue, message, args)
        {
        }

        public ManagerException(Enum errorEnumValue, Exception ex, string message, params object[] args) : base(errorEnumValue, ex, message, args)
        {
        }
    }
}
