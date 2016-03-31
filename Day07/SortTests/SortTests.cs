using System;
using System.Collections.Generic;
using NUnit.Framework;
using static Sort.Sort;

namespace SortTests
{
    [TestFixture]
    public class SortTests
    {
        private int[] arrayInt = {5, 4, 3, 2, 1, 6};
        private int[] sortArrayInt = { 1,2,3,4,5,6 };
        private int[] sortDescArrayInt = { 6,5, 4, 3, 2, 1 };

        public IEnumerable<TestCaseData> TestDataInt
        {
            get
            {
                yield return new TestCaseData(arrayInt, Comparer<int>.Create((x, y) => -x.CompareTo(y))).Returns(sortDescArrayInt);
                yield return new TestCaseData(arrayInt, Comparer<int>.Default).Returns(sortArrayInt);
            }
        }

        [Test, TestCaseSource(nameof(TestDataInt))]
        public int[] BubbleSort_ForInt_WithYield(int[] array, Comparer<int> comparer)
        {
            BubbleSort(ref array,comparer);
            return array;
        }


        private string[] arrayString = { "xyz","a","bc","x","left","right"};
        private string[] sortArrayString = { "a", "bc","left", "right", "x","xyz" };
        private string[] sortDescArrayString = {"xyz","x","right","left","bc","a"};

        public IEnumerable<TestCaseData> TestDataString
        {
            get
            {
                yield return new TestCaseData(arrayString, Comparer<string>.Create((x, y) => -x.CompareTo(y))).Returns(sortDescArrayString);
                yield return new TestCaseData(arrayString, Comparer<string>.Default).Returns(sortArrayString);
            }
        }

        [Test, TestCaseSource(nameof(TestDataString))]
        public string[] BubbleSort_ForString_WithYield(string[] array, Comparer<string> comparer)
        {
            BubbleSort(ref array, comparer);
            return array;
        }
    }
}
