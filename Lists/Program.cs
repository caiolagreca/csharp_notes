using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Quando Usar List:
                Use List quando você precisa de uma coleção dinâmica cujo tamanho pode mudar durante a execução.
                Quando você precisa das funcionalidades adicionais fornecidas por List, como inserção e remoção flexível de elementos.
             */

            List<int> listNumbers = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter a number: ");
                listNumbers.Add(Convert.ToInt32(Console.ReadLine()));
            }

            for (int i = 0; i < listNumbers.Count; i++)
            {
                Console.WriteLine(listNumbers[i]);
            }
            listNumbers.RemoveAt(0);

            foreach (var item in listNumbers)
            {
                Console.Write($"{item} ");
            }

            //EXERCISE
            /* Create two lists with integer data type, one for even numbers and one for odd.
            Loop from 0-20.
            if Number is even, add to even list; if is odd, add to odd list.
            Print even and odd lists.
             */

            List<int> odd = new List<int>();
            List<int> even = new List<int>();

            for (int i = 0; i < 30; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(i);
                }
                else
                {
                    odd.Add(i);
                }
            }

            Console.WriteLine(Environment.NewLine + "Priting even numbers:"); //Environment.NewLine  insere uma nova linha no início da mensagem
            foreach (var item in even)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(Environment.NewLine + " Printing odd numbers:");
            foreach (var item in odd)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();

        }
    }
}
