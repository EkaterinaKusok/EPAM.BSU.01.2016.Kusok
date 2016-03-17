using System;
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
            if (String.IsNullOrEmpty(format)) format = "N";
            // Remove any white space and convert to uppercase.
            format = format.Trim().ToUpperInvariant();

            if (provider == null) provider = CultureInfo.InvariantCulture;

            switch (format)
            {
                case "NPR":
                    return String.Format(provider, "{0}", this.Name) + ", " + String.Format(provider, "{0}", this.ContactPhone) + ", " + String.Format(provider, "{0:C}", this.Revenue);
                case "NRP":
                    return String.Format(provider, "{0}", this.Name) + ", " + String.Format(provider,"{0:C}",this.Revenue) + ", " + String.Format(provider, "{0}", this.ContactPhone);
                case "N":
                    return String.Format(provider, "{0}", this.Name);
                case "P":
                    return String.Format(provider, "{0}", this.ContactPhone);
                case "R":
                    return String.Format(provider, "{0:C}", this.Revenue);
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
    }
}
