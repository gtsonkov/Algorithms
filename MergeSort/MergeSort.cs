using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

           var result = DataPart(input);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> DataPart(List<int> input)
        {
            if (input.Count == 1)
            {
                return input;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = input.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(input[i]);
            }

            for (int i = middle; i < input.Count; i++)
            {
                right.Add(input[i]);
            }

            left = DataPart(left);
            right = DataPart(right);

            return Merge(left,right);

        }

        private static List<int> Merge(List<int>left, List<int>right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    var leftElement = left.First();
                    var rightElement = right.First();

                    if (leftElement <= rightElement)
                    {
                        result.Add(leftElement);
                        left.Remove(leftElement);
                    }

                    else
                    {
                        result.Add(rightElement);
                        right.Remove(rightElement);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if(right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }
    }
}