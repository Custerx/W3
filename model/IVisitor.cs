using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface IVisitor
    {
        void VisitDealer(Dealer a_dealer);
        void VisitGame(Game a_game);
    }
}
