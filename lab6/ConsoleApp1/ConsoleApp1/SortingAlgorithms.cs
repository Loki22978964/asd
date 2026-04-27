using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SortingAlgorithms
    {
        // Binary Radix Sort / MSB)
        public static void RadixBinarySort(int[] array)
        {
            if (array == null || array.Length <= 1) return;
            
            SortBit(array, 0, array.Length - 1, 30);
        }

        private static void SortBit(int[] array, int left, int right, int bit)
        {
            if (left >= right || bit < 0) return;

            int i = left;
            int j = right;

            while (i <= j)
            {
                while (i <= j && ((array[i] >> bit) & 1) == 0) i++;

                while (i <= j && ((array[j] >> bit) & 1) == 1) j--;

                if (i < j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            SortBit(array, left, j, bit - 1);
            SortBit(array, i, right, bit - 1);
        }

        //Bubble Sort
        public static void BubbleSort(int[] array)
        {
            if (array == null) return;
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                
                if (!swapped) break;
            }
        }
    }
}
