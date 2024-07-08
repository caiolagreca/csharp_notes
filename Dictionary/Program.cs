using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Quando Usar um Dictionary:
                 Quando você precisa de um mapeamento rápido e eficiente de chaves únicas para valores.
                 Quando a ordem dos elementos não é importante.
                 Quando você precisa realizar buscas rápidas com base na chave.
             */

            Dictionary<int, string> names = new Dictionary<int, string>{
                //KeyValuePair
                {1, "Caio"},
                {2, "Niedja"},
                {3, "Claudia"},
             };

            for (int i = 0; i < names.Count; i++)
            {
                KeyValuePair<int, string> pair = names.ElementAt(i);
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }

            Console.WriteLine();

            foreach (KeyValuePair<int, string> item in names)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.ReadLine();
        }
    }
}
