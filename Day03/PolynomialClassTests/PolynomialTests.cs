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
        public Polynomial polynomial1 = new Polynomial(-8.0, 16.0);

        public IEnumerable<TestCaseData> TestData1
        {
            get
            {
                yield return new TestCaseData(polynomial1, 0.0).Returns("( 0 )");
                yield return new TestCaseData(polynomial1, -1.0).Returns("( 8 -16 )");
                yield return new TestCaseData(null, -1.0).Throws( typeof(ArgumentNullException));
            }
        }
        [Test, TestCaseSource(nameof(TestData1))]
        public string Polynomial_MultiplyWithNumber(Polynomial data1, double data2)
        {
            return (data2*data1).ToString();
        }

        public IEnumerable<TestCaseData> TestData2
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new double[] { -8.0, 16.0 }), new Polynomial(new double[] { -2.0 })).Returns("");
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), new Polynomial(new double[] { 1, 1 })).Returns("");
            }
        }
        [Test, TestCaseSource(nameof(TestData2))]
        public string Polynomial_MultiplyWithPolynomial(Polynomial data1, Polynomial data2)
        {
            return (data2*data1).ToString();
        }

        public IEnumerable<TestCaseData> TestData3
        {
            get
            {
                yield return new TestCaseData(polynomial1, 8).Returns("");
                yield return new TestCaseData(new Polynomial(new double[] {-1, 1}), 0).Returns("");
            }
        }
        [Test, TestCaseSource(nameof(TestData3))]
        public string Polynomial_AddWithNumber(Polynomial data1, double data2)
        {
            return (data1+data2).ToString();
        }


        public IEnumerable<TestCaseData> TestData4
        {
            get
            {
                yield return new TestCaseData(polynomial1, new Polynomial(new double[] { -2.0 })).Returns("");
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), new Polynomial(new double[] { 1, 1 })).Returns("");
            }
        }
        [Test, TestCaseSource(nameof(TestData4))]
        public string Polynomial_AddWithPolynomial(Polynomial data1, Polynomial data2)
        {
            return (data2 + data1).ToString();
        }

        public IEnumerable<TestCaseData> TestData5
        {
            get
            {
                yield return new TestCaseData(polynomial1, -8).Returns(" ");
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), 0).Returns(" ");
            }
        }
        [Test, TestCaseSource(nameof(TestData5))]
        public string Polynomial_SubstructWithNumber(Polynomial data1, double data2)
        {
            return ((-1) * (data2 - data1)).ToString();
        }


        public IEnumerable<TestCaseData> TestData6
        {
            get
            {
                yield return new TestCaseData(polynomial1, new Polynomial(new double[] { -8.0 })).Returns("");
                yield return new TestCaseData(new Polynomial(new double[] { -1, 1 }), new Polynomial(new double[] { 1, 1 })).Returns("");
            }
        }
        [Test, TestCaseSource(nameof(TestData6))]
        public string Polynomial_SubstructWithPolynomial(Polynomial data1, Polynomial data2)
        {
            return ((-1)*(data2 - data1)).ToString();
        }
    }
}
