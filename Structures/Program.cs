using System;

namespace Structures
{
    class Program
    {

        struct Person
        {
            public string name;
            public int age;
            public int birthMonth;
            public int phoneNumber;

            //Constructor
            public Person(string name, int age, int birthMonth, int phoneNumber)
            {
                this.name = name;
                this.age = age;
                this.birthMonth = birthMonth;
                this.phoneNumber = phoneNumber;

            }
        }
        static void Main(string[] args)
        {
            Person person = ReturnPerson();
            Console.WriteLine($"{person.name} - {person.age} - {person.birthMonth} - {person.phoneNumber}");
            Console.ReadLine();
        }

        static Person ReturnPerson()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter your birthMonth: ");
            int birthMonth = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter your phoneNumber: ");
            int phoneNumber = Convert.ToInt16(Console.ReadLine());

            return new Person(name, age, birthMonth, phoneNumber);

        }
    }
}
