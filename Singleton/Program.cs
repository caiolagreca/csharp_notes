using System;
using System.Collections.Generic;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GameManager.Instance);
            GameManager.Instance.TestFunction();
            Console.ReadKey();
        }

        public class GameManager
        {
            private static GameManager instance;

            public static GameManager Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                    return instance;
                }
            }
            private GameManager() { }

            public void TestFunction() { }
        }


    }
}
