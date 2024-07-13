using System;

namespace Stack
{
    class Program
    //Take a look at README to see the Built in Delegates in csharp
    {
        private delegate void AttackDelegate();
        private delegate int MyDelegate(string str);

        private static AttackDelegate attackAction;

        private static Action myAction; //Built in Delegate in csharp; Action has a void type return;
        private static Action<int> myAction2;

        private static Func<int> myFunc; //Another build in Delegate;

        static void Main(string[] args)
        {

            attackAction = MeleeAttack; //Delegate (attackAction) and the Method (MeleeAttack) must have the same signature (return void and no parameters)
            attackAction += RangedAttack; //MulitCast Delegate (it can store multiple objects)
            attackAction();
            Console.WriteLine("------");
            attackAction -= RangedAttack;
            attackAction();

            MyDelegate myDelegate = MyTestFunction; //Delegate (myDelegate) and the Method (MyTestFunction) must have the same signature (return an int and a string as parameter)
            myDelegate("hello");

            myAction = MeleeAttack; //Both has the same signature (return void)

            myAction2 = MyTestFunction2;

            myFunc = MyTestFunction3;

            Func<int, bool> myLambdaFunction = (int i) => false; //Using Delegate with Lambda

            Console.ReadKey();
        }

        private static void MeleeAttack()
        {
            Console.WriteLine("Melee Attack");
        }

        private static void RangedAttack()
        {
            Console.WriteLine("Ranged Attack");
        }

        private static int MyTestFunction(string myString)
        {
            Console.WriteLine(myString);
            return 0;
        }

        private static void MyTestFunction2(int i)
        {
            Console.WriteLine(i);
        }

        private static int MyTestFunction3()
        {
            return 1;
        }
    }
}
