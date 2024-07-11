using System;

namespace DoWhileStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intArray = new int[5][];
            intArray[0] = new int[3];
            intArray[1] = new int[6];
            intArray[2] = new int[10];

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i] == null);
                intArray[i] = new int[6];
            }
            intArray[0][2] = 5;

            Console.WriteLine("----------");

            int[,] multiArray = new int[3, 4];

            for (int i = 0; i < multiArray.GetLength(0); i++)
            {
                for (int j = 0; j < multiArray.GetLength(1); j++)
                {
                    Console.WriteLine($"{i}, {j}: {multiArray[i, j]}");
                }
            }

            Console.WriteLine("----------");


        }
    }
}
