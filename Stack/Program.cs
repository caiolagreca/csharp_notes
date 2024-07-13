using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //LIFO - Last In First Out   
            Stack<string> stackHeros = new Stack<string>();
            stackHeros.Push("Iron Man");
            stackHeros.Push("Superman");
            stackHeros.Push("Hulk");

            Console.WriteLine(stackHeros.Pop()); //Hulk
            Console.ReadKey();
        }
    }
}
