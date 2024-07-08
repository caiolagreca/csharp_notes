using System;

namespace GetAndSetFileds
{
    class Program
    {
        class Person
        {
            private string name;
            private int age;
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public void SetName(string name)
            {
                this.name = !string.IsNullOrEmpty(name) ? name : "Invalid Name.";
            }

            public string GetName()
            {
                return name;
            }

            public void SetAge(int age)
            {
                this.age = age >= 0 && age <= 150 ? age : -1;
            }

            //using arrow function:
            public int GetAge() => age;

            public string ReturnDetails()
            {
                return $"Name: {name}\nAge: {age}";
            }
        }
        static void Main(string[] args)
        {
            Person person = new Person("Caio", 28);
            Console.WriteLine(person.ReturnDetails());

            person.SetName("Niedja");
            person.SetAge(27);
            Console.WriteLine(person.ReturnDetails());

            Console.WriteLine($"Your name is {person.GetName()} and yout age is {person.GetAge()}");
            Console.ReadLine();

        }
    }
}
