using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Types
{
    public struct Cpf
    {
        private readonly string _value;
        public bool IsValid { get; internal set; }

        private Cpf(string value)
        {
            _value = value;
            IsValid = false; // Always initialize as false
        }

        public override string ToString() => _value;
        public override bool Equals(object obj) => _value.Equals(obj);
        public override int GetHashCode() => _value.GetHashCode();

        public static bool operator ==(Cpf cpf, string value) => cpf._value == value;
        public static bool operator !=(Cpf cpf, string value) => !(cpf._value == value);
        public static bool operator ==(Cpf cpf, Cpf cpf2) => cpf._value == cpf2._value;
        public static bool operator !=(Cpf cpf, Cpf cpf2) => !(cpf._value == cpf2._value);


        public static implicit operator Cpf(string value) => Parse(value);
        public static Cpf Parse(string value) => TryParse(value, out var result) ? result : "";

        public static bool TryParse(string value, out Cpf result)
        {
            result = new Cpf(value);
            return isValid(value) ? result.IsValid = true : result.IsValid = false;
        }

        private static bool isValid(string value)
        {
            return string.IsNullOrEmpty(value) ? false : true;
        }
    }
}
