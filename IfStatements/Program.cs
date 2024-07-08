using System;

namespace IfElseExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            string num1Text = Console.ReadLine()    ;
            int firstNumber = Convert.ToInt32(num1Text);

            Console.Write("Enter second number: ");
            string num2Text = Console.ReadLine();
            int secondNumber = Convert.ToInt32(num2Text);

            int answer = firstNumber * secondNumber;

            Console.Write("value of " + firstNumber + " x " + secondNumber + ": ");
            string answerInput = Console.ReadLine();
            int answerNumber = Convert.ToInt32(answerInput);

            if (answer == answerNumber)
            {
                Console.WriteLine("Well done!");
            }
            else
            {
                Console.WriteLine("Wrong Answer.");
            }

        }
    }
}
