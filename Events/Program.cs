using System;


namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();
            PlayerHealthBar playerHealthBar = new PlayerHealthBar(player);
            PlayerManaBar playerManaBar = new PlayerManaBar(player);
            player.Damage(); // Aciona o evento

            playerHealthBar.Unsubscribe(player);
            playerManaBar.Unsubscribe(player);

            player.Damage(); // Não aciona mais os eventos dos health bar e mana bar
        }
        //Classe Publisher: A classe que declara o evento. É responsável por chamar o evento para notificar os inscritos quando o evento ocorre.
        private class Player
        {
            public class OnPlayerDamagedEventArgs : EventArgs
            {
                public int PreviousHealth { get; set; }
            }

            // Declaração do evento usando EventHandler<T>
            //O delegate está implícito na assinatura do evento
            //Um evento é um "wrapper" em torno de um delegate. Ele expõe o delegate de maneira segura, permitindo que outras classes se inscrevam e cancelem a inscrição para notificações.
            public event EventHandler<OnPlayerDamagedEventArgs> OnPlayerDamaged;

            public void Damage()
            {
                //Sempre verifique se o evento não é nulo antes de invocá-lo.
                OnPlayerDamaged?.Invoke(this, new OnPlayerDamagedEventArgs
                {
                    PreviousHealth = 56
                });
            }
        }
        //Subscriber (Assinante): A classe que se inscreve no evento. É responsável por fornecer métodos que serão chamados quando o evento ocorrer. A inscrição é feita no construtor da classe
        private class PlayerHealthBar
        {
            public PlayerHealthBar(Player player)
            {
                // Inscreve-se no evento OnPlayerDamaged
                player.OnPlayerDamaged += Player_OnPlayerDamaged;
            }

            // Método que será chamado quando o evento OnPlayerDamaged for acionado
            private void Player_OnPlayerDamaged(object? sender, Player.OnPlayerDamagedEventArgs e)
            {
                // Acessa a propriedade PreviousHealth do argumento do evento
                Console.WriteLine($"Player Health was {e.PreviousHealth}");
            }

            // Método para desinscrever do evento. é uma boa prática realizar o unsubscribe (desinscrição) dos eventos para evitar vazamentos de memória, especialmente em aplicativos de longa duração ou quando os objetos que se inscreveram nos eventos têm um ciclo de vida diferente dos objetos que publicam os eventos.
            public void Unsubscribe(Player player)
            {
                player.OnPlayerDamaged -= Player_OnPlayerDamaged;
            }

        }
        ////Subscriber. A inscrição é feita no construtor da classe
        private class PlayerManaBar
        {
            public PlayerManaBar(Player player)
            {
                // Inscreve-se no evento OnPlayerDamaged
                player.OnPlayerDamaged += Player_OnPlayerDamaged;
            }

            // Método que será chamado quando o evento OnPlayerDamaged for acionado
            private void Player_OnPlayerDamaged(object sender, Player.OnPlayerDamagedEventArgs e)
            {
                // Apenas imprime uma mensagem simples
                Console.WriteLine("Mana bar updated");
            }

            // Método para desinscrever do evento
            public void Unsubscribe(Player player)
            {
                player.OnPlayerDamaged -= Player_OnPlayerDamaged;
            }
        }


    }
}
