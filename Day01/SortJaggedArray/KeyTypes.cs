using System;
using System.Collections.Generic;

namespace JaggedArray
{
    public class CompareMaxAbcAsc : IComparer<Int32[]>
    {
        public  int Compare(int[] obj1, int[] obj2)
        {
            if (obj1 == null && obj2 == null) return 0;
            if (obj1 == null) return -1;
            if (obj2 == null) return 1;
            if (obj1.Length == 0 && obj2.Length == 0) return 0;
            if (obj1.Length == 0) return -1;
            if (obj2.Length == 0) return 1;
            // сейчас в обоих массивах есть хотя бы по одному элементу
            long key1 = obj1[0], key2=obj2[0];
            for (int i = 1; i < obj1.Length; i++)
                if (Math.Abs(obj1[i]) > key1)
                    key1 = Math.Abs(obj1[i]);
            for (int i = 1; i < obj2.Length; i++)
                if (Math.Abs(obj2[i]) > key2)
                    key2 = Math.Abs(obj2[i]);
            if (key1 - key2 > 0) return 1;
            if (key1 == key2) return 0;
            return -1;
        }
    }
    public class CompareSumAsc : IComparer<Int32[]>
    {
        public int Compare(int[] obj1, int[] obj2)
        {
            if (obj1 == null && obj2 == null) return 0;
            if (obj1 == null) return -1;
            if (obj2 == null) return 1;
            if (obj1.Length == 0 && obj2.Length == 0) return 0;
            if (obj1.Length == 0) return -1;
            if (obj2.Length == 0) return 1;
            // сейчас в обоих массивах есть хотя бы по одному элементу
            long key1 = obj1[0], key2 = obj2[0];
            for (int i = 1; i < obj1.Length; i++)
                key1 += obj1[i];
            for (int i = 1; i < obj2.Length; i++)
                key2 += obj2[i];
            if (key1 - key2 > 0) return 1;
            if (key1 == key2) return 0;
            return -1;
        }
    }
    
}
