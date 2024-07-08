using System;

namespace TimesTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask the user for a number for the table
            //Write a for loop to print X times table

            Console.Write("Enter a number for the table: ");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("{0} x {1} = {2}", i, number, i * number);
            }
            Console.ReadLine();
        }
    }
}
