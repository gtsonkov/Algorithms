using System;

namespace PermutationsV2
{
    using System.Linq;
    using System.Text;

    class PermutationsV2
    {
        static int[] elements;
        static ulong PermutationsCount = 0;
        static StringBuilder PermutationsToPrint = new StringBuilder();

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(new string('-', elements.Length));
            Permute(0);
            //Console.WriteLine(PermutationsToPrint);
            Console.WriteLine(new string('-', elements.Length));
            Console.WriteLine($"Total Permutations: {PermutationsCount}");
        }

        static void Permute(int index)
        {
            if (index >= elements.Length)
                Console.WriteLine(PermutationsCount + " : " + string.Join(" ", elements));
            else
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, 1);
                }

        }
        static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
