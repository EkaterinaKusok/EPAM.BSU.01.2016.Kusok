using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static FormattedOutput.IntExtension;

namespace FormattedOutputTests
{
    [TestFixture]
    public class IntExtensionTests
    {
        public IEnumerable<TestCaseData> TestData
        {

            get
            {
                yield return new TestCaseData(2147483647).Returns("7FFFFFFF");
                yield return new TestCaseData(0).Returns("0");
                yield return new TestCaseData(129300).Returns("1F914");
                yield return new TestCaseData(-2147483646).Returns("80000002");
                yield return new TestCaseData(-2147483648).Returns("80000000");
                yield return new TestCaseData(-2134896640).Returns("80C01000");
                yield return new TestCaseData(-300).Returns("FFFFFED4");
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public string ConvertToHex_InputInt_WithYield(int decValue)
        {
            return decValue.ConvertToHex();
        }
    }
}
