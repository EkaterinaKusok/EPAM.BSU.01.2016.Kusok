using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using CustomerToString;

namespace CustomerToStringTests
{
    [TestFixture]
    public class CustomerTests
    {
        public IEnumerable<TestCaseData> TestData
        {

            get
            {
                yield return new TestCaseData("N", null).Returns("Jeffrey Rihter");
                yield return new TestCaseData("P", null).Returns("+1(425)555-0100");
                yield return new TestCaseData("NPR", null).Returns("Jeffrey Rihter, +1(425)555-0100, ¤1,000,000.00");
                yield return new TestCaseData("nrp", new CultureInfo("de-DE")).Returns("Jeffrey Rihter, 1.000.000,00 €, +1(425)555-0100");
                yield return new TestCaseData("A", null).Throws(typeof (FormatException));
                yield return new TestCaseData("R", null).Returns("¤1,000,000.00");
                yield return new TestCaseData("R", new CultureInfo("en-US")).Returns("$1,000,000.00");
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public string CustomerToString_WithYield(string parameter, IFormatProvider provider)
        {
            Customer temp = new Customer("Jeffrey Rihter", "+1(425)555-0100", 1000000m);
            return temp.ToString(parameter, provider);
        }

        [Test, TestCaseSource(nameof(TestData))]
        public string Customer_FormattedOutput_WithYield(string parameter, IFormatProvider provider)
        {
            Customer temp = new Customer("Jeffrey Rihter", "+1(425)555-0100", 1000000m);
            return String.Format(provider, "{0:" + parameter + "}", temp);
        }

        [TestCase(Result = "Customer: Jeffrey Rihter. Contact phone: +1(425)555-0100. Revenue: ¤1,000,000.00")]
        public string CustomerProvider_Test()
        {
            Customer temp = new Customer("Jeffrey Rihter", "+1(425)555-0100", 1000000m);
            return String.Format(new CustomerFormatProvider(), "{0:npr}", temp);
        }


        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]
        [TestCase("Mirror", "{0}", Result = "Mirror")]
        public string ParentFormat_Test(object number, string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider cust = new CustomerFormatProvider();
            return string.Format(cust, format, number);
        }
    }
}
