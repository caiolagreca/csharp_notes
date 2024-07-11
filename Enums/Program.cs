using System;

namespace Enums
{
    class Program
    {

        //ENUMS for If statements:
        private enum PlayerAction
        {
            NoEnemy,
            NoPathToEnemy,
            MovingTowardEnemy,
            AttackingEnemy
        }

        private PlayerAction GetNextPlayerAction()
        {
            if (!PlayerHasEnemy())
            {
                return PlayerAction.NoEnemy;
            }
            if (!HasPathToEnemy())
            {
                return PlayerAction.NoPathToEnemy;
            }
            if (!PlayerWithinAttackDistance())
            {
                return PlayerAction.MovingTowardEnemy;
            }
            else
            {
                return PlayerAction.AttackingEnemy;
            }
        }

        private bool PlayerHasEnemy()
        {
            return false;
        }
        private bool HasPathToEnemy()
        {
            return true;
        }
        private bool PlayerWithinAttackDistance()
        {
            return false;
        }

        //ENUMS for Switch Statement:
        private enum State
        {
            LookingForEnemy,
            MovingToEnemy,
            AttackingEnemy
        }

        private State state;

        private void HandleState()
        {
            switch (state)
            {
                case State.MovingToEnemy:
                    //Moving to enemy logic
                    break;
                case State.LookingForEnemy:
                    break;
                case State.AttackingEnemy:
                    break;
            }
        }


        private enum TutorialStage
        {
            Stage_1,
            Stage_2,
            Stage_3,
            Stage_4,
        }

        static void Main(string[] args)
        {
            PlayerAction playerAction = PlayerAction.NoPathToEnemy;
            Console.WriteLine((int)playerAction); //1 (index 1)
            Console.WriteLine((PlayerAction)2); //MovingTowardEnemy

            TutorialStage tutorialStage = TutorialStage.Stage_1;
            tutorialStage++;
            Console.WriteLine(tutorialStage); //Stage_2
            string tutorialStageString = tutorialStage.ToString();
            Console.WriteLine(Enum.Parse<TutorialStage>(tutorialStageString)); //Stage_2
            //Enum.Parse<T>(string value) eh um metodo generico que converte uma string definida em um enum para o valor desse mesmo enum. No caso acima, converte "Stage_2" de volta para o valor do enum Stage2 (sem ser uma string)

            Console.WriteLine("------------");
            foreach (TutorialStage tutorialStage1 in Enum.GetValues(typeof(TutorialStage)))
            {
                Console.WriteLine(tutorialStage1);
            }
            /* OUTPUT
            ------------
            Stage_1
            Stage_2
            Stage_3
            Stage_4
             */

        }
    }
}
