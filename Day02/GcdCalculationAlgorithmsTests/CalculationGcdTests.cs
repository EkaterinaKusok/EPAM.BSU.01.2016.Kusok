using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;
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
                yield return new TestCaseData(new int[] {8, 16}).Returns(8);
                yield return new TestCaseData(new int[] {8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096}).Returns(8);
                yield return new TestCaseData(new int[] {8, 16, 32}).Returns(8);
                yield return new TestCaseData(new int[] {1, 3}).Returns(1);
                yield return new TestCaseData(new int[] {0, -1}).Throws(typeof (ArgumentOutOfRangeException));
                yield return new TestCaseData(null).Throws(typeof (ArgumentNullException));
                yield return new TestCaseData(new int[0]).Throws(typeof (ArgumentException));
                yield return new TestCaseData(10).Throws(typeof (ArgumentException));
                yield return new TestCaseData(new int[] {2, 4, 6}).Returns(2);
                yield return new TestCaseData(new int[] {100, 3, 6}).Returns(1);
                yield return new TestCaseData(new int[] {13, 26, 0}).Returns(13);
                yield return new TestCaseData(new int[] {0, 20, -1}).Throws(typeof (ArgumentOutOfRangeException));
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public int GcdByEuclidean_FindForArrayNumbers_WithYield(params int[] data)
        {
            int result = GcdByEuclidean(out _workingTime, data);
            Debug.WriteLine(_workingTime.TotalMilliseconds);
            return result;
        }

        [Test, TestCaseSource(nameof(TestData))]
        public int GcdByStein_FindForArrayNumbers_WithYield(params int[] data)
        {
            int result = GcdByStein(out _workingTime, data);
            //Debug.WriteLine(_workingTime.TotalMilliseconds);
            return result;
        }

        public IEnumerable<TestCaseData> TestData1
        {
            get
            {
                yield return new TestCaseData(8, 16).Returns(8);
                yield return new TestCaseData(16, 24).Returns(8);
                yield return new TestCaseData(86899875, 1777489365).Returns(15);
                yield return new TestCaseData(1048576, 1073741823).Returns(1);
                yield return new TestCaseData(0, -1).Throws(typeof (ArgumentOutOfRangeException));
            }
        }

        [Test, TestCaseSource(nameof(TestData1))]
        public int GcdByEuclidean_FindGcdFor2Numbers_WithYield(int num1, int num2)
        {
            int result = GcdByEuclidean(out _workingTime, num1, num2);
            //Debug.WriteLine(_workingTime.Ticks);
            return result;
        }

        [Test, TestCaseSource(nameof(TestData1))]
        public int GcdByStein_FindGcdFor2Numbers_WithYield(int num1, int num2)
        {
            int result = GcdByStein(out _workingTime, num1, num2);
            //Debug.WriteLine(_workingTime.Ticks);
            return result;
        }
    }
}