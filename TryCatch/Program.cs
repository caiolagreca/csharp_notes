using System;

namespace OutParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            bool looping = true;

            while (looping)
            {
                try
                {
                    Console.Write("Enter a number: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(num);
                    looping = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Too many digits!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only numbers!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
                }
                finally
                {
                    Console.WriteLine("Finally!");
                }
            }
            Console.WriteLine("Good bye");
        }
    }
}
