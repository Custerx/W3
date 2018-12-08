using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface ISubject
    {
        void AddSubscriber(IBlackJackObserver a_sub);
        void RemoveSubscriber(IBlackJackObserver a_observer);
        void NotifySubscriber();
    }
}
