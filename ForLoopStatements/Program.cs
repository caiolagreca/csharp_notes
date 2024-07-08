using System;

namespace ForLoopStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many times do you want to say hi? ");
            int loopNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < loopNumber; i++)
            {
                Console.WriteLine("Hi " + i);
            }

        }
    }
}
