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
                yield return new TestCaseData(new int[] { 8, 16}).Returns(8);
                yield return new TestCaseData(new int[] {8,0}).Returns(8);
                yield return new TestCaseData(new int[] { 0, 0}).Returns(0);
                yield return new TestCaseData(new int[] { 1, 3}).Returns(1);
                yield return new TestCaseData(new int[] { 0, -1}).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new int[0]).Throws(typeof(ArgumentException));
                yield return new TestCaseData( 10 ).Throws(typeof(ArgumentException));
                yield return new TestCaseData(new int[] { 2, 4, 6}).Returns(2);
                yield return new TestCaseData(new int[] { 100, 3, 6}).Returns(1);
                yield return new TestCaseData(new int[] { 13, 26, 0}).Returns(13);
                yield return new TestCaseData(new int[] { 0, 20, -1}).Throws(typeof(ArgumentOutOfRangeException));
            }
        }
        
        [Test, TestCaseSource(nameof(TestData))]
        public double EuclideanAlgorithm_FindGcd2Numbers_WithYield(params int[] data)
        {
            return EuclideanAlgorithm(out _workingTime, data);
        }

        [Test, TestCaseSource(nameof(TestData))]
        public double SteinAlgorithm_FindGcd2Numbers_WithYield(params int [] data)
        {
            return SteinAlgorithm(out _workingTime, data);
        }
    }
}
