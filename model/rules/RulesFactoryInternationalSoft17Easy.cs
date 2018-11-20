using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactoryInternationalSoft17Easy : IRulesAbstractFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new Soft17HitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new InternationalNewGameStrategy();
        }

        public IWinStrategy GetWinRule()
        {
            return new EasyWinStrategy();
        }

        public IDealCardStrategy GetCardRule()
        {
            return new DealCardStrategy();
        }
    }
}
