using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomerToString
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string name, string phone, decimal revenue)
        {
            this.Name = name;
            this.ContactPhone = phone;
            this.Revenue = revenue;
        }

        public override string ToString()
        {
            return this.ToString("N", null);
        }

        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            // Handle null or empty arguments.
            if (String.IsNullOrEmpty(format)) format = "NPR";
            // Remove any white space and convert to uppercase.
            format = format.Trim().ToUpperInvariant();

            if (provider == null) provider = NumberFormatInfo.CurrentInfo;

            switch (format)
            {
                case "NPR":
                    return "CustomerRecord: " + this.Name + ", " + this.ContactPhone + ", " +
                           this.Revenue.ToString(provider);
                case "N":
                    return "CustomerRecord: " + this.Name;
                case "P":
                    return "CustomerRecord: " + this.ContactPhone;
                case "R":
                    return "CustomerRecord: " + this.Revenue.ToString("0,0", provider);
                case "R,":
                    return "CustomerRecord: " + this.Revenue.ToString("0,0", CultureInfo.InvariantCulture);
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
    }
}
