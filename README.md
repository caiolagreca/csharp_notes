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

# Polymorphism and Overriding Methods:

Polymorphism allos us to use inheritanced methods to perform a single action in a different ways.
To override the base class method, we have to add the virtual keyword to the method inside the base class, and the override keyword for each derived class methods:

```csharp
class Animal  // Base class (parent)
{
  public virtual void animalSound()
  {
    Console.WriteLine("The animal makes a sound");
  }
}

class Pig : Animal  // Derived class (child)
{
  public override void animalSound()
  {
    Console.WriteLine("The pig says: wee wee");
  }
}

class Dog : Animal  // Derived class (child)
{
  public override void animalSound()
  {
    Console.WriteLine("The dog says: bow wow");
  }
}

class Program
{
  static void Main(string[] args)
  {
    Animal myAnimal = new Animal();  // Create a Animal object
    Animal myPig = new Pig();  // Create a Pig object
    Animal myDog = new Dog();  // Create a Dog object

    myAnimal.animalSound();
    myPig.animalSound();
    myDog.animalSound();
  }
}
```

# Abstract Classes and Methods:

Data abstraction is the process of hiding certain details and showing only essential information to the user.
Abstraction can be achieved with either abstract classes or interfaces.

Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
An abstract class can have both abstract and regular methods.

Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).

```csharp
abstract class Animal
{
    // Abstract method (does not have a body)
    public abstract void animalSound();

    // Regular method
    public void sleep()
    {
        Console.WriteLine("Zzz");
    }
}

// Derived class (inherit from Animal)
class Pig : Animal
{
  public override void animalSound()
  {
    // The body of animalSound() is provided here
    Console.WriteLine("The pig says: wee wee");
  }
}

class Program
{
  static void Main(string[] args)
  {
    Pig myPig = new Pig(); // Create a Pig object
    myPig.animalSound();  // Call the abstract method
    myPig.sleep();  // Call the regular method
  }
}
```

# Interfaces:

Like abstract classes, interfaces cannot be used to create objects (in the example above, it is not possible to create an "IAnimal" object in the Program class).

Makes your code more modular.

It is considered good practice to start with the letter "I" at the beginning of an interface, as it makes it easier for yourself and others to remember that it is an interface and not a class.

You do not have to use the override keyword when implementing an interface.

Interface methods do not have a body - the body is provided by the "implement" class.

On implementation of an interface, you must override all of its methods.

Interfaces can contain properties and methods, but not fields/variables.

Interface members are by default abstract and public.

An interface cannot contain a constructor (as it cannot be used to create objects).

Like said before, but in other words: Interfaces can not story any data.

In new csharp versions you can add optional default implementation, meaning that you can add a logic into the Method() of the Interface and don't be obligate to implement in the class that uses the interface (it will automatically use the default method implemented in the interface). But remember, to use that, you must implement something into the Method in the Interface. (take a look at the Interface Folder Example )

```csharp
// Interface
interface IAnimal
{
  void animalSound(); // interface method (does not have a body)
}

// Pig "implements" the IAnimal interface
class Pig : IAnimal
{
  public void animalSound()
  {
    // The body of animalSound() is provided here
    Console.WriteLine("The pig says: wee wee");
  }
}

class Program
{
  static void Main(string[] args)
  {
    Pig myPig = new Pig();  // Create a Pig object
    myPig.animalSound();
  }
}
```

- Multiple Interfaces:
  C# does not support "multiple inheritance" (a class can only inherit from one base class). However, it can be achieved with interfaces, because the class can implement multiple interfaces. Note: To implement multiple interfaces, separate them with a comma.

```csharp
interface IFirstInterface
{
    void myMethod(); // interface method
}

interface ISecondInterface
{
    void myOtherMethod(); // interface method
}

// Implement multiple interfaces
class DemoClass : IFirstInterface, ISecondInterface
{
    public void myMethod()
    {
        Console.WriteLine("Some text..");
    }
    public void myOtherMethod()
    {
        Console.WriteLine("Some other text...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        DemoClass myObj = new DemoClass();
        myObj.myMethod();
        myObj.myOtherMethod();
    }
}
```

# Enums:

An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
To create an enum, use the enum keyword (instead of class or interface), and separate the enum items with a comma.
Use enums when you have values that you know aren't going to change, like month days, days, colors, deck of cards, etc.

```csharp
class Program
{
  enum Level
  {
    Low,
    Medium,
    High
  }
  static void Main(string[] args)
  {
    Level myVar = Level.Medium;
    Console.WriteLine(myVar);
  }
}
```

