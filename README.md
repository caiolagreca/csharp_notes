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
Use quando o argumento deve ser inicializado antes de ser passado ao método.

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

2. Out:

Não precisa ser inicializado antes de passar para o método.
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
Simples e Sem Comportamento: DTOs contêm apenas propriedades e não possuem métodos ou lógica de negócios. (devem usar properties e nao fields).
Usados para Transferência de Dados: São usados principalmente para transportar dados entre camadas ou sistemas.
Desacoplamento: Ajudam a desacoplar as camadas do sistema, especialmente em aplicações distribuídas, como aquelas que usam APIs RESTful.
Serialização e Desserialização: Facilitam a serialização e desserialização de dados, o que é útil para comunicação entre sistemas diferentes, como entre um cliente e um servidor via JSON ou XML.
Podem ocultar propriedades que clientes nao devem visualizar.
Imutabilidade nao eh um requisito para DTOs.
Nao deve realizar encapsulamento e nao precisam de membros private/protected.

Devem ser modelados como DTOs:
API Request / Response Objects
MVC ViewModel objects
Database query result objects
Messages (Commands, Events, Queries)

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
Eh basicamente a assinatura de um metodo e sera gerada uma variavel para essa assinatura. Essa variavel, assoiada a uma assinatura de um metodo recebera algum metodo. Isso vai fazer com que esse metodo possa ser passado como uma variavel (passado atraves de parametros).

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

# Partial classes:

Permite que você divida a definição de uma classe, estrutura ou interface em vários arquivos. Todos os fragmentos devem ser combinados em uma única definição quando o programa é compilado.
Não podem haver membros duplicados (métodos, propriedades, etc.) nas partes de uma classe parcial.
Todas as partes da classe parcial devem ter os mesmos modificadores de acesso (public, private, etc.).
Todas as partes devem estar no mesmo namespace.

```csharp
//Arquivo 1: Parte1.cs
namespace MinhaApp
{
    public partial class MinhaClasse
    {
        public void Metodo1()
        {
            Console.WriteLine("Método 1");
        }
    }
}

//Arquivo 2: Parte2.cs
namespace MinhaApp
{
    public partial class MinhaClasse
    {
        public void Metodo2()
        {
            Console.WriteLine("Método 2");
        }
    }
}
```

# readonly:

const:

Um campo const é uma constante de tempo de compilação, o que significa que seu valor deve ser conhecido e definido no momento da compilação.
O valor de um const é fixo e não pode ser alterado. Além disso, ele é implícito como static, ou seja, pertence à classe e não à instância da classe.
Deve ser inicializado no momento da declaração e não pode ser modificado posteriormente.

readonly:

Um campo readonly é uma constante de tempo de execução, o que significa que seu valor pode ser definido em tempo de execução, mas somente no momento da inicialização do campo ou dentro do construtor da classe.
O valor de um campo readonly pode ser diferente para diferentes instâncias da classe, porque ele pode ser inicializado dentro de um construtor de instância.
Pode ser inicializado na declaração ou no construtor, mas não pode ser alterado depois de inicializado.

Quando Usar const e readonly:

Use const quando o valor da constante é conhecido em tempo de compilação e não vai mudar.
Use readonly quando o valor só pode ser determinado em tempo de execução, geralmente passado como argumento para o construtor.

<!-- OLHAR EXEMPLO NO FOLDER READONLY -->

# IEnumerabale e IEnumerator:

Faz com que classes personalizadas (que voce criou) possam utilizar o foreach. Tradicionalmente voce utiliza foreach em Lists, Arrays, mas nao em uma classe na qual voce criou.

- IEnumerable:
  é uma interface que define um único método GetEnumerator, que retorna um objeto de tipo IEnumerator.
  Serve para fornecer uma maneira de iterar sobre uma coleção de objetos. É a interface base para todas as coleções que podem ser enumeradas usando foreach.
  Método principal: IEnumerator GetEnumerator()

- IEnumerator:
  é uma interface que define os métodos necessários para percorrer uma coleção.
  Serve para iterar sobre a coleção, fornecendo a capacidade de acessar elementos na coleção um por um.
  Métodos principais:
  bool MoveNext(): Move para o próximo elemento na coleção.
  object Current { get; }: Obtém o elemento na posição atual.
  void Reset(): Redefine a enumeração para sua posição inicial.

- GetEnumerator:
  é um método definido pela interface IEnumerable.
  Ele retorna um enumerador (IEnumerator) que permite iterar sobre a coleção.
  Quando você usa foreach para iterar sobre uma coleção, o compilador C# chama implicitamente GetEnumerator para obter um enumerador que será usado para iterar sobre os elementos da coleção.

- MoveNext():
  é um método definido pela interface IEnumerator.
  Ele avança o enumerador para o próximo elemento na coleção. Retorna true se o enumerador foi avançado com sucesso, ou false se o enumerador já passou do final da coleção.
  Em um loop foreach, MoveNext é chamado repetidamente para avançar o enumerador através da coleção.

- Current:
  é uma propriedade definida pela interface IEnumerator.
  Ele retorna o elemento na posição atual do enumerador.
  Em um loop foreach, Current é chamado após cada chamada bem-sucedida de MoveNext para obter o elemento atual.

- Reset():
  é um método definido pela interface IEnumerator.
  Ele redefine o enumerador para sua posição inicial, que é antes do primeiro elemento na coleção.
  Na maioria dos cenários de uso de foreach, Reset não é chamado explicitamente. Ele é mais útil em cenários em que você precisa reutilizar o mesmo enumerador para iterar novamente sobre a coleção.

- Fluxo de Iteração com foreach:

  1. Início do foreach:
     O compilador chama GetEnumerator na coleção para obter um enumerador.
  2. Primeira Iteração:
     MoveNext é chamado para mover o enumerador para o primeiro elemento.
     Se MoveNext retornar true, Current é chamado para obter o primeiro elemento.
  3. Iterações Subsequentes:
     MoveNext é chamado repetidamente para mover o enumerador para os próximos elementos.
     Após cada chamada bem-sucedida de MoveNext, Current é chamado para obter o elemento atual.
  4. Fim da Iteração:
     Quando MoveNext retornar false, o loop foreach termina.

