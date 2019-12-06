using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BubbleSort
{
    class BubbleSort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read data from: ");
            Console.WriteLine("0 - Console");
            Console.WriteLine("1 - File");
            string readFromCommand = Console.ReadLine();

            if (readFromCommand == "0")
            {
                int[] unsortedArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int[] sortedArr = SortArray(unsortedArr);
                Console.Write("Create .txt file? (y/n)");
                string saveCommand = Console.ReadLine();

                if (saveCommand == "y")
                {

                    SaveToText(sortedArr);
                }

                else
                {
                    PrintToConsole(sortedArr);
                }
            }

            else
            {
                Console.Write("File path:");
                string filePath = Console.ReadLine();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int[] unsortedArr = reader.ReadLine().Split(" ").Select(int.Parse).ToArray();
                    reader.Close();
                    int[] sortedArr = SortArray(unsortedArr);
                    Console.Write("Create .txt file? (y/n)");
                    string saveCommand = Console.ReadLine();

                    if (saveCommand == "y")
                    {
                        SaveToText(sortedArr);
                    }

                    else
                    {
                        PrintToConsole(sortedArr);
                    }
                }
            }
        }

        private static void PrintToConsole(int[] sortedArr)
        {
            Console.WriteLine(string.Join(" ", sortedArr));
        }

        private static void SaveToText(int[] sortedArr)
        {
            using (StreamWriter writer = new StreamWriter("endArray.txt"))
            {
                StringBuilder textBuilder = new StringBuilder();
                foreach (var number in sortedArr)
                {
                    textBuilder.AppendLine(number.ToString());
                }

                writer.Write(textBuilder.ToString());
            }
        }

        private static int[] SortArray(int[] unsortedArr)
        {
            int count = unsortedArr.Length;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (unsortedArr[j] > unsortedArr[j+1])
                    {
                        int tempNumber = unsortedArr[j];
                        unsortedArr[j] = unsortedArr[j+1];
                        unsortedArr[j + 1] = tempNumber;
                    }
                }
            }

            return unsortedArr;
        }
    }
}
