using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game : IBlackJackObserver, IVisitable
    {
        private model.Dealer m_dealer;
        private model.Player m_player;
        private List<IBlackJackObserver> m_observers;
        private rules.GameModeAbstractFactory m_gameMode;
        private List<rules.IRulesAbstractFactory> m_listOfRules;
        private rules.IRulesAbstractFactory m_currentGameMode;

        public Game()
        {
            try
            {
                m_gameMode = new rules.GameModeAbstractFactory();
                CreateGameModeList();
                ChoseGameMode();

                m_dealer = new Dealer(CurrentGameMode());
                m_player = new Player();
                m_observers = new List<IBlackJackObserver>();
                m_dealer.AddSubscriber(this);
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public rules.IRulesAbstractFactory CurrentGameMode()
        {
            return m_currentGameMode;
        }

        public void ChoseGameMode(int a_chosenGameMode = 0) // Default: InternationalSoft17Easy().
        {
            if (a_chosenGameMode > 2)
            {
                throw new System.ArgumentException("ChoseGameMode parameter cannot be larger than 2");
            }
            m_currentGameMode = m_listOfRules[a_chosenGameMode];
        }

        public void Accept(IVisitor a_visitor)
        {
            a_visitor.VisitGame(this);
        }

        public void AddSubscriber(IBlackJackObserver a_sub)
        {
            m_dealer.AddSubscriber(a_sub);
        }

        public void RemoveSubscriber(IBlackJackObserver a_observer)
        {
            m_observers.Remove(a_observer);
        }

        public void NotifySubscriber()
        {
            m_observers.ForEach(x => x.CardDealt());
        }

        public void CardDealt()
        {
            NotifySubscriber();
        }

        public void NotifyTwoSubscriber()
        {
            m_observers.ForEach(x => x.PlayerCardDealt());
        }

        public void PlayerCardDealt()
        {
            NotifyTwoSubscriber();
        }

        public void NotifyThreeSubscriber()
        {
            m_observers.ForEach(x => x.DealerCardDealt());
        }

        public void DealerCardDealt()
        {
            NotifyThreeSubscriber();
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {
            return m_dealer.Stand(m_player);
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }

        private void CreateGameModeList()
        {
            m_listOfRules = new List<rules.IRulesAbstractFactory>();

            m_listOfRules.Add(m_gameMode.InternationalSoft17Easy());
            m_listOfRules.Add(m_gameMode.AmericanSoft17Easy());
            m_listOfRules.Add(m_gameMode.AmericanBasicBasic());
        }
    }
}
