using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }
 
        public bool GetInput(model.Game a_game)
        {
            int input = System.Console.In.Read();

            if (input == 'p')
            {
                a_game.NewGame();
            }
            else if (input == 'h')
            {
                a_game.Hit();
            }
            else if (input == 's')
            {
                a_game.Stand();
            }

            return input != 'q';
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score, bool a_slow = true)
        {
            if(a_slow)
            {
                DisplayHand("Player", a_hand, a_score);
            } else
            {
                DisplayStaticHand("Player", a_hand, a_score);
            }
        
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score, bool a_slow = true)
        {
            if(a_slow)
            { 
                DisplayHand("Dealer", a_hand, a_score);
            } else
            {
                DisplayStaticHand("Dealer", a_hand, a_score);
            }
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                System.Threading.Thread.Sleep(1000);
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        private void DisplayStaticHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}
