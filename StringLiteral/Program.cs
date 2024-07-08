using System;

namespace StringLiteral
{
    class Program

    {
        static void Main(string[] args)
        {
            string speech = "He said \"something\"";
            string path = "C:\\Users\\CoffeeCode\\Desktop\nNew line test";
            Console.WriteLine(path);
            Console.WriteLine(speech);

            path = @"C:\Users\CoffeeCode\Desktop" + "\nNew line test";
            Console.WriteLine(path);

            string name = @"Hello ""someone""";
            Console.WriteLine(name);

            name = "Hello 'someone'";
            Console.WriteLine(name);

            //String formatting:
            string newName = "Caio";
            int age = 28;

            Console.WriteLine("Your name is {0} and your age is {1}", newName, age);
            Console.WriteLine("Name: {0}\nAge: {1}", newName, age);

            //String interpolation:
            Console.WriteLine($"Your name is {newName} and you are {age}");

            //String concatenation:
            string test = string.Concat("Your name is ", newName, " and your age is ", age);
            Console.WriteLine(string.Concat("Your name is ", newName, " and your age is ", age));

            //Empty String:
            Console.WriteLine("Enter your name: ");
            string nome = Console.ReadLine();

            if (nome != string.Empty)
            {
                Console.WriteLine($"Your name is {nome}");
            }
            else
            {
                Console.WriteLine("Name is empty");
            }

            //String Equals Function
            string message1 = "Hello";
            string message2 = "Hello";

            if (message1.Equals(message2))
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }

            Console.WriteLine("Enter your name: ");
            string name2 = Console.ReadLine();

            if (!name2.Equals(""))
            {
                Console.WriteLine($"Your name is {name2}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            //String isNullOrEmpty Function

            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            Console.WriteLine("{0}", name);

            if (!string.IsNullOrEmpty(name))
            {
                if (name.Equals("Caio"))
                {
                    Console.WriteLine("Correct");
                }
            }
            Console.ReadKey();

        }
    }
}
