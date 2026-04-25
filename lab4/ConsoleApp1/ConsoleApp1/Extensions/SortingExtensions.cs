using ConsoleApp1.Collections;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Extensions
{
    public static class SortingExtensions
    {
        // 1
        public static void SelectionSort(this Student[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (string.Compare(arr[j].Surname, arr[minIdx].Surname) < 0)
                        minIdx = j;
                }
                (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
            }
        }

        // 2
        public static void SelectionSort(this DoublyLinkedList<Student> list)
        {
            for (var i = list.Head; i != null; i = i.Next)
            {
                var minNode = i;
                for (var j = i.Next; j != null; j = j.Next)
                {
                    if (string.Compare(j.Data.Surname, minNode.Data.Surname) < 0)
                        minNode = j;
                }
                (i.Data, minNode.Data) = (minNode.Data, i.Data);
            }
        }

        // 3 (QuickSort)
        public static void QuickSort(this Student[] arr, int left, int right)
        {
            if (left >= right) return;

            int pivotIdx = Partition(arr, left, right);
            QuickSort(arr, left, pivotIdx - 1);
            QuickSort(arr, pivotIdx + 1, right);
        }

        private static int Partition(Student[] arr, int left, int right)
        {
            string pivot = arr[right].Surname;
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (string.Compare(arr[j].Surname, pivot) <= 0)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
            return i + 1;
        }
    }
}
