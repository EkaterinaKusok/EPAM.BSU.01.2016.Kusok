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

        public IEnumerable<TestCaseData> TestData
        {

            get
            {
                yield return new TestCaseData(new Polynomial(new double[]{8.0, 16.0}), new Polynomial(new double[] { 0, 1.0 })).Returns(new Polynomial(new double[]{0.0,8.0,16.0}));
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public Polynomial Polynomial_Multiply(Polynomial data1, Polynomial data2)
        {
            return data1.Multiply(data2);
        }
    }
}
