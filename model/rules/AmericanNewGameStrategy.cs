using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : DealCardStrategy, INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            base.DealCard(a_deck, a_dealer, a_player);

            base.DealCard(a_deck, a_dealer, a_dealer);

            base.DealCard(a_deck, a_dealer, a_player);

            base.DealCard(a_deck, a_dealer, a_dealer, false);

            a_dealer.NotifySubscriber();

            return true;
        }
    }
}