- Implementação: Crie uma classe que implementa IEnumerable e outra classe aninhada que implementa IEnumerator para fornecer a lógica de iteração.

<!-- OLHAR EXEMPLO NO FOLDER IENUMERABLE -->

# Iterator:

Um iterador é um método, propriedade ou bloco get que permite a iteração sobre uma coleção de maneira fácil, sem a necessidade de criar explicitamente uma classe enumeradora. O compilador gera essa classe enumeradora automaticamente para você.
O iterador usa a palavra-chave yield para produzir uma sequência de valores, um de cada vez, conforme necessário pela iteração.

- Vantagens:
  Eficiência de Memória: Gera elementos sob demanda, o que pode ser mais eficiente em termos de memória.
  Menos Código: Reduz a quantidade de código boilerplate necessário para criar um enumerador.
  Simplicidade: O código é mais fácil de ler e manter.

- Existem duas formas principais de usar yield:
  yield return: Retorna cada elemento da coleção um por um.
  yield break: Encerra a iteração.

```csharp
using System;
using System.Collections.Generic;

public class MinhaColecao
{
    private string[] itens = { "Item1", "Item2", "Item3" };

    public IEnumerator<string> GetEnumerator()
    {
        foreach (var item in itens)
        {
            yield return item;
        }
    }
}

class Program
{
    static void Main()
    {
        MinhaColecao colecao = new MinhaColecao();

        foreach (var item in colecao)
        {
            Console.WriteLine(item);
        }
    }
}
```

# Singleton Pattern:

Eh um padrão de design que garante uma única instância de uma classe com um ponto global de acesso.
Vantagens: Controle de instâncias, ponto de acesso global, economia de recursos.
Desvantagens: Dificuldade em testes, violação de SRP, estado global, dificuldade de extensão, problemas de concorrência (multi-thread) e desempenho.
Alternativas: Injeção de dependência e gerenciamento de escopo de vida.

- Estado global:
  Refere-se a dados ou variáveis que podem ser acessados e modificados por qualquer parte do código da aplicação. No contexto de um Singleton, isso significa que a instância única mantém estado (dados) que é acessível de qualquer lugar, potencialmente levando a problemas de concorrência e dificuldade de rastreamento de mudanças.

# Extensions Methods:

São métodos estáticos que permitem adicionar novos métodos a tipos existentes sem modificar o código original do tipo ou criar uma subclasse.
Proposito: adicionar funcionalidade adicional a metodos existentes sem modificar ou herdar o tipo.
Não modificam o tipo original; adicionam novos métodos de forma não intrusiva.
São definidos em classes estáticas e devem tambem ser estaticos e o primeiro parâmetro do método de extensão especifica o tipo que está sendo estendido, precedido pela palavra-chave this.
No exemplo abaixo TargetType é o tipo que você está estendendo e target eh o Metodo que esta sendo estendido.

```csharp
public static class Extensions
{
    public static ReturnType ExtensionMethodExample(this TargetType target)
    {
        // Implementação do método
    }
}
```

# Dependency Injections:

Permite que você injete as dependências de uma classe em vez de a própria classe criar essas dependências.

É integrada e configurada através do contêiner de serviços:
Um serviço é uma classe que oferece uma funcionalidade específica e bem definida, que pode ser usada por outras partes da aplicação.
Contêiner de Serviços, também conhecido como IoC (Inversion of Control) Container, é um componente que gerencia a criação, vida útil e resolução de dependências de serviços. Ele permite que você registre os serviços e suas dependências e depois injete esses serviços onde necessário.

É um padrão fundamental em ASP.NET Core que facilita o desenvolvimento de software modular, testável e de fácil manutenção. Ela desacopla as classes, promove a reutilização de código e centraliza a configuração dos serviços, tornando a aplicação mais flexível e robusta.

Tipos de DI:
Injeção de Construtor: Dependências são passadas através do construtor da classe.
Injeção de Propriedade: Dependências são configuradas através de propriedades públicas.
Injeção de Método: Dependências são passadas diretamente para métodos específicos.

Existem três tipos principais de ciclos de vida das dependências:

1. Transient:
   Uma nova instância do serviço é criada cada vez que ele é solicitado.
   Uso: Serviços leves e sem estado, que não mantêm dados entre solicitações.

```csharp
builder.Services.AddTransient<IService, ServiceImplementation>();
```

2. Scoped:
   Uma única instância do serviço é criada por escopo de solicitação. Ou seja, a mesma instância é usada em toda a duração de uma única solicitação HTTP.
   Uso: Serviços que mantêm estado durante a duração de uma solicitação HTTP.

```csharp
builder.Services.AddScoped<IService, ServiceImplementation>();
```

3. Singleton:
   Uma única instância do serviço é criada e compartilhada por toda a aplicação.
   Uso: Serviços pesados ou com estado que precisam ser compartilhados por toda a aplicação.

```csharp
builder.Services.AddSingleton<IService, ServiceImplementation>();
```

# Como JWT Tokens funcionam:

1. O cliente solicita acesso a aplicacao usando suas credenciais (geralmente username e password).
2. O servidor verifica se as credenciais do cliente sao válidas; caso seja, o servidor envia ao cliente um Token que serve para permitir acesso a endpoints que so podem ser acessados com a devida autenticacao e autorizacao.
3. Agora, o cliente ja acessou a aplicacao com suas credenciais e obteve o Token atraves do servidor. Assim, o cliente irá acessar o endpoint que deseja (seja pelo metodo GET, POST, PUT, DELETE...)
4. Porém, algum desses endpoints são restritos. Exemplo: so pode ser acessado após efetuar o login, ou mesmo após login só pode ser acessado por usuarios com privilegios (como deletar contas de usuarios que somente admin users podem realizar).
5. Entao, para ter acesso e obter a resposta desses endpoints restritos, o cliente realiza uma requisicao HTTP/HTTPS do endpoint desejado e juntamente envia o Token obtido atraves do cabeçalho na requisicao.
6. O servidor verifica se o Token eh valido e se ainda nao foi expirado, e caso seja, retorna a resposta da requisicao para o cliente, finalizando com sucesso a requisicao solicitada pelo cliente.

# O que sao Claims:

Uma claim (ou "declaração") é uma afirmação sobre um usuário que pode ser usada para autenticação e autorização. As claims são pares chave-valor que descrevem atributos específicos de um usuário, como nome, email, role, e outras propriedades. Elas são usadas em sistemas de autenticação para fornecer informações sobre o usuário e determinar seus direitos de acesso.
Elas são incluídas em tokens de autenticação (como JWT) e são verificadas pelo servidor para determinar se um usuário tem permissão para acessar determinados recursos.

Componentes de uma Claim:
Type (Tipo): Define o tipo de informação que a claim representa (por exemplo, "name", "email", "role").
Value (Valor): O valor associado ao tipo de claim (por exemplo, "player1", "player1@example.com", "admin").

Tipos Comuns de Claims:
Name: O nome do usuário.
Role: A função ou papel do usuário (por exemplo, "admin", "user").
Email: O endereço de email do usuário.
Subscription: O nível de assinatura do usuário (por exemplo, "silver", "gold").

Exemplo Prático
Login e Geração de Token:
O usuário faz login e, se autenticado, o servidor gera um token JWT que inclui claims sobre o usuário.
Requisição Autenticada:
O cliente envia o token JWT em cada requisição. O servidor valida o token e usa as claims contidas nele para determinar se o usuário tem permissão para acessar o recurso solicitado.

ClaimsIdentity: é uma coleção de Claims .
Por exemplo, pegue sua carteira de motorista. Ela tem claims como FirstName, LastName, DateOfBirth. Portanto, a carteira de motorista é ClaimsIdentity.

ClaimsPrincipal: contém uma coleção de ClaimsIdentity . Você pode pensar no ClaimsPrincipal como o usuário do seu aplicativo.
Um Usuário pode ter mais de uma ClaimsIdentity. Por exemplo, carteira de motorista e passaporte.
Uma carteira de motorista é uma ClaimsIdentity com afirmações como FirstName, LastName, DateOfBirth, etc. Passaporte é outra ClaimsIdentity com afirmações como FirstName, LastName, Address, PassportNo, etc.

# O que é Razor Pages:

Razor Pages é um recurso do ASP.NET Core projetado para simplificar a construção de aplicações web. Cada página Razor é autossuficiente, combinando a lógica de UI e a apresentação em uma estrutura organizada. As principais vantagens incluem simplicidade, melhor organização do código e desempenho aprimorado em cenários simples. É ideal para aplicações simples a moderadas, prototipagem rápida e CRUDs. Contudo, pode ser menos adequado para aplicações altamente complexas devido à sua estrutura mais direta e menos flexível em comparação com MVC.

Exemplo de Estrutura de Razor Page:
Arquivo .cshtml: Contém o HTML e a lógica de apresentação.

```csharp
@page
@model IndexModel

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Index Page</title>
</head>
<body>
    <h1>Hello, @Model.Message!</h1>
</body>
</html>
```

Arquivo PageModel: Contém a lógica de manipulação de dados e interações.

```csharp
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string Message { get; private set; }

    public void OnGet()
    {
        Message = "Welcome to Razor Pages!";
    }
}
```

# O que é gRPC:

gRPC é um framework de comunicação de alta performance e plataforma cruzada que permite chamadas de procedimento remoto (Remote Procedure Call - RPC). Ele usa o protocolo HTTP/2 para transporte, Protocol Buffers como linguagem de descrição de interface (IDL) e pode ser utilizado em diversas linguagens de programação.

Vantagens
Desempenho: Utiliza HTTP/2, que oferece multiplexação de streams e compressão de cabeçalhos, resultando em comunicação eficiente e rápida.
Plataforma Cruzada: Suporta diversas linguagens de programação e pode ser utilizado em múltiplos ambientes.
Contract-First: Usa Protocol Buffers para definir contratos de serviço, garantindo a consistência entre cliente e servidor.
Comunicação Bidirecional: Suporta streaming bidirecional, permitindo comunicação eficiente e em tempo real.

Desvantagens
Complexidade: Mais complexo de configurar e gerenciar em comparação a REST APIs simples.
Ferramentas de Debugging: Menos ferramentas de debugging e monitoramento disponíveis comparadas a REST APIs.
Compatibilidade: Requer suporte a HTTP/2, o que pode ser um problema em ambientes mais antigos.

Quando Usar
Comunicação de Alta Performance: Ideal para aplicações que exigem baixa latência e alta taxa de transferência.
Microserviços: Adequado para comunicação eficiente entre microserviços.
Streaming de Dados: Perfeito para casos de uso que requerem streaming de dados bidirecional.

# O Que é Kestrel em ASP.NET Core:

Kestrel é um servidor web leve e de alta performance incorporado ao ASP.NET Core. Ele é utilizado para hospedar aplicações ASP.NET Core e serve como o servidor web padrão na maioria das configurações de desenvolvimento e produção.

1. Características Principais
   Desempenho Elevado: Projetado para ser rápido e eficiente, utilizando recursos mínimos do sistema.
   Compatibilidade com HTTP/1.1, HTTP/2 e HTTPS: Suporta os protocolos HTTP/1.1 e HTTP/2, além de conexões seguras via HTTPS.
   Cross-Platform: Funciona em Windows, macOS e Linux, oferecendo flexibilidade de implantação.
   Integração com Reverse Proxies: Pode ser usado em conjunto com servidores reverse proxy como IIS, Nginx ou Apache para aumentar a segurança, escalabilidade e estabilidade.

2. Quando Usar
   Desenvolvimento: Kestrel é ideal para o desenvolvimento local devido à sua simplicidade e facilidade de configuração.
   Produção: Pode ser usado diretamente em produção ou atrás de um reverse proxy para fornecer funcionalidades adicionais de segurança e balanceamento de carga.

3. Usando servidor Kestrel por tras de outro servidor web:
   Kestrel nao é um servidor web com todos os recursos. Mas é isso que o torna rápido.
   Não é aconselhável executar o Kestrel como um servidor web autônomo no ambiente de produção. É recomendável executá-lo por trás de um servidor Web com todos os recursos, como IIS, Nginx, Apache, etc. Em tal cenário, o servidor Web atua como um servidor proxy reverso.
   O servidor proxy reverso recebe a solicitação HTTP da Internet e a passa para o servidor Kestrel exatamente como foi recebido.
   O IIS pode receber a solicitação HTTP e executar processamento útil como registro, filtragem, e Reescritas de URL antes de passar a solicitação para o Kestrel.
   Existem muitas razões pelas quais você deve usar este modelo na produção:
   Segurança - Ele pode limitar sua área de superfície exposta. Ele fornece uma camada adicional opcional de configuração e defesa.
   Simplifica o balanceamento de carga.
   Configuração SSL - Somente seu servidor proxy reverso requer um certificado SSL, e esse servidor pode se comunicar com seus servidores de aplicativos na rede interna usando HTTP simples.
   Compartilhando um único IP com vários endereços.
   Solicitar filtragem, registro e reescrita de URL, etc.
   Ele pode garantir que o aplicativo reinicie se ele travar.

   4. Recursos Ausentes em Kestrel
      Gerenciamento Avançado de Conexões: Kestrel não oferece funcionalidades avançadas de gerenciamento de conexões, como limitar o número de conexões simultâneas ou gerenciar filas de conexões de forma eficiente.
      Segurança Avançada: Embora suporte SSL/TLS, Kestrel não tem recursos avançados de segurança, como filtragem de IP, proteção contra ataques DDoS, ou inspeção profunda de pacotes.
      Balanceamento de Carga: Kestrel não inclui balanceamento de carga integrado. Em ambientes de produção, é comum usá-lo atrás de um balanceador de carga, como Nginx ou Azure Load Balancer.
      Logging e Monitoramento Avançados: Ele não fornece ferramentas avançadas de logging e monitoramento que alguns servidores web completos oferecem.
      Configuração Simplificada: Kestrel é altamente configurável, mas não oferece a mesma facilidade de configuração para aspectos complexos de um servidor web completo.

      Devido a essas limitações, Kestrel é frequentemente usado em produção atrás de um reverse proxy ou balanceador de carga, como Nginx, Apache, ou IIS. Isso permite combinar a alta performance de Kestrel com os recursos avançados de um servidor web completo, garantindo uma solução robusta e escalável.

O metodo WebApplication.CreateBuilder registra e configura o servidor HTTP Kestrel. E quando executamos o comando app.Run ele começa a escutar requisições HTTP.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

# O Que é um Reverse Proxy:

Um reverse proxy é um servidor que fica entre os clientes e os servidores de backend, encaminhando as solicitações dos clientes para os servidores apropriados e retornando as respostas para os clientes. Ele não é exatamente um balanceador de carga, mas pode desempenhar essa função junto com outras funcionalidades.

Funcionalidades do Reverse Proxy
Balanceamento de Carga: Distribui as solicitações de entrada entre vários servidores para otimizar o desempenho e evitar sobrecarga em um único servidor.
Segurança: Adiciona uma camada de segurança ao ocultar os detalhes dos servidores backend e podendo aplicar políticas de segurança.
Cache: Armazena em cache as respostas dos servidores backend para acelerar as respostas a solicitações subsequentes.
SSL Termination: Descriptografa solicitações SSL/TLS, aliviando a carga dos servidores backend.
Autenticação e Autorização: Pode ser configurado para autenticar e autorizar solicitações antes de encaminhá-las aos servidores backend.

Exemplos de Reverse Proxy
Nginx: Muito utilizado por sua performance e flexibilidade.
Apache: Pode ser configurado como reverse proxy com módulos apropriados.
IIS: No ambiente Windows, pode atuar como reverse proxy.
HAProxy: Especializado em balanceamento de carga, também pode atuar como reverse proxy.

# CLI:

Dotnet cli é uma ferramenta de linha de comando. Ele contém comandos que você pode usar para:
Criar um novo projeto
Construir um projeto
Executar o projeto
Publicar o projeto
Restaurar pacotes Nuget
Migrar de uma versão para outra do .NET

A sintaxe do NET CLI consiste em três partes. O “driver”, o “verbo” e os “argumentos”
dotnet [verbo] [argumentos]
O driver é “dotnet”. Ele pode executar um comando ou executar um aplicativo.
O “verbo” é o comando que você quer executar. Ele realiza uma ação.
Os “argumentos” são argumentos que passamos para os comandos invocados.

Aqui estão alguns dos comandos dotnet CLI mais comuns:
new - Cria um novo projeto, arquivo de configuração ou solução com base no modelo especificado.
restore - Restaura as dependências e ferramentas de um projeto.
build - Cria um projeto e todas as suas dependências.
publish - Empacota o aplicativo e suas dependências em uma pasta para implantação em um sistema de hospedagem.
run Executa código-fonte sem nenhum comando explícito de compilação ou inicialização.
test - Driver de teste .NET usado para executar testes unitários.
vstest - Executa testes dos arquivos especificados.
pack - Empacota o código em um pacote NuGet.
migrate - Migra um projeto .NET Core do Preview 2 para um projeto .NET Core SDK 1.0.
clean - Limpa a saída de um projeto.
sln - Modifica um arquivo de solução do .NET Core.
help - Mostra documentação mais detalhada on-line para o comando especificado.
store - Armazena os assemblies especificados no armazenamento de pacotes de tempo de execução.

Lista de Templates para criacao de projeto:
console - Console Application
classlib - Class library
mstest - Unit Test Project
xunit - xUnit Test Project
web - ASP.NET Core Empty
mvc - ASP.NET Core Web App (Model-View-Controller)
razor - ASP.NET Core Web App
angular - ASP.NET Core with Angular
react - ASP.NET Core with React.js
reactredux - ASP.NET Core with React.js and Redux
webapi - ASP.NET Core Web API

# Arquivo lauchnSettings.json

Este arquivo json contém todas as configurações específicas do projeto necessárias para iniciar o aplicativo. Você encontrará o perfil de depuração, as variáveis ​​de ambiente que devem ser usadas, etc.
Ele é usado somente durante o desenvolvimento do aplicativo.
Ele contém somente as configurações necessárias para executar o aplicativo.
Este arquivo é ignorado quando publicamos o aplicativo.
Você encontrará o launchSettings.json na pasta properties.

2. O arquivo tem duas seções. Uma é iisSettings e a outra é a seção profiles.
   iisSettings: contém as configurações necessárias para depurar o aplicativo no IIS (Internet Information Service) ou IIS Express.
   profiles: A seção contém os perfis de depuração. O Visual Studio cria esses perfis quando cria o projeto.

Exemplo:

```csharp
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:38034",
      "sslPort": 44314
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5117",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7120;http://localhost:5117",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

# Dependencies Folder

Esta pasta contém todas as dependências do projeto.
O Visual Studio usa NuGet para todas as dependências do lado do servidor.
Para as dependências do lado do cliente, o Libman é usado. Este é um desvio das versões anteriores onde NuGet é usado para dependências do lado do servidor e do lado do cliente.

1. Na pasta Dependências, temos as pastas Packages , Frameworks e Analyzers.

   - A pasta Packages conterá os pacotes do lado do servidor que você instalar. Esta pasta é criada somente quando você instala um novo pacote.

   - A pasta Frameworks contém o framework. Ela mostra dois pacotes Microsoft.AspNetCore.App e Microsoft.NetCore.App.
     O Microsoft.NETCore.app é o coração do .NET. Ela contém os recursos comuns necessários para construir um aplicativo .NET (Windows, web, blazer etc).
     O Microsoft.AspNetCore.app contém os recursos relacionados apenas ao ASP.NET Core.

   - A pasta Analyzers inclui pacotes que ajudam o Visual Studio a analisar o código. Por exemplo, mensagens de erro e avisos que aparecem enquanto você digita, junto com correções automáticas de código, etc.

O arquivo libman.json é criado quando instalamos os pacotes de terceiros usando o libman.

# program.cs file

A classe Program contém o ponto de entrada dos aplicativos ASP.NET Core.
Não há método main neste arquivo, ele é implícito.
Todas as tarefas que foram feitas na classe startup, agora são movidas para cá a partir da versão .NET 6.0.
Ela contém o código de inicialização do aplicativo.
Configura e registra os serviços necessários para o aplicativo.
Registra componentes de middleware e configura o pipeline de tratamento de solicitações do aplicativo.

1. ASP.NET Core apps configuram e iniciam um arquivo host:
   Você pode pensar em um host como um wrapper em torno do seu aplicativo. Ele é responsável pela inicialização e gerenciamento do tempo de vida do aplicativo. O host contém a configuração do aplicativo e o servidor Kestrel (servidor HTTP) que escuta solicitações e envia respostas. Ele também configura o registro, injeção de dependência, configuração, pipeline de processamento de solicitação, etc.
   Há três hosts diferentes capazes de executar um ASP.NET Core app:
   WebHost - foi usado nas versões iniciais do ASP.NET Core
   Generic Host - substituiu o WebHost no ASP.NET Core 3.0
   WebApplication (or Minimal Host) - foi introduzido no ASP.NET Core 6.0

2. O WebApplication é o núcleo do seu aplicativo ASP.NET Core. Ele contém a configuração do aplicativo e o servidor HTTP (Kestrel) que escuta solicitações e envia respostas.
   O WebApplication se comporta de forma semelhante ao Generic Host, expondo muitas das mesmas interfaces, mas exigindo menos retornos de chamada de configuração.
   Precisamos configurar o WebApplication antes de executá-lo. Há duas tarefas essenciais que precisamos executar antes de executar o aplicativo:
   Configurar e adicionar os serviços para injeção de dependência .
   Configurar o pipeline de solicitações , que manipula todas as solicitações feitas ao aplicativo.

Essas quatro linhas contêm todo o código de inicialização necessário para criar um servidor web e começar a escutar solicitações:
O program.cs file cria a aplicacao web em 3 estagios - Create, Build and Run.
As versões anteriores do ASP.NET Core criavam dois arquivos. Um é program.cs, e o outro é startup.cs (conhecido como classe startup). O program.cs é onde configuramos o host, e a classe startup é onde usamos para configurar o aplicativo. Desde o ASP.NET core 6, ambos os processos são simplificados e mesclados em um program.cs.

```csharp
/* CREATE (cria uma instancia do WebApplication).
CreateBuilder eh um metodo estatico da classe WebApplcation e retorna uma nova isntancia da classe WebApplicationBuilder.
Ele configura alguns recursos básicos da plataforma ASP.NET por padrão, incluindo: Configuracao do servidor HTTP (Kestrel), Logging, Configuracao, adiciona servicos ao Contêiner de injeção de dependência, Adiciona os framework-provided services. */
var builder = WebApplication.CreateBuilder(args);

/* BUILD
O método Build da classe WebApplicationBuilder cria uma nova instância da classe WebApplication .
Usamos a instância do WebApplication para configurar os middlewares e endpoints. */
var app = builder.Build();
app.MapGet("/", () => "Hello World!"); //Insere Middlewares e endpoints aqui

/* RUN
O método Run da instância WebApplication inicia o aplicativo e escuta solicitações HTTP. */
app.Run();

```

# appsettings.json

é uma das várias maneiras pelas quais podemos fornecer os valores de configuração para o aplicativo ASP.NET core.
Você encontrará esse arquivo na pasta raiz do nosso projeto.
Também podemos criar arquivos específicos do ambiente como appsettings.development.json, appsettngs.production.json, etc.
O sistema de configuração do ASP.NET Core carrega o appsettings.json e também o arquivo específico do ambiente appsettings com base no ambiente atual.
O appsettings armazena os valores de configuração em pares nome-valor usando o formato JSON.

Exemplo:

```csharp
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

O núcleo do ASP.NET lê o valor da variável ASPNETCORE_ENVIRONMENT contida no launchSettings.json, para determinar o ambiente atual.
O método na classe program.cs lê o valor da variavel ASPNETCORE_ENVIRONMENT bem no início do aplicativo. Ele então cria o IWebHostEnvironment object, que podemos usar para ler o ambiente atual em qualquer lugar do aplicativo.

1. O núcleo do ASP.NET usa o provedor de configuração JSON para ler as configurações. Ele as lê na seguinte ordem:
   appsettings.json
   appsettings.<EnvironmentName>.json :
   Por exemplo, se o ambiente atual for Desenvolvimento, então o appsettings.development.json é carregado. Se o ambiente for Produção, então ele usa oappsettings.production.json
   Portanto, podemos carregar diferentes configurações com base no ambiente ou aplicativo em execução.

# Request Pipeline e Middlewares:

O Request Pipeline é o mecanismo pelo qual as requests são processadas começando com uma Request e terminando com uma Response.
O pipeline especifica como o aplicativo deve responder ao HTTP request.
A solicitação que chega do navegador passa pelo pipeline e volta.
Os componentes individuais que compõem o pipeline são chamados de Middleware.

1. Middlewares:
   é um componente de software que se conecta ao pipeline de requests para lidar com solicitações da web e gerar respostas.
   Cada middleware processa e manipula a request conforme ela é recebida do middleware anterior.
   Ele pode decidir chamar o próximo middleware no pipeline ou enviar a resposta de volta para o middleware anterior (encerrando o pipeline).

2. Como funcionam os middlewares:
   Primeiro, a solicitação HTTP chega (diretamente ou por meio de um servidor web externo) ao aplicativo.
   O servidor Web Kestrel pega a solicitação e cria o httpContext e passa para o Primeiro Middleware no Request pipeline.
   O Primeiro Middleware então assume, processa a solicitação e a passa para o próximo Middleware. Isso continua até chegar ao último middleware.
   O último middleware retorna a solicitação ao middleware anterior, encerrando efetivamente o pipeline de solicitação.
   Cada middleware na sequência tem uma segunda chance de inspecionar a solicitação e modificar a resposta no caminho de volta.
   Finalmente, a resposta chega ao Kestrel, que retorna a resposta ao cliente.
   Qualquer um dos middlewares no pipeline de request pode encerrar o pipeline simplesmente não passando a solicitação para o próximo middleware.
   As solicitacoes sao passadas de um Middleware para outro atraves do metodo "next.Invoke()"

# Static File:

Os StaticFile são aqueles arquivos cujo conteúdo não muda dinamicamente quando o usuário os solicita. Portanto, não faz sentido que a solicitação passe por todo o caminho até o MVC Middleware, apenas para servir esses arquivos. O ASP.NET Core fornece um Middleware integrado apenas para essa tarefa.
Para fornecer um arquivo estático, precisamos adicionar o Middleware de Arquivos Estáticos. Este Middleware está disponível no assembly Microsoft.AspNetCore.StaticFiles. Não precisamos instalar este conjunto, pois ele faz parte do Microsoft.AspNetCore.All Metapackage.
Podemos configurar o ASP.NET Core para servir arquivo estático usando o método UseStaticFiles.

Os arquivos estáticos são um Terminating Middleware. Se o File for encontrado, ele retornará o arquivo e encerrará o request pipeline.
Ele chamará o próximo middleware, somente se não conseguir encontrar o recurso solicitado.

1. wwwroot:
   é o diretório dentro da raiz de conteúdo de onde os recursos estáticos, como CSS, JavaScript e arquivos de imagem, são armazenados.

2. Seguranca:
   O middleware de arquivo estático não verifica se o usuário está autorizado a visualizar o arquivo.
   Se você deseja que apenas o usuário autorizado acesse o arquivo, você deve armazená-lo fora da pasta wwwroot. Você pode então fornecer o arquivo usando controller action e retornando um FileResult.

# Value Type x Reference Type:

1. Tipos de valor:
   Definição: Armazenam dados diretamente.
   Armazenamento: A variável contém a própria cópia dos dados.
   Local de Armazenamento: Normalmente na stack.
   Cópia: Ao atribuir a outra variável, cria uma cópia dos dados.
   Exemplos: int, float, double, char, struct.

2. Tipos de Referência:
   Definição: Armazenam uma referência (endereço) para os dados.
   Armazenamento: A variável contém um ponteiro para os dados que estão na heap.
   Local de Armazenamento: Normalmente na heap (os dados) e a referência na stack.
   Cópia: Ao atribuir a outra variável, copia a referência, não os dados.
   Exemplos: object, string, array, class.

A principal diferença é como os dados são armazenados e copiados. Tipos de valor armazenam diretamente os dados e copiam os dados ao serem atribuídos a outra variável, enquanto tipos de referência armazenam uma referência para os dados e copiam a referência ao serem atribuídos a outra variável.

# Stack x Heap:

1. Stack
   Armazenamento: Utilizado para armazenar variáveis locais e chamadas de funções/métodos.
   Acesso: Segue a estrutura LIFO (Last In, First Out).
   Velocidade: Acesso rápido devido à sua natureza linear e previsível.
   Gerenciamento: Gerenciado automaticamente pelo compilador, liberando memória ao final do escopo da função.
   Tamanho: Geralmente limitado e menor em comparação à heap.

2. Heap
   Armazenamento: Utilizado para armazenar objetos e dados que precisam de alocação dinâmica.
   Acesso: Acesso indireto por meio de referências/pointers.
   Velocidade: Acesso mais lento devido à alocação/desalocação dinâmica e fragmentação de memória.
   Gerenciamento: Gerenciado pelo coletor de lixo (garbage collector), que desaloca memória quando não é mais referenciada.
   Tamanho: Geralmente maior e mais flexível que a stack.

3. Conclusao
   Stack: Ideal para dados de curta duração e alocação rápida, com acesso direto e previsível.
   Heap: Adequado para dados que precisam de maior tempo de vida e alocação dinâmica, com gerenciamento de memória mais complexo e flexível.

4. Alocacao dinâmica:
   Refere-se à prática de alocar memória durante a execução do programa, ao invés de durante a compilação. Isso permite que um programa utilize memória de forma mais flexível, adaptando-se às necessidades em tempo de execução.
   A memória é alocada na heap, e a alocação é gerenciada pelo programador ou pelo sistema de gerenciamento de memória (como o garbage collector).

# MVC Architecture:

é um padrão de camada de Apresentação. Ele lida apenas com como e quando os dados são apresentados ao Usuário. Você precisa usar esse padrão junto com a camada de acesso a dados e a camada de negócios para criar um aplicativo web Completo.

1.  Model:
    O modelo representa os dados que precisam ser mostrados ao usuário e alguma lógica associada.
    O Model não depende e não deve depender do Controller ou View.
    A única responsabilidade do Model é manter os dados.
    A classe do Model é reutilizável.

2.  View:
    A view é uma representação visual do Model.
    É responsabilidade da View pegar o Model do Controller, renderizá-lo e apresentá-lo ao usuário.
    A view é conectada a um Model, acessa seus dados e os mostra ao usuário. Ela pode atualizar o Model e enviá-lo de volta ao Controller para atualização do banco de dados.
    A view nunca acessará a camada de negócios ou a camada de dados.

    - A View tem as seguintes responsabilidades:
      Responsável por interagir com o Usuário
      Renderizar o Model para o usuário
      Aceita a interação do usuário e passa ao Controller
      Consiste em páginas HTML padrão / Javascript e CSS
      Deve ser capaz de renderizar JSON, XML e tipos de retorno personalizados

3.  Controller:
    O Controller recebe a solicitação. Ele então constrói o Model e seleciona a View para exibi-lo. Ele fica entre a View e o Model. Você pode pensar nele como uma cola que une o Model à View.
    Ele controla o fluxo de atividade.
    O Controller não deve se tornar um depósito para seu código. Ele deve sempre delegar o trabalho para a camada de serviço (por exemplo, a camada de dados para obter os dados, a camada de negócios para executar a lógica de negócios, etc.) para construir e obter o Model. O Model então, deve ser injetado na View para renderizar a View.

            - O Controller tem as seguintes responsabilidades:
              Processa requests recebidas do usuário.
              O Controller então passa a request para a camada de serviço apropriada para obter o Model.
              Passa o Model para View para renderização.
              Passa as validações e erros de volta para a View, se houver.
              O Controller nunca acessa a camada de dados.
              O Controller atua tanto no Model quanto na View. Ele controla o fluxo de dados para o objeto do Model e atualiza a View sempre que os dados mudam. Ele mantém a View e o Model separados.

            - A Class Controller deve satisfazer ao menos uma das condicoes:
              O nome da classe é sufixado com “Controller”.
              A classe herda de uma classe cujo nome é sufixado com “Controller”.
              A classe é decorada com o atributo [Controller].

            - Action Methods:
              Qualquer método público exposto por um controlador é chamado de Action Method.
              O método Action é chamado quando um usuário digita uma URL específica no navegador.
              Os métodos de ação devem chamar a camada de serviço para responder à request. A camada de serviço geralmente deve consultar ou atualizar o banco de dados usando a camada de acesso a dados e, em seguida, mapear os resultados em um modelo e passá-lo de volta para o método de ação.
              O método Action então invoca a View com o modelo para gerar a resposta.
              A resposta pode ser uma página HTML, Json, XML ou um arquivo para baixar.

              Qualquer método público em uma classe Controller pode ser invocado por qualquer pessoa localizada em qualquer lugar do mundo. Então, tenha cuidado ao colocar um método público no controlador.

              Ao criar um Action Method, você deve se lembrar do seguinte:
              Método de ação deve ser um método público.
              O método Action não pode ser um método estático ou um método de extensão.
              O Constructor, getter ou setter não podem ser usados.
              Métodos herdados não podem ser usados ​​como método Action.
              Métodos de ação Não podem conter parâmetros ref ou out.
              Os métodos de ação não podem conter o atributo [NonAction].
              Os métodos de ação não podem ser overloaded.

              Geralmente, um action Controller deve retornar algo chamado Action Result. Cada tipo de retorno, como HTML, Json ou string, tem seu próprio Action Result, que herda da classe base ActionResult.
              A classe base ActionResult é uma classe abstrata.

              Por exemplo, para gerar resposta HTML, usamos ViewResult .
              Para gerar resultado de string ou texto, usamos ContentResult.
              Tanto ViewResult quanto ContentResult herdam de ActionResult.
              O ASP.NET Core MVC possui suporte integrado para vários tipos de Action results:
                ViewResult – Representa HTML e marcação.
                EmptyResult – Não representa nenhum resultado.
                RedirectResult – Representa um redirecionamento para uma nova URL.
                JsonResult – Representa um resultado de Notação de Objeto JavaScript que pode ser usado em um aplicativo AJAX.
                JavaScriptResult – Representa um script JavaScript.
                ContentResult – Representa um resultado de texto.
                FileContentResult – Representa um arquivo para download (com o conteúdo binário).
                FilePathResult – Representa um arquivo para download (com um caminho).
                FileStreamResult – Representa um arquivo para download (com um fluxo de arquivos).

