using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.StateSastava
{
    class StateIgra : StateSastavaUtakmice
    {
        StateSastavaUtakmice stanje1 = null;
        StateSastavaUtakmice stanje2 = null;
        StateSastavaUtakmice stanje3 = null;
        public override void iskljuciIgraca(Sastav igrac)
        {
            stanje1 = new StateIskljucen();
            this.contextSastavaUtakmice.promijeniStanje(stanje1);
            igrac.Stanje = this.contextSastavaUtakmice.dajStanje();
        }

        public override void zamijeniIgrace(Sastav igrac, Sastav zamjena)
        {
            stanje2 = new StateZamijenjen();
            this.contextSastavaUtakmice.promijeniStanje(stanje2);
            igrac.Stanje = this.contextSastavaUtakmice.dajStanje();
            stanje3 = new StateIgra();
            this.contextSastavaUtakmice.promijeniStanje(stanje3);
            zamjena.Stanje = this.contextSastavaUtakmice.dajStanje();
        }
    }
}
