using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomerToString;
//using static CustomerToString.Customer;

namespace CustomerToStringTests
{
    [TestFixture]
    public class CustomerTests
    {
        public IEnumerable<TestCaseData> TestData
        {

            get
            {
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m,"N",null).Returns("CustomerRecord: Jeffrey Rihter");
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m, "P",null).Returns("CustomerRecord: +1(425)555-0100");
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m, "NPR",null).Returns("CustomerRecord: Jeffrey Rihter, +1(425)555-0100, 1000000");
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m, "A",null).Throws(typeof(FormatException));
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m, "R",null).Returns("CustomerRecord: 1 000 000");
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m, "R", CultureInfo.CreateSpecificCulture("el-GR")).Returns("CustomerRecord: 1.000.000");
                yield return new TestCaseData("Jeffrey Rihter", "+1(425)555-0100", 1000000m, "R,", null).Returns("CustomerRecord: 1,000,000");
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public string CustomerToString_InputCustomerWithParamerets_WithYield(string name, string phone, decimal revenue, string parameter, IFormatProvider provider)
        {
            Customer temp = new Customer(name, phone, revenue);
            return temp.ToString(parameter, provider);
        }

        [Test, TestCaseSource(nameof(TestData))]
        public string Customer_FormattedOutput_WithYield(string name, string phone, decimal revenue, string parameter, IFormatProvider provider)
        {
            Customer temp = new Customer(name,phone, revenue);
            return String.Format(provider,"{0:"+parameter+"}", temp);
        }
    }
}
