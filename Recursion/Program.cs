using System;

namespace DoWhileStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            while (number < 5)
            {
                number++;
            }
            Console.WriteLine(number);

            Console.WriteLine("----------");
            Console.WriteLine("Refactoring with Recursion:");

            Console.WriteLine(RecursionIncrementer(0));
        }

        private static int RecursionIncrementer(int number)
        {
            if (number < 5)
            {
                return RecursionIncrementer(number + 1);
            }
            else
            {
                return number;
            }
        }
    }
}
