using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static BinarySearch.BinarySearch;

namespace BinarySearchTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        public int[] arraySample = new int[] { 1,2,3,4,5};
        public IEnumerable<TestCaseData> TestData
        {
            get
            {
               // yield return new TestCaseData(new int[] { 1,2,3,8, 16 },1).Returns(0);
                yield return new TestCaseData(arraySample, 16, null).Returns(4);
                yield return new TestCaseData(arraySample, 3, Comparer<int>.Default).Returns(2);
                yield return new TestCaseData(arraySample, -1,null).Returns(-1);
                yield return new TestCaseData(arraySample, 32,null).Returns(-4);
                //yield return new TestCaseData(new string[] { "a","b", "c","d" },"a", Comparer<string>.Default).Returns(0);
                //yield return new TestCaseData(new string[] { "a", "b", "c", "d" }, "e",null).Returns(-4);
                //yield return new TestCaseData(null,5,null).Returns(-1);
               // yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
              }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public int BinarySearch_FindElement_WithYield<T>(T[] array, T searchElement, Comparer<T>  comparer)
        {
            int result = Find(array, searchElement, comparer);
            return result;
        }


        [Test]
        public void BinarySearch()
        {
            int[] array1 ={ 1, 3, 5, 7, 9 };
            int result = Find(array1,5,null);
            Assert.That(result,Is.EqualTo(3));
        }
    }
}
