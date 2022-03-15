using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.StateSastava
{
    class StateZamijenjen : StateSastavaUtakmice
    {
        StateSastavaUtakmice stanje = null;
        public override void iskljuciIgraca(Sastav igrac)
        {
            stanje = new StateIskljucen();
            this.contextSastavaUtakmice.promijeniStanje(stanje);
            igrac.Stanje = this.contextSastavaUtakmice.dajStanje();
        }

        public override void zamijeniIgrace(Sastav igrac, Sastav zamjena)
        {
            Console.WriteLine("Igrač " + igrac + " je već zamijenjen");
        }
    }
}
