using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ObserverIspisDogadaja
{
    interface IObserverIspis
    {
        void update(ISubjectIspis s);
    }
}
