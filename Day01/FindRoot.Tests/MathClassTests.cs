using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FindRoot.MathClass;

namespace FindRoot.Tests
{
    [TestClass]
    public class MathClassTests
    {
        [TestMethod]
        public void FindNthRoot_Number8root3_Returned2()
        {
            //Arrange Act Assert (AAA)
            //Arrange
            double number = (double)8;
            int root = 3;
            double epsilon = 0.00001;
            double returnedResult = 2;
            // Debug.WriteLine("Bla-bla-bla");
            //Act
            double actResult = FindNthRoot(number, root, epsilon);
            //Assert
            Assert.AreEqual(returnedResult, actResult, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FindNthRoot_NegativeRoot_ReturnedException()
        {
            double number = 8;
            int root = -3;
            double epsilon = 0.00001;

            double actResult = FindNthRoot(number, root, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FindNthRoot_NegativeNumberAndEvenRoot_ReturnedException()
        {
            double number = -8;
            int root = 2;
            double epsilon = 0.00001;

            double actResult = FindNthRoot(number, root, epsilon);
        }
    }
}
