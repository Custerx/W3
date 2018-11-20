using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactoryAmericanBasicBasic : IRulesAbstractFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IWinStrategy GetWinRule()
        {
            return new BasicWinStrategy();
        }

        public IDealCardStrategy GetCardRule()
        {
            return new DealCardStrategy();
        }
    }
}
