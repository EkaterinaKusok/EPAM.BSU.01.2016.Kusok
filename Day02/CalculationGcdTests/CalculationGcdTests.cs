using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static GcdCalculationAlgorithms.CalculationGcd;

namespace GcdCalculationAlgorithmsTests
{
    [TestFixture]
    public class CalculationGcdTests
    {
        private TimeSpan _workingTime;
        public IEnumerable<TestCaseData> TestData
        {

            get
            {
                yield return new TestCaseData(8, 16).Returns(8);
                yield return new TestCaseData(8, 0).Returns(8);
                yield return new TestCaseData(0, 0).Returns(0);
                yield return new TestCaseData(1, 3).Returns(1);
                yield return new TestCaseData(0, -1).Throws(typeof(FormatException));
            }
        }
        
        [Test, TestCaseSource(nameof(TestData))]
        public double EuclideanAlgorithm_FindGcd2Numbers_WithYield(int first, int second)
        {
            return EuclideanAlgorithm(first, second, out _workingTime);
        }

        [Test, TestCaseSource(nameof(TestData))]
        public double SteinAlgorithm_FindGcd2Numbers_WithYield(int first, int second)
        {
            return SteinAlgorithm(first, second, out _workingTime);
        }
    }
}
