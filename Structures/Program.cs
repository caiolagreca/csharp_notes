using System;

namespace Structs
{
    //Similar to class, but value type
    //When you use something as a Class, like a Class Parameter, it is passed as a reference. While for structs it is passed as a copy (like int, float, bool, enum variables).
    //It can not be Inherited.
    //It is stored in the Stack, instead of the Heap (like it is for Classes).
    //Use it as an immutable piece o data
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyStruct myStruct = new MyStruct();
            myClass.a = 7;
            myStruct.a = 7;
            MyFunction(myClass, myStruct);

            Console.WriteLine(myClass.a + " " + myStruct.a);

        }

        private static void MyFunction(MyClass myClass, MyStruct myStruct)
        {
            myClass.a = 5;
            myStruct.a = 5;
        }

        private class MyClass
        {
            public int a;
        }

        private struct MyStruct
        {
            public int a;
        }

    }
}