- Enum Values:
  By default, the first item of an enum has the value 0. The second has the value 1, and so on.
  To get the integer value from an item, you must explicitly convert the item to an int

```csharp
enum Months
{
  January,    // 0
  February,   // 1
  March,      // 2
  April,      // 3
  May,        // 4
  June,       // 5
  July        // 6
}

static void Main(string[] args)
{
  int myNum = (int) Months.April;
  Console.WriteLine(myNum);
}
```

You can also assign your own enum values, and the next items will update their numbers accordingly:

```csharp
enum Months
{
  January,    // 0
  February,   // 1
  March=6,    // 6
  April,      // 7
  May,        // 8
  June,       // 9
  July        // 10
}

static void Main(string[] args)
{
  int myNum = (int) Months.April;
  Console.WriteLine(myNum);
}
```

# Working with Files:

The File class from the System.IO namespace, allows us to work with files.

Method - Description
AppendText() - Appends text at the end of an existing file
Copy() - Copies a file
Create() - Creates or overwrites a file
Delete() - Deletes a file
Exists() - Tests whether the file exists
ReadAllText() - Reads the contents of a file
Replace() - Replaces the contents of a file with the contents of another file
WriteAllText() - Creates a new file and writes the contents to it. If the file already exists, it will be overwritten.

```csharp
using System.IO;  // include the System.IO namespace

string writeText = "Hello World!";  // Create a text string
File.WriteAllText("filename.txt", writeText);  // Create a file and write the content of writeText to it

string readText = File.ReadAllText("filename.txt");  // Read the contents of the file
Console.WriteLine(readText);  // Output the content
```

# O que sao Records:

Implementado no C# 9.0. Traz uma nova maneira de definir tipos de dados imutavies, otimizados para igualdade de valor. Sao uteis para modelar dados e objetos que nao devem mudar apos a criacao.

Comparação entre Classe e Record:
Característica - Classe - Record
Mutabilidade - Mutável por padrão - Imutável por padrão
Igualdade - Comparação por referência - Comparação por valor
Sintaxe - Sintaxe completa para definir propriedades e construtores - Sintaxe simplificada para propriedades e construtores
Uso Comum - Objetos que representam entidades com comportamento e estado mutável - Objetos que representam dados imutáveis e modelagem de dados
Clonagem - Implementação manual de métodos de clonagem - Implementação automática de métodos de clonagem (with expression)

Classes são melhores para cenários onde você precisa de objetos mutáveis com comportamentos e métodos.

```csharp
public class MutablePerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public MutablePerson(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

// Uso
var person1 = new MutablePerson("John", "Doe");
var person2 = person1;
person2.FirstName = "Jane";

// person1 e person2 são iguais porque referem-se ao mesmo objeto
Console.WriteLine(person1.FirstName); // Saída: Jane
```

Records são ideais para cenários onde você está modelando dados imutáveis e precisa de igualdade de valor.

```csharp
public record Person(string FirstName, string LastName);

// Uso
var person1 = new Person("John", "Doe");
var person2 = person1 with { FirstName = "Jane" };

// person1 e person2 são diferentes
Console.WriteLine(person1.FirstName); // Saída: John
Console.WriteLine(person2.FirstName); // Saída: Jane
```

# O que sao DTOs?

Um DTO (Data Transfer Object) é um padrão de design usado para transferir dados entre camadas de um aplicativo, especialmente em arquiteturas de software onde é necessário passar dados entre o cliente e o servidor, ou entre diferentes partes de um sistema. O principal objetivo de um DTO é transportar dados sem comportamento, ou seja, sem lógica de negócios.

Características dos DTOs
Simples e Sem Comportamento: DTOs contêm apenas propriedades e não possuem métodos ou lógica de negócios.
Usados para Transferência de Dados: São usados principalmente para transportar dados entre camadas ou sistemas.
Desacoplamento: Ajudam a desacoplar as camadas do sistema, especialmente em aplicações distribuídas, como aquelas que usam APIs RESTful.
Serialização e Desserialização: Facilitam a serialização e desserialização de dados, o que é útil para comunicação entre sistemas diferentes, como entre um cliente e um servidor via JSON ou XML.

Exemplo:

```csharp
//Primeiro, definimos a entidade de domínio, que pode conter lógica de negócios.
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}

//Agora, definimos um DTO para transferir dados do usuário sem a lógica de negócios.
public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
```

