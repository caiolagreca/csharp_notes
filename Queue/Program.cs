using System;
using System.Collections.Generic;

namespace QueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //FIFO - First In First Out
            Queue<string> queueHeros = new Queue<string>();
            queueHeros.Enqueue("Iron Man");
            queueHeros.Enqueue("Superman");
            queueHeros.Enqueue("Hulk");

            Console.WriteLine(queueHeros.Dequeue()); //Iron Man
            Console.ReadKey();
        }
    }
}
