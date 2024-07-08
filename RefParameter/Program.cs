using System;

namespace RefParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 10;
            Assign(out num);
            Console.WriteLine(num);
            Console.ReadLine();
        }

        static void Assign(out int num)
        {
            num = 20;
        }
    }
}
