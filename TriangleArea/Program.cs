using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = ReadInt("Enter width: ");
            int height = ReadInt("Enter height: ");

            Console.WriteLine($"The area is {CalcArea(width, height)}");
        }

        static int CalcArea(int width, int height)
        {
            return width * height / 2;
        }

        static int ReadInt(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
