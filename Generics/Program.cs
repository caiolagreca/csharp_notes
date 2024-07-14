using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<Player> myIntList = new MyList<Player>();
            myIntList.field = new Player();
            Console.WriteLine(myIntList.MyFunction());
            Console.ReadKey();
        }

        private static void GetAttackWinner<TAttackable, TDefendable>(TAttackable attackable, TDefendable defendable) where TAttackable : IAttackable where TDefendable : IDefendable
        {
            attackable.GetAttackPoints();
            defendable.GetDefendPoints();

        }

        private interface IAttackable
        {
            public int GetAttackPoints();
        }

        private interface IDefendable
        {
            public int GetDefendPoints();
        }

        private class Player
        {

        }

        private class MyList<T> where T : class, new()
        {
            public T field;

            public T MyFunction()
            {
                return new T();
            }
        }
    }
}
