using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var tempArr = new int[input.Length];

            arrayPart(input,tempArr, 0, input.Length);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void arrayPart(int[] arr, int[] tempArr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                arrayPart(arr, tempArr, left, middle);
                arrayPart(arr, tempArr, middle + 1, right);

                merge(arr, tempArr, left, middle, right);
            }
        }

        private static void merge(int[] arr, int[] tempArr, int left, int middle, int right)
        {
            var leftArr = (right + left) / 2;
            var rightArr = leftArr + 1;

            int size = rightArr - leftArr + 1;

            int a = 0;
            int b = middle;
            int c = 0;

            while (a < leftArr && b < rightArr)
            {
                if (arr[a] <= arr[b])
                {
                    tempArr[c] = arr[a];
                    a++;
                }

                else
                {
                    tempArr[c] = arr[b];
                    b++;
                }

                c++;
            }

            for (int i = a; i < leftArr-(a+1); i++)
            {
                tempArr[c] = arr[i];
                c++;
            }

            for (int i = b; i < rightArr - b; i++)
            {
                tempArr[c] = arr[i];
                c++;
            }

            for (int i = leftArr; i < size; i++)
            {
                arr[i] = tempArr[i];
            }
        }
    }
}