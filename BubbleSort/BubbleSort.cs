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
            int[] unsortedArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sortedArr = SortArray(unsortedArr);
            Console.Write("Create .txt file? (y/n)");
            string command = Console.ReadLine();
            if (command == "y")
            {
                using (StreamWriter writer = new StreamWriter("endArray.txt"))
                {
                    StringBuilder textBuilder = new StringBuilder();
                    textBuilder.AppendJoin(";", sortedArr).AppendLine();
                    writer.Write(textBuilder.ToString());
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", sortedArr));
            }
        }

        private static int[] SortArray(int[] unsortedArr)
        {
            int count = unsortedArr.Length;
            for (int i = 0; i < count -1; i++)
            {
                for (int j = 0; j < count-i - 1; j++)
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
