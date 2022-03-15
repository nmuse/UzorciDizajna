using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.StateSastava
{
    class ContextSastavaUtakmice
    {
        private StateSastavaUtakmice stateSastavaUtakmice = null;
        public ContextSastavaUtakmice(StateSastavaUtakmice stateSastavaUtakmice)
        {
            this.stateSastavaUtakmice = stateSastavaUtakmice;
            this.stateSastavaUtakmice.inicijalizirajContext(this);
        }

        public void promijeniStanje(StateSastavaUtakmice state)
        {
            this.stateSastavaUtakmice = state;
            this.stateSastavaUtakmice.inicijalizirajContext(this);
        }

        public StateSastavaUtakmice dajStanje()
        {
            return this.stateSastavaUtakmice;
        }

        public void iskljuciIgraca(Sastav igrac)
        {
            this.stateSastavaUtakmice.iskljuciIgraca(igrac);
        }
        public void zamijeniIgrace(Sastav igrac, Sastav zamjena)
        {
            this.stateSastavaUtakmice.zamijeniIgrace(igrac, zamjena);
        }

        public bool provjeraZamjene(Sastav igrac, Sastav zamjena)
        {
            if ((igrac.Stanje is StateIgra) == false) {
                return false;
            }
            if ((zamjena.Stanje is StatePricuva) == false)
            {
                return false;
            }
            if ((zamjena.Stanje is StateIskljucen) == true)
            {
                return false;
            }
            if ((igrac.Stanje is StateZamijenjen) == true)
            {
                return false;
            }

            return true;
        }

        public bool provjeriMogucnostDavanjaGolova(Sastav igrac)
        {
            if ((igrac.Stanje is StateIgra) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool provjeriMozeLiSeIgracIskljuciti(Sastav igrac)
        {
            if (igrac.Stanje is StateIskljucen)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool provjeriImaLiDrugiZutiKarton(Sastav igrac)
        {
            bool imaDvaZutaKartona = false;
            if (igrac.ZutiKartoni == 2)
            {
                imaDvaZutaKartona = true;
                igrac.ZutiKartoni = 0;
            }
            else
            {
                imaDvaZutaKartona = false;
            }
            return imaDvaZutaKartona;
        }
    }
}
