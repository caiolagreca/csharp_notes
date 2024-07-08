using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Quando Usar Array:
                Use arrays quando você sabe que o tamanho da coleção será fixo e não mudará.
                Para cenários de alto desempenho onde o acesso rápido ao índice é crucial.
             */

            const int numAngles = 3;
            int[] angles = new int[numAngles];

            for (int i = 0; i < angles.Length; i++)
            {
                Console.WriteLine($"Enter angle {i + 1}: ");
                angles[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sumAngles = 0;
            foreach (int angle in angles)
            {
                sumAngles += angle;
            }
            Console.WriteLine(sumAngles == 180 ? "Valid" : "Invalid");

            //ARRAY SORTING

            int[] numbers = new int[]{
                9,2,1,5,5,6,7,8,9
            };
            Array.Sort(numbers);

            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine();

            //ARRAY REVERSE
            //you can reverse simply with the method: Array.Reverse(numbers), but here I am reversing manually to practice.
            //NOTE: To reverse it, the list needs to be sorted first. (which, in this case, it is already through the method Sorted passed before).

            int[] reversedArray = new int[numbers.Length];

            int x = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                reversedArray[x] = numbers[i];
                x++;
            }

            foreach (int num in reversedArray)
            {
                Console.Write($"{num},");
            }
            Console.WriteLine();

            //ARRAY CLEAR
            //Array.Clear(numbers, 0, numbers.Length) - This method eliminates all the items in the array. Starting from 0 to all the length of array.
            Array.Clear(numbers, 5, 3); //In this case we are eliminating 3 items, starting from index 5

            foreach (int num in numbers)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            //EXERCISE
            /* Create a table of multiples of 7 with a defined length. */

            int multiple = 7;
            int tableLength = 5;
            int[] table = new int[tableLength];
            int count = 0;

            for (int i = 1; i <= tableLength; i++, count++)
            {
                table[count] = multiple * i;
            }

            foreach (int item in table)
            {
                Console.Write($"{item} ");
            }

            Console.ReadLine();

        }
    }
}
