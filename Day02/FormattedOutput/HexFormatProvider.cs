using System;
using System.Globalization;

namespace FormattedOutput
{
    public class HexFormatProvider: IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            // Determine whether custom formatting object is requested.
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string resultHexString;
            // Handle null or empty format string, string with precision specifier.
            string thisFmt = String.Empty;
            // Extract first character of format string (precision specifiers are not supported).
            if (!String.IsNullOrEmpty(format))
                thisFmt = format.Length > 1 ? format.Substring(0, 1) : format;

            if (!(arg is  int))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new ArgumentException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            switch (thisFmt.ToUpper())
            {
                // Hex formatting.
                case "H":
                    resultHexString = ConvertToHex((int)arg);
                    break;
                // Handle unsupported format strings.
                default:
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                    }
            }
            return resultHexString;
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

        private static string ConvertToHex( int decValue)
        {
            string hexValue = "0x";
            if (decValue== -2147483648)
                return "-0x80000000";
            if (decValue > -1)
                hexValue += GetHexDigitsString(decValue);
            else 
            {
                hexValue = "-" + hexValue;
                hexValue += GetHexDigitsString((-1) * decValue);
            }
            return hexValue;
        }

        private static string GetHexDigitsString(int decValue)
        {
            string[] digits = new string[16]
            {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
            string result="";
            do
            {
                result = digits[decValue%16]+result;
                decValue /= 16;
            } while (decValue != 0);
            return result;
        }
    }
}