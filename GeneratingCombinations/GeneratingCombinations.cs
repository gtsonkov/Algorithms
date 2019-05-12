using System;
using System.Linq;

namespace GeneratingCombinations
{
    class GeneratingCombinations
    {
        static int[] SetOfNums;
        static void Main(string[] args)
        {
            int boarder = -1;
            int[] vector = new int[2];
            SetOfNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            GenerateCombinations(SetOfNums,vector,boarder,0);
        }

        static void GenerateCombinations(int[] SetOfNUms, int[] vector, int boarder, int Index)
        {
            if (Index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ",vector));
            }
            else
            {
                for (int i = boarder+1; i < SetOfNUms.Length; i++)
                {
                    vector[Index] = SetOfNUms[i];
                    GenerateCombinations(SetOfNUms, vector, i, Index +1);
                }
            }
        }
    }
}
