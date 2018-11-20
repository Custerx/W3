using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class GameModeVisitor : IVisitor // Should be in view.
    {
        public void VisitDealer(Dealer a_dealer)
        {

        }

        public void VisitGame(Game a_game)
        {
            Console.WriteLine(a_game.CurrentGameMode());
        }
    
    }
}
