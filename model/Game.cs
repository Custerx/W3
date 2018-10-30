﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game : IBlackJackObserver
    {
        private model.Dealer m_dealer;
        private model.Player m_player;
        private List<IBlackJackObserver> m_observers;

        public Game()
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
            m_observers = new List<IBlackJackObserver>();
            m_dealer.AddSubscriber(this);
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
    }
}
