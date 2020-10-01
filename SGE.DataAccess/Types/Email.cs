using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SGE.DataAccess.Types
{
    public struct Email
    {
        private readonly string _value;
        public bool IsValid { get; internal set; }
        public int Length { get => _value.Length; }

        private Email(string value)
        {
            _value = value;
            IsValid = false; // Always initialize as false
        }

        public override string ToString() => _value;
        public override bool Equals(object obj) => _value.Equals(obj);
        public override int GetHashCode() => _value.GetHashCode();

        public static bool operator ==(Email Email, string value) => Email._value == value;
        public static bool operator !=(Email Email, string value) => !(Email._value == value);
        public static bool operator ==(Email Email, Email Email2) => Email._value == Email2._value;
        public static bool operator !=(Email Email, Email Email2) => !(Email._value == Email2._value);


        public static implicit operator Email(string value) => Parse(value);
        public static Email Parse(string value) => TryParse(value, out var result) ? result : "";

        public static bool TryParse(string value, out Email result)
        {
            result = new Email(value);
            return isValid(value) ? result.IsValid = true : result.IsValid = false;
        }

        private static bool isValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return true;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}