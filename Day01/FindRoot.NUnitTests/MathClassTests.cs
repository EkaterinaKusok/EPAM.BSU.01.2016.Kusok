using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static FindRoot.MathClass;

namespace FindRoot.NUnitTests
{
    [TestFixture]
    public class MathClassTests
    {
        public IEnumerable<TestCaseData> TestData
        {

            get
            {
                //yield return new TestCaseData(8, 3, 0.00001).Returns(2);
                yield return new TestCaseData(8, -3, 0.0001).Throws(typeof (FormatException));
                yield return new TestCaseData(-8, 2, 0.0001).Throws(typeof (FormatException));
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public double FindNthRoot_FromNumber_WithYield(double number, int root, double epsilon)
        {
            //Debug.WriteLine("Hello!");
            return FindNthRoot(number, root, epsilon);
        }

        [Test]
        public void FindNthRoot_FromNumberWithEpsilonWitinExeption()
        {
            double number = 8;
            int root = 3;
            double epsilon = 0.00001;
            double returnedResult = 2;
            double actResult = FindNthRoot(number, root, epsilon);
            Assert.That(actResult, Is.InRange(returnedResult-epsilon, returnedResult+epsilon));
        }
        
    }

}