4.  Endpoint Routing:

        - Possui 3 componentes:
          Definindo os Endpoints.
          Correspondência de rotas e construção de um ponto final ( UseRouting).
          Execução de ponto final ( UseEndpoints). - Atualmente nao usamos mais UseEndpoints e ja chamamos direto o MapControllerRoute no Program.cs por exemplo.

        - UseRouting:
          Quando o app inicia, UseRouting registra o Route Matching Middleware "EndPointRoutingMiddleware".
          O EndPointRoutingMiddleware resolve as requests HTTP recebidas e constrói um Endpoint e atualiza o context.
          O Middleware em execução depois do UseRouting pode acessar o endpoint do HTTP Context e tomar medidas. Por exemplo, um middleware de autorização pode consultar os metadados do endpoint e aplicar a política de autorização correta com base nessas informações.
          Middlewares executados antes da chamada do metodo UseRouting nao podem acessar os Endpoints.
          Sua finalidade é:
            Analisar a URL de entrada.
            Resolver a URL e construir o Endpoint.
            Atualizar o objeto HTTP Context com o Endpoint usando o método SetEndpoint.
          Os objetos Endpoint são imutáveis ​​e não podem ser modificados após a criação.

```csharp
var builder = WebApplication.CreateBuilder(args);
// Adicionar serviços MVC ao contêiner
builder.Services.AddControllersWithViews();
var app = builder.Build();
// Configurar o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

Eh necessario configurar o Endpoint para cada Action Method do Controller. Ha 2 maneiras para isso:

- Convention-based routing:
  é normalmente usado com os Controllers e Views. Ele cria rotas com base em uma série de convenções.

  MapControllerRoute é um método de extensão no EndpointRouteBuilder e aceita os seguintes argumentos:
  name: O nome da rota
  pattern: O padrão de URL da rota
  defaults: Um objeto que contém valores padrão para parâmetros de rota. As propriedades do objeto representam os nomes e valores dos default values.
  constraints: Um objeto que contém restrições para a rota. As propriedades do objeto representam os nomes e valores das restrições.
  dataTokens: Um objeto que contém tokens de dados para a rota. As propriedades do objeto representam os nomes e valores dos tokens de dados.

  O MapControllerRoute cria uma única rota, que é nomeada como default e o Padrão de URL da rota é {controller=Home}/{action=Index}/{id?}
  Cada rota deve conter um URL Pattern. Este Pattern é comparado a uma URL de entrada. Se o pattern corresponder à URL, então ele é usado pelo sistema de roteamento para processar essa URL.
  Cada URL Pattern consiste em um ou mais Segments. A barra delimita um Segment de outro segmento.
  Cada segmento pode ser um Constant(literal) ou Route Parameter.
  O Route Parameters são colocados entre chaves {controller}, por exemplo {action}.
  O Route Parameters pode ter valor padrão como {controller=Home}, onde Home é o valor padrão para o controlador. Um = sinal de igual seguido por um valor após o Route Parameter define um valor padrão para o parâmetro.
  Você também pode ter os Constant. Ex: admin/{controller=Home}/{action=Index}/{id?}. Aqui admin eh um Constant e deve estar presente na URL solicitada.
  O ? em {id ?} indica que é opcional. Um ponto de interrogação ? após o nome do parâmetro de rota define o parâmetro como opcional.

```csharp
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");
```

Outra maneira eh usar default arguments:

```csharp
app.MapControllerRoute(
  name: "default",
  pattern: "{controller}/{action}",
  defaults: new { controller=home, action = "Index" });
```

- Attribute routing:
  usa os atributos definidos diretamente na ação do Controller para definir as rotas. O Attribute routing dá a você mais controle sobre as URLs em seu aplicativo web.
  Para configurar um Routing baseado em atributo, use o método MapControllers.

  ```csharp
  endpoints.MapControllers();
  ```

MapControllerRoute e MapControllers escondem todas as complexidades de configuração do Endpoint de nós. Ambos configuram o Endpoint para os Controllers Action Methods.

Você também pode criar um Endpoint para um delegate personalizado usando o metodo MapGet.
MapGet aceita dois argumentos. Um é Route Pattern ( "/" no exemplo) e o outro um request delegate que será executado quando o Endpoint for correspondido.

```csharp
endpoints.MapGet("/", async context =>
   {
      await context.Response.WriteAsync("Hello World");
   });
```

5.  Como funciona MVC no ASP .NET Core:
    =(Request)=>[CONTROLLER]=(Builds)=>[MODEL]=(Renders)=>[VIEW]=(HTML)=>

    A Request começa quando o usuário clica em um botão, em um link ou digita a URL no navegador.
    A Request chega ao Middleware MVC após passar pelo Request Pipeline.
    O MVC Middleware inspeciona a URL e decide qual Controller invocar. O processo de mapeamento da request para o Controller é chamado Routing.
    O MVC Middleware invoca o Controller e passa a request do usuário.
    O Controller agora olha para a request do usuário e decide o que fazer com ela. A request pode ser para inserir um novo cliente ou obter uma lista de clientes (exemplo). O Controller constrói o Model apropriado. Ele chamará a camada de serviço para concluir sua tarefa.
    O Controller passa o Model para a View apropriada e passa o controle para a View para construir a resposta.
    A View gerará a resposta apropriada. A resposta pode ser um HTML, XML, Json ou um arquivo para download. Em seguida, ela o envia de volta ao usuário.
    O ciclo da request é concluído e o aplicativo aguarda nova interação do usuário, o que iniciará um novo ciclo.

# Extra Notes:

- A static method can be accessed without creating an object of the class, while public methods can only be accessed by objects.

- Thread-Safe: Capacidade de um método ou classe de ser usado simultaneamente por múltiplas threads sem causar corrupção de dados ou resultados imprevisíveis.
  Classe Random: Não é thread-safe, o que significa que o uso simultâneo por múltiplas threads pode levar a problemas de concorrência.
  Soluções: Usar bloqueios (lock) ou ThreadLocal<Random> para garantir segurança em contextos multi-thread.
