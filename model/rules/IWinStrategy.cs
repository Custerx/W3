using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinStrategy
    {
        bool IsDealerWinner(int a_playerScore, int a_dealerScore);
    }
}
