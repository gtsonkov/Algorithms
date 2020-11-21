using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestPosibleRange
{
    class LongestPosibleRange
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, bool> nums = new Dictionary<int, bool>();

            for (int i = 0; i < input.Length; i++)
            {
                nums.Add(input[i], true);
            }

            int longestRange = 0;
            int firstValue = 0;
            int lastValue = 0;

            int iterations = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[input[i]] != true)
                {
                    continue;
                }

                int currNum = nums.Keys.ElementAt(i);

                nums[currNum] = false;

                int currRangeLength = 1;
                int currFirstValue = currNum;
                int currLastValue = currNum;
                iterations = i;

                while (true)
                {
                    if (nums.ContainsKey(currLastValue + 1))
                    {
                        currLastValue++;
                        currRangeLength++;
                        nums[currLastValue] = false;

                        continue;
                    }

                    if (nums.ContainsKey(currFirstValue - 1))
                    {
                        currFirstValue--;
                        currRangeLength++;
                        nums[currFirstValue] = false;

                        continue;
                    }

                    break;
                }

                if (currRangeLength > longestRange)
                {
                    longestRange = currRangeLength;
                    firstValue = currFirstValue;
                    lastValue = currLastValue;
                }

                if (longestRange > (nums.Count / 2))
                {
                    break;
                }
            }

            Console.WriteLine($"[{firstValue} - {lastValue}] : {iterations}");
        }
    }
}