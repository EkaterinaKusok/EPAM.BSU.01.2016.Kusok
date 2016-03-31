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
        private int[] arrayInt = {1,2,3,5,6,7};
        public IEnumerable<TestCaseData> TestDataInt
        {
            get
            {
                yield return new TestCaseData(arrayInt, 1, null).Returns(0);
               // yield return new TestCaseData(arrayInt, 16, null).Returns(-1);
                yield return new TestCaseData(arrayInt, 3, Comparer<int>.Default).Returns(2);
                yield return new TestCaseData(arrayInt, -1,Comparer<int>.Default).Returns(-1);
                yield return new TestCaseData(arrayInt, 32, Comparer<int>.Default).Returns(-7);
                yield return new TestCaseData(arrayInt, 4, Comparer<int>.Default).Returns(-4);
            }
        }

        [Test, TestCaseSource(nameof(TestDataInt))]
        public int BinarySearch_FindIntElement_WithYield(int[] array, int searchElement, Comparer<int> comparer)
        {
            return Find(array, searchElement, comparer);
        }

        private string[] arrayString = { "a", "b", "c", "d", "e"};
        public IEnumerable<TestCaseData> TestDataString
        {
            get
            {
                yield return new TestCaseData(arrayString,"a", Comparer<string>.Default).Returns(0);
                yield return new TestCaseData(arrayString, "e",null).Returns(4);
                yield return new TestCaseData(arrayString, " ", Comparer<string>.Default).Returns(-1);
                yield return new TestCaseData(arrayString, "f", Comparer<string>.Default).Returns(-6);
            }
        }

        [Test, TestCaseSource(nameof(TestDataString))]
        public int BinarySearch_FindStringElement_WithYield(string[] array, string searchElement, Comparer<string> comparer)
        {
            return Find(array, searchElement, comparer);
        }


        [Test]
        public void BinarySearch_Object1()
        {
            Assert.That(Find<Object>(null, null, null),Is.EqualTo(-1));
        }

        private object[] arrayObject = { (object)1, (object)2, (object)3, (object)"a", (object)"b", (object)"c", (object)"d", (object)"e" };
        public IEnumerable<TestCaseData> TestDataObject
        {
            get
            {
                yield return new TestCaseData(arrayObject, 1, null).Returns(0);
                yield return new TestCaseData(arrayObject, 3,null).Returns(2);
                yield return new TestCaseData(arrayObject, "a", null).Returns(3);
                yield return new TestCaseData(arrayObject, (object)"f", Comparer<object>.Default).Returns(-9);
            }
        }

        [Test, TestCaseSource(nameof(TestDataObject))]
        public int BinarySearch_FindObjectElement_WithYield(object[] array, object searchElement, Comparer<object> comparer)
        {
            return Find(array, searchElement, comparer);
        }

        [Test]
        public void BinarySearch_Object2()
        {
            Object[] arr = new Object[2];
            arr[0] = 12;
            arr[1] = "abc";
            Assert.That(Find<Object>(arr, "abc", Comparer<object>.Default), Is.EqualTo(1));
            Assert.That(Find<Object>(arr, 12, null), Is.EqualTo(0));
        }
    }
}
