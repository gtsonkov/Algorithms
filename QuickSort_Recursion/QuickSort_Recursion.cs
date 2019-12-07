using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickSort_Recursion
{
    class QuickSort_Recursion
    {
        
        static void Main(string[] args)
        {
            Console.Write("Read file from:");
            string filePath = Console.ReadLine(); 
            using (StreamReader reader = new StreamReader(filePath))
            {
                int[] unsortedArr = reader.ReadLine().Split(" ").Select(int.Parse).ToArray();
                reader.Close();
                int len = unsortedArr.Length;
                Console.Write("Create .txt file? (y/n)");
                string saveCommand = Console.ReadLine();
                Console.WriteLine("QuickSort By Recursive Method");
                QuickSort_Recursive(unsortedArr, 0, len - 1);
                SaveToText(unsortedArr);
            }
        }

        private static void SaveToText(int[] sortedArr)
        {
            using (StreamWriter writer = new StreamWriter("endArray.txt"))
            {
                Console.WriteLine("Almoust redy");
                StringBuilder textBuilder = new StringBuilder();
                foreach (var number in sortedArr)
                {
                    textBuilder.AppendLine(number.ToString());
                }

                writer.Write(textBuilder.ToString());
            }
        }
        static public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void QuickSort_Recursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    QuickSort_Recursive(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort_Recursive(arr, pivot + 1, right);
            }
        }

    }
}