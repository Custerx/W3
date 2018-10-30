using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinStrategy m_winRule;
        private rules.IDealCardStrategy m_dealCardRule;

        private List<IBlackJackObserver> m_observers;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinRule();
            m_dealCardRule = a_rulesFactory.GetCardRule();
            m_observers = new List<IBlackJackObserver>();
        }

        public void AddSubscriber(IBlackJackObserver a_sub)
        {
            m_observers.Add(a_sub);
        }

        public void RemoveSubscriber(IBlackJackObserver a_sub)
        {
            m_observers.Remove(a_sub);
        }

        public void NotifySubscriber()
        {
            m_observers.ForEach(x => x.CardDealt());
        }

        public void NotifyTwoSubscriber()
        {
            m_observers.ForEach(x => x.PlayerCardDealt());
        }

        public void NotifyThreeSubscriber()
        {
            m_observers.ForEach(x => x.DealerCardDealt());
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                m_dealCardRule.DealCard(m_deck, this, a_player);
                NotifyTwoSubscriber();
                return true;
            }
            return false;
        }

        public bool Stand(Player a_player)
        {
            if (m_deck != null)
            {
                while (m_hitRule.DoHit(this))
                {
                    m_dealCardRule.DealCard(m_deck, this, this);
                    NotifyThreeSubscriber();
                }
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(a_player.CalcScore(), CalcScore());
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
