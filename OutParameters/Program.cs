using System;

namespace OutParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = new List<string>
            {
                "Coffee", "Milk", "Sugar"
            };

            Console.Write("Enter an item to search: ");
            string search = Console.ReadLine();

            if (FindInList(search, shoppingList, out int index))
            {
                Console.WriteLine($"Found {search} at index {index}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            static bool FindInList(string item, List<string> list, out int index)
            {
                index = -1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ToLower().Equals(item.ToLower()))
                    {
                        index = i;
                    }
                }
                return index > -1;
            }

        }
    }
}
