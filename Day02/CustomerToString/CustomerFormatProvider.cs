using System;
using System.Globalization;

namespace CustomerToString
{
    public class CustomerFormatProvider: IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string resultString;
            if (!(arg is Customer))
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

            switch (format.ToUpper())
            {
                case "NPR":
                    resultString = "Customer: " + String.Format("{0:n}", arg) + ". Contact phone: " 
                        + String.Format("{0:p}", arg) + ". Revenue: " + String.Format("{0:r}", arg);
                    break;
                case "NRP":
                    resultString = "Customer: " + String.Format("{0:n}", arg) + ". Revenue: " + 
                        String.Format("{0:r}", arg) + ". Contact phone: " + String.Format("{0:p}", arg);
                    break;
                case "N":
                    resultString = "Customer: " + String.Format("{0:n}", arg) + ".";
                    break;
                case "P":
                    resultString = "Contact phone: " + String.Format("{0:p}", arg) + ".";
                    break;
                case "R":
                    resultString = "Revenue: " + String.Format("{0:r}", arg) + ".";
                    break;
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
            return resultString;
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
    }
}
