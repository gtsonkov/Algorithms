using System;

namespace Permutations
{
    using System.Linq;
    using System.Text;

    class PermutationsV1
    {
        static int[] elements;
        static bool[] used;
        static int[] permutations;
        static ulong PermutationsCount = 0;
        static StringBuilder PermutationsToPrint = new StringBuilder();

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            used = new bool[elements.Length];
            permutations = new int[elements.Length];
            Console.WriteLine(new string('-',elements.Length));
            Permute(0);
            Console.WriteLine(PermutationsToPrint);
            Console.WriteLine(new string('-', elements.Length));
            Console.WriteLine($"Total Permutations: {PermutationsCount}");
        }

        static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                if (PermutationsCount == 0)
                {
                    PermutationsCount++;
                    PermutationsToPrint.Append(string.Join(" ", permutations));
                }
                else
                {
                    PermutationsToPrint.Append(Environment.NewLine);
                    PermutationsCount++;
                    PermutationsToPrint.Append(string.Join(" ", permutations));
                }
                
                //Console.WriteLine(PermutationsCount +" : "+ string.Join(" ",permutations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        int currNumber = elements[i];
                        used[i] = true;
                        permutations[index] = currNumber;
                        Permute(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
