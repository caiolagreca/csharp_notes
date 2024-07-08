using System;

namespace Classes
{
    class Program
    {

        class Person
        {
            public string name;
            public int age;

            //This is the Default Constructor
            public Person()
            {
            }

            public Person(string name)
            {
                this.name = name;

            }

            public Person(int age)
            {
                this.age = age;
            }
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = Convert.ToInt16(Console.ReadLine());

            Person person = new Person(name, age);
            Person person2 = new Person();
            Person person3 = new Person(name);
            Person person4 = new Person(age);

            Console.WriteLine($"{person.name}, {person.age}");
            Console.WriteLine(person2);
            Console.WriteLine(person3.name);
            Console.WriteLine(person4.age);


        }

    }
}
