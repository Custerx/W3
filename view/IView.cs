using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    interface IView
    {
        void DisplayWelcomeMessage();
        bool GetInput(model.Game a_game);
        void DisplayCard(model.Card a_card);
        void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score, bool a_slow = true);
        void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score, bool a_slow = true);
        void DisplayGameOver(bool a_dealerIsWinner);
    }
}
