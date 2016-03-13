using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattedOutput
{
    public static class IntExtension
    {
        public static string ConvertToHex(this int decValue)
        {
            string hexValue = "";
            if (decValue== -2147483648)
                return hexValue = "80000000";
            string[] digits = new string[16]
            {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
            int[] digitsIndex = new int[8];
            if (decValue > -1)
                digitsIndex = ToHexDigitsIndexs(decValue);
            else 
            {
                int j = 0;
                digitsIndex = ToHexDigitsIndexs((-1)*decValue);
                for (j = 0; j < digitsIndex.Length; j++)
                    digitsIndex[j] = 15 - digitsIndex[j];
                j = 7;
                digitsIndex[7]++;
                while ((digitsIndex[j])/16 == 1 && j > 0)
                {
                    digitsIndex[j] = (digitsIndex[j])%16;
                    j--;
                    digitsIndex[j]++;
                }
            }
            int i = 0; 
            while (digitsIndex[i] == 0 && i < 7)
                i++;
            for (; i < digitsIndex.Length; i++)
                hexValue += digits[digitsIndex[i]];
            return hexValue;
        }

        private static int[] ToHexDigitsIndexs(int decValue)
        {
            int[] digInd = new int[8] {0,0,0,0,0,0,0,0};
            int index = 7;
            do
            {
                digInd[index] = decValue%16;
                decValue /= 16;
                index--;
            } while (decValue != 0);
            return digInd;
        }
    }
}