using System;
using System.Diagnostics;

namespace HomeWork_2
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] myArray = { 1, 2, 3, 4, 5, 6 };

            int searchValue = 3;
            BinaryResearch(myArray, searchValue);
            //O(log n)-сложность
        }

        static int BinaryResearch(int [] intputArray,int searchValue)
        {
            int min = 0;
            int max = intputArray.Length - 1;
            while (min<=max)
            {
                int mid = (min + max) / 2;
                if (searchValue==intputArray[mid])
                {
                    return mid;
                }
                else if (searchValue<intputArray[mid])
                {
                    max = mid - 1;
                }
                else if (searchValue>=intputArray[mid])
                {
                    min = mid + 1;
                }
                
            }
            return -1;
        }
      
    }
}