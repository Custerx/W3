﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IDealCardStrategy
    {
        void DealCard(Deck a_deck, Dealer a_dealer, Player a_player, bool a_show = true);
    }
}