# Lambda Expressions:

Sao funcoes anonimas, semelhantes ao arrow function em JS.
Usada em LINQ, callbacks, middleware...
Sintaxe:

```csharp
(parameters) => expression
(parameters) => { statement; }
```

Exemplos:

```csharp
//Filtro de Numeros paraes
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
evenNumbers.ForEach(n => Console.WriteLine(n));
```

```csharp
//Callback em Event Listener
using System;

public class Button
{
    public event EventHandler Click;

    public void SimulateClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}

public class Program
{
    public static void Main()
    {
        Button button = new Button();
        button.Click += (sender, e) => Console.WriteLine("Button was clicked!");
        button.SimulateClick();
    }
}
```

# Delegates:

Permitem que metodos sejam passados como parametros e sao armazenados em variaveis.

Características dos Delegates
Tipo Seguro: garantem que apenas métodos com a assinatura correspondente possam ser atribuídos a eles.
Multicast: podem referenciar mais de um método, permitindo chamar vários métodos com uma única invocação de delegate.
Base para Eventos: são a base para a implementação de eventos.

When to use? When we need to pass a method as a parameter(arguments) to other methods. (Callback function)

Example:

```csharp
delegate void PrintDelegate(string text);


//Delegate Method
PrintDelegate PrintConsole = (string text) => {
  Console.WriteLine(text);
};

//Delegate Method
PrintDelegate PrintToFile = (string text) => {
  File.AppendAllText("./logs.txt", text);
};

//Method that will callback the Delegate
static void ConnectToDatabase(PrintDelegate log)
{
  log("Insert new record to db");
  log("The record was done");
}

ConnectToDatabase(PrintToFile);
```

Other Example:

```csharp
public delegate void StringDelegate(string  text);

public class Program
{
  static void Main(string[] args)
  {
    StringDelegate stringDelegate = ToUpperCase;
    WriteOutput("This is a lowercase string", stringDelegate);
  }

  static void ToUpperCase(string text) => Console.WriteLine(text.ToUpper());
  static void ToLowerCase(string text) => Console.WriteLine(text.ToLower());

  static void WriteOutput(string text, StringDelegate ToUpperCase)
  {
    Console.WriteLine("$Before: {text}");
    stringDelegate(text);
  }
}
/* OUTPUT
Before: this is a lowercase string
THIS IS A LOWERCASE STRTNG
 */
```

Built in Delegates:

1. Func: T Method (T1 ...T16);
   This Delegate takes a type and can take from 0 to 16 input parameters of any object type
   Declaring it:

```csharp
// The last parameter is always the return type. So in the case bellow the Func Delegate has a string parameter and a string as return.
// The pointer is the variable name
Func<string, string> pointer = SomeMethod;

string SomeMethod(String str){
//...logic of method
}
//To invoke the reference method, there are two options:
pointer("Hello World");
pointer.Invoke("Hello World");

//We can use with Lambda expression as well:
Func<string, string> pointer = (str) => "$" + str;
```

2. Action: - void Method(T1 ... T16);
   Is the same as Func Delegate, but it doens't return any type.

```csharp
Action<string, string> //Both are input parameters

Array.ForEach(Action<T>)
```

3. Predicate: - bool Method(T1);
   It takes only one parameter of any type and always return a boolean.

```csharp
Predicate<int>
```

# Params:

When you have a method and wants to receive any number of parameters, use the "params" keyword

```csharp
public class Program {

  static void Main (string[] args)
  {
    PrintPlayerName(35, "Caio", "Niedja", "Rodrigo");
  }

  private static void PrintPlayerName(int age, params string[] playerNameArray)
  {
    Console.WriteLine(playerNameArray.Length);
  }
}
```

# Values x Reference Types:

One works as a copy, the other as a reference.

Values types (contain tbeir data):
int, float, bool, enum, struct.
a variable points to one value, so if you assign this variable to another variable, you are making a copy.
Can´t be null.

```csharp
int a = 7;
int b = a;
b = 5;

Console.WriteLine(a); //7
```

Reference types (stores references to their data):
class, object, array, strings (sometimes strings can be values types).
Can have multiple variables pointing to the same reference type.
Can be null.

```csharp
MyClass myClass = new MyClass();
myClass.a = 7;
MyClass mySecondClass = myClass();
mySecondClass.a = 5;

Console.WriteLine(myClass.a); //5
```

# Extra Notes:

- A static method can be accessed without creating an object of the class, while public methods can only be accessed by objects.
