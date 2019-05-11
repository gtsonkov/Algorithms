using System;

namespace PermutationV2
{
    using System.Linq;
    class Program
    {
        static int[] elements;
        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
               //Using StringBuilder may be fast for some biger data inputs
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }
        static void Swap(int first, int second)
        {
            int temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Permute(0);
        }

        
    }
}
