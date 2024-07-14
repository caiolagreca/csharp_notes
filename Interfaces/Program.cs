using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IAttackable attackable = new Player()
            {
                health = 120
            };
            AttackObject(new Player());
            AttackObject(new Enemy());

            //IS and AS keywords:
            Console.WriteLine(attackable.GetType()); //Just to see the type of the attackable object
            if (attackable is Player)
            {
                Console.WriteLine("Is Player!");
                Player player = (Player)attackable; //this is called "cast"; same as: Player player = attackable as Player;
                player.PlayerSaysHello(); //You can only implement this method with the player object because we converted the player type (from IAttckable to Player);
            }

            //Switching on Type instead of just on value:
            switch (attackable)
            {
                case Player player when player.health > 50:
                    Console.WriteLine("Health good");
                    player.PlayerSaysHello();
                    break;
                case Player player:
                    player.PlayerSaysHello();
                    break;
                case Enemy enemy:
                    break;
                case RedBarrel redBarrel:
                    break;
                default:
                    break;
            }
        }

        private static void AttackObject(IAttackable attackable)
        {
            attackable.Damage();
        }

        public class Player : IAttackable, IMovable, IHasInventory
        {
            public int health;
            public void Damage()
            {
                Console.WriteLine("Player Damage");
            }

            public void PlayerSaysHello()
            {
                Console.WriteLine("Hello");
            }
        }

        public class Enemy : IAttackable, IMovable
        {
            //You are not obligate to implement the Interface's Method because it has a logic inside it.
        }

        public class RedBarrel : IAttackable
        {

        }

        public interface IAttackable //public keyword is optional because it is public by default
        {
            public void Damage() //public keyword is optional because it is public by default
            {
                Console.WriteLine("Damage");
            }
        }

        public interface IMovable
        {

        }

        public interface IHasInventory
        {

        }
    }
}
