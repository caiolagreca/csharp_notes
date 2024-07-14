using System;

/* Pelo que entendi o readonly foi criado com o intuito de fazer com que instancias de classes se tornem uma "const".
 Constantes tem seus valores assinados em compiler time, e quando criamos uma instancia de uma classe, o Constructor da classe ocorre em run time.
 No caso podemos utilizar consts para built in types (string, bool, float...) porem para classes, structs e objects devemos usar o readonly.
 Caso voce queira tornar fields (variaveis internas de classes) imutaveis (constantes), voce precisa atribuir o readonly, pois atribuir como uma "const" nao ira funcionar devido ao problema do compiler time/run time. */

namespace ReadOnly
{
    class Program
    {
        private const float PLAYER_SPEED = 4f;
        private static readonly Player player = new Player(5);
        static void Main(string[] args)
        {
            int age;
            age = 5;
            age = 7;
            Console.WriteLine(PLAYER_SPEED);
            Console.WriteLine(player);

            Console.ReadKey();
        }

        public class Player
        {
            private readonly int healthMax; // readonly é apropriado ao inves de const porque healthMax é inicializado no construtor com um valor passado como parâmetro.

            public Player(int healthMax)
            {
                this.healthMax = healthMax;
            }

            public override string ToString()
            {
                return $"Player with health max: {healthMax}";
            }
        }
    }
}
