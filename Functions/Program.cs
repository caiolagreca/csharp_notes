using System;
using System.Runtime.InteropServices;

namespace Functions
{

    class Test
    {
        public void something()
        {
            Console.WriteLine("Bye Caio!");
        }
    }
    class Program
    {
        static void Main()
        {
            WelcomeMessage();
            Test test = new Test();
            test.something();
            OptionalParameter();

            Console.ReadLine();

        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Hello Caio!");
        }

        //OPTIONAL PARAMETERS
        static void OptionalParameter()
        {
            int result = Add(5);
            Console.WriteLine(result);
        }

        static int Add(int a, int b = default)
        {
            return a + b;
        }
    }
}
