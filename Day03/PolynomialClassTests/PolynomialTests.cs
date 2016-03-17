using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PolynomialClass;
using static PolynomialClass.Polynomial;

namespace PolynomialClassTests
{
    [TestFixture]
    public class PolynomialTests
    {

        public IEnumerable<TestCaseData> TestData1
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[]{-8.0, 16.0}), 0.0).Returns(new double[] {0});
                yield return new TestCaseData(new Polynomial(new double[] { -8.0, 16.0 }), -1.0).Returns(new double[] { 8.0, -16.0 });
            }
        }
        [Test, TestCaseSource(nameof(TestData1))]
        public double[] Polynomial_MultiplyWithNumber(Polynomial data1, double data2)
        {
            //return (data1*data2).Get();
            return (data2*data1).Get();
        }

        public IEnumerable<TestCaseData> TestData2
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { -8.0, 16.0 }), new Polynomial(new double[] { -2.0 })).Returns(new double[] { 16, -32});
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), new Polynomial(new double[] { 1, 1 })).Returns(new double[] { -1,0,1 });
            }
        }
        [Test, TestCaseSource(nameof(TestData2))]
        public double[] Polynomial_MultiplyWithPolynomial(Polynomial data1, Polynomial data2)
        {
            //return (data1 * data2).Get();
            return (data2*data1).Get();
        }

        public IEnumerable<TestCaseData> TestData3
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] {-8, 16}), 8).Returns(new double[] {0, 16});
                yield return new TestCaseData(new Polynomial(new double[] {-1, 1}), 0).Returns(new double[] {-1, 1});
            }
        }
        [Test, TestCaseSource(nameof(TestData3))]
        public double[] Polynomial_AddWithNumber(Polynomial data1, double data2)
        {
            return (data1+data2).Get();
        }


        public IEnumerable<TestCaseData> TestData4
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { -8.0, 16.0 }), new Polynomial(new double[] { -2.0 })).Returns(new double[] { -10,16 });
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), new Polynomial(new double[] { 1, 1 })).Returns(new double[] {0,2});
            }
        }
        [Test, TestCaseSource(nameof(TestData4))]
        public double[] Polynomial_AddWithPolynomial(Polynomial data1, Polynomial data2)
        {
            //return (data1 + data2).Get();
            return (data2 + data1).Get();
        }

        public IEnumerable<TestCaseData> TestData5
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { -8, 16 }), -8).Returns(new double[] { 0, 16 });
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), 0).Returns(new double[] { -1, 1 });
            }
        }
        [Test, TestCaseSource(nameof(TestData5))]
        public double[] Polynomial_SubstructWithNumber(Polynomial data1, double data2)
        {
            //return (data1 - data2).Get();
            return ((-1) * (data2 - data1)).Get();
        }


        public IEnumerable<TestCaseData> TestData6
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { -8.0, 16.0 }), new Polynomial(new double[] { -8.0 })).Returns(new double[] { 0, 16 });
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), new Polynomial(new double[] { 1, 1 })).Returns(new double[] {-2, 0 });
            }
        }
        [Test, TestCaseSource(nameof(TestData6))]
        public double[] Polynomial_SubstructWithPolynomial(Polynomial data1, Polynomial data2)
        {
            //return (data1 - data2).Get();
            return ((-1)*(data2 - data1)).Get();
        }
    }
}
