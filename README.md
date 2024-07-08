# Creating and running projects to practice:

```bash
dotnet new console -n NameOfProject
dotnet sln add NameOfProject/NameOfProject.csproj
cd NameOfProject
dotnet run
```

# O que eh a extensao .csproj?

É um arquivo XML que especifica metadados como o framework de destino, tipo de saída (por exemplo, executável ou biblioteca) e referências a pacotes NuGet e outros projetos. é essencial para o SDK do .NET e IDEs como o Visual Studio entenderem como compilar, construir e executar o projeto, garantindo que todos os recursos e configurações necessários sejam gerenciados corretamente.
É similar ao package.json de um projeto Javascript.

# O que sao abstracoes?

1. Classes Abstratas:

Uma classe abstrata é uma classe que não pode ser instanciada diretamente. Ela é destinada a ser uma classe base para outras classes.
Pode conter métodos abstratos (sem implementação) e métodos concretos (com implementação).
Métodos abstratos devem ser implementados por qualquer classe derivada que não seja abstrata.

Use classes abstratas quando tiver uma base comum de implementação ou estado que deve ser compartilhado entre classes relacionadas em uma hierarquia.

```csharp
// Exemplo de classe abstrata
public abstract class Animal
{
    // Método abstrato (sem implementação)
    public abstract void MakeSound();

    // Método concreto (com implementação)
    public void Sleep()
    {
        Console.WriteLine("Sleeping...");
    }
}

// Classe concreta que herda de Animal
public class Dog : Animal
{
    // Implementação do método abstrato
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}
```

2. Interfaces:

Uma interface é um contrato que define um conjunto de métodos e propriedades que uma classe deve implementar.
As interfaces não podem conter implementação, apenas assinaturas de métodos.
Uma classe pode implementar múltiplas interfaces, permitindo uma forma de herança múltipla.

Use interfaces quando quiser definir um contrato ou comportamento que pode ser compartilhado por classes não relacionadas, e quando precisar de flexibilidade para implementar múltiplas funcionalidades.

```csharp
// Exemplo de interface
public interface IFlyable
{
    void Fly();
}

// Classe que implementa a interface
public class Bird : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Flying...");
    }
}
```

# Diferenca entre Ref Parameter X Out Parameter

1. Ref:

Deve ser inicializado antes de passar para o método.
Use quando você precisa que um método leia e modifique o valor de um argumento passado.
Jse quando o argumento deve ser inicializado antes de ser passado ao método.

```csharp
using System;

namespace RefExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 5;  // Deve ser inicializado
            MultiplyByTwo(ref number);
            Console.WriteLine(number); // Output: 10
        }

        static void MultiplyByTwo(ref int num)
        {
            num *= 2;
        }
    }
}
```

2. Use out:

Não precisa ser inicializado antes de passar para o método
Use quando você quer que um método retorne múltiplos valores ou quando um método precisa retornar um valor através de um parâmetro que não precisa ser inicializado antes da chamada.
Use quando o método deve garantir que o argumento tenha um valor atribuído antes de retornar.

```csharp
using System;

namespace OutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int result;  // Não precisa ser inicializado
            GetProduct(3, 4, out result);
            Console.WriteLine(result); // Output: 12
        }

        static void GetProduct(int a, int b, out int product)
        {
            product = a * b;  // Deve ser atribuído antes de retornar
        }
    }
}
```

# Data Types:

Data Type - Size - Description
int - 4 bytes - Stores whole numbers from -2,147,483,648 to 2,147,483,647
long - 8 bytes - Stores whole numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
float - 4 bytes - Stores fractional numbers. Sufficient for storing 6 to 7 decimal digits
double - 8 bytes - Stores fractional numbers. Sufficient for storing 15 decimal digits
bool - 1 bit - Stores true or false values
char - 2 bytes - Stores a single character/letter, surrounded by single quotes
string - 2 bytes per character - Stores a sequence of characters, surrounded by double quotes

# Overloading Methods:

Multiple methods can have the same name as long as the number and/or type of parameters are different.
In the case bellow, we have the same number of parameters, but different types (int and double).

```csharp
static int PlusMethod(int x, int y)
{
  return x + y;
}

static double PlusMethod(double x, double y)
{
  return x + y;
}

static void Main(string[] args)
{
  int myNum1 = PlusMethod(8, 5);
  double myNum2 = PlusMethod(4.3, 6.26);
  Console.WriteLine("Int: " + myNum1);
  Console.WriteLine("Double: " + myNum2);
}
```

# Using Multiple Classes:

we can use multiple classes for better organization (one for fields and methods, and another one for execution).

```csharp
//prog2.cs
class Car
{
  public string model;
  public string color;
  public int year;
  public void fullThrottle()
  {
    Console.WriteLine("The car is going as fast as it can!");
  }
}

//prog.cs
class Program
{
  static void Main(string[] args)
  {
    Car Ford = new Car();
    Ford.model = "Mustang";
    Ford.color = "red";
    Ford.year = 1969;

    Car Opel = new Car();
    Opel.model = "Astra";
    Opel.color = "white";
    Opel.year = 2005;

    Console.WriteLine(Ford.model);
    Console.WriteLine(Opel.model);
  }
}
```

# Acess Modifiers:

Why Access Modifiers?
To control the visibility of class members (the security level of each individual class and class member).
To achieve "Encapsulation" - which is the process of making sure that "sensitive" data is hidden from users. This is done by declaring fields as private.

Modifier - Description
public - The code is accessible for all classes
private - The code is only accessible within the same class
protected - The code is accessible within the same class, or in a class that is inherited from that class.
internal - The code is only accessible within its own assembly, but not from another assembly.

There's also two combinations: protected internal and private protected.
Note: By default, all members of a class are private if you don't specify an access modifier.

# Properties (Get and Set) and Encapsulation :

The meaning of Encapsulation, is to make sure that "sensitive" data is hidden from users. To achieve this, you must:
declare fields/variables as private
provide public get and set methods, through properties, to access and update the value of a private field

A property is like a combination of a variable and a method, and it has two methods: a get and a set method:

```csharp
class Person
{
    private string name; //field

    public string Name //The Name property is associated with the name field. It is a good practice to use the same name for both the property and the private field, but with an uppercase first letter.
    {
        get
        {
            return name; //The get method returns the value of the variable name.
        }
        set
        {
            name = value; //The set method assigns a value to the name variable. The value keyword represents the value we assign to the property.
        }
    }
}

class Program
{
  static void Main(string[] args)
  {
    Person myObj = new Person();
    myObj.Name = "Liam";
    Console.WriteLine(myObj.Name);
  }
}
```

# Automatic Properties (Short Hand):

```csharp
class Person
{
    private string name;

    public string Name
    {get; set;}
}

class Program
{
    static void Main(string[] args)
    {
        Person myObj = new Person();
        myObj.Name = "Caio";
        Console.WriteName(myObj.Name);
    }
}
```

Why Encapsulation?
Better control of class members (reduce the possibility of yourself (or others) to mess up the code)
Fields can be made read-only (if you only use the get method), or write-only (if you only use the set method)
Flexible: the programmer can change one part of the code without affecting other parts
Increased security of data

# The sealed Keyword:

If you don't want other classes to inherit from a class, use the sealed keyword

```csharp
sealed class Vehicle
{
  ...
}

class Car : Vehicle
{
  ...
}
//Output - 'Car': cannot derive from sealed type 'Vehicle'
```

# Extra Notes:

- A static method can be accessed without creating an object of the class, while public methods can only be accessed by objects.
#   c s h a r p _ n o t e s  
 