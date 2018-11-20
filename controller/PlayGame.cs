using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        private view.IView m_view;
        private model.Game m_game;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
            m_game.AddSubscriber(this);
            m_view.DisplayWelcomeMessage();
            Console.WriteLine(m_game.CurrentGameMode());
        }

        public bool Play()
        {
            return m_view.GetInput(m_game);
        }

        public void CardDealt()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
            System.Threading.Thread.Sleep(1000);
        }

        public void PlayerCardDealt()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore(), false); // Cards presented without delay.
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void DealerCardDealt()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore(), false); // Cards presented without delay.

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}
