using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Types
{
    public struct Cnpj
    {
        private readonly string _value;
        public bool IsValid { get; internal set; }

        private Cnpj(string value)
        {
            _value = value;
            IsValid = false; // Always initialize as false
        }

        public override string ToString() => _value;
        public override bool Equals(object obj) => _value.Equals(obj);
        public override int GetHashCode() => _value.GetHashCode();

        public static bool operator ==(Cnpj Cnpj, string value) => Cnpj._value == value;
        public static bool operator !=(Cnpj Cnpj, string value) => !(Cnpj._value == value);
        public static bool operator ==(Cnpj Cnpj, Cnpj Cnpj2) => Cnpj._value == Cnpj2._value;
        public static bool operator !=(Cnpj Cnpj, Cnpj Cnpj2) => !(Cnpj._value == Cnpj2._value);


        public static implicit operator Cnpj(string value) => Parse(value);
        public static Cnpj Parse(string value) => TryParse(value, out var result) ? result : "";

        public static bool TryParse(string value, out Cnpj result)
        {
            result = new Cnpj(value);
            return isValid(value) ? result.IsValid = true : result.IsValid = false;
        }

        private static bool isValid(string value)
        {
            return string.IsNullOrEmpty(value) ? false : true;
        }
    }
}
