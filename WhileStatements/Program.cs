using System;

namespace WhileStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            //Console.ReadLine() ?? "0" assegura que, se Console.ReadLine() retornar null, uma string "0" será usada no lugar, evitando a conversão de null para int
            string num1Text = Console.ReadLine() ?? "0";
            int firstNumber = Convert.ToInt32(num1Text);

            Console.Write("Enter second number: ");
            string num2Text = Console.ReadLine() ?? "0";
            int secondNumber = Convert.ToInt32(num2Text);

            int answer = firstNumber * secondNumber;
            int answerNumber = 0;


            Console.Write("what is the value of " + firstNumber + " x " + secondNumber + "?");
            Console.WriteLine();

            while (answer != answerNumber)
            {
                Console.Write("Enter your answer: ");
                string answerInput = Console.ReadLine() ?? "0";
                answerNumber = Convert.ToInt32(answerInput);

                if (answer != answerNumber)
                {
                    Console.WriteLine("Wrong Answer.");
                }
            }
        }
    }
}
