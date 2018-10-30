using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealCardStrategy : IDealCardStrategy
    {
        public void DealCard(Deck a_deck, Dealer a_dealer, Player a_player, bool a_show = true)
        {
            Card c;
            c = a_deck.GetCard();
            c.Show(a_show);
            a_player.DealCard(c);
        }
    }
}
