using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicWinStrategy : IWinStrategy
    {
        private const int g_maxScore = 21;

        public bool IsDealerWinner(int a_playerScore, int a_dealerScore)
        {
            if (a_playerScore > g_maxScore)
            {
                return true;
            }
            else if (a_dealerScore > g_maxScore)
            {
                return false;
            }
            return a_dealerScore >= a_playerScore;
        }
    }
}
