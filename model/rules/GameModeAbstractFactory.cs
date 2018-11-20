using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class GameModeAbstractFactory
    {
        public IRulesAbstractFactory AmericanBasicBasic()
        {
            return new RulesFactoryAmericanBasicBasic();
        }

        public IRulesAbstractFactory AmericanSoft17Easy()
        {
            return new RulesFactoryAmericanSoft17Easy();
        }

        public IRulesAbstractFactory InternationalSoft17Easy()
        {
            return new RulesFactoryInternationalSoft17Easy();
        }
    }
}
