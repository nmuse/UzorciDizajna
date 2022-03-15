using nmuse_zadaca_3;
using nmuse_zadaca_3.Models;
using nmuse_zadaca_3.StateSastava;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ChainOfResponsibilityObrade
{
    class ObradaKartona : OsnovniHandlerObrade
    {
        public override int obradiDogadaj(Dogadaj dogadaj)
        {
            Sastav igrac = null;
            List<Sastav> sastavi = dajSastaveKraj();
            foreach (Sastav s in sastavi)
            {
                if (s.Broj == dogadaj.Broj && s.Igrac == dogadaj.Igrac && s.Klub == dogadaj.Klub)
                {
                    igrac = s;
                }
            }
            if (igrac is null) return 0;
            ContextSastavaUtakmice contextSastavaUtakmice = new ContextSastavaUtakmice(igrac.Stanje);
            switch (dogadaj.Vrsta)
            {
                case 10:
                    igrac.ZutiKartoni++;
                    if (contextSastavaUtakmice.provjeriImaLiDrugiZutiKarton(igrac))
                    {
                        contextSastavaUtakmice.iskljuciIgraca(igrac);
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                case 11:
                    if (contextSastavaUtakmice.provjeriMozeLiSeIgracIskljuciti(igrac))
                    {
                        contextSastavaUtakmice.iskljuciIgraca(igrac);
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
            }

            return base.obradiDogadaj(dogadaj);
        }

        private List<Sastav> dajSastaveKraj()
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Kolo> listaKola = p1.NogometnoPrventsvo.dajKola();
            List<Utakmica> listaUtakmica = new List<Utakmica>();
            foreach (Kolo k in listaKola)
            {
                List<Utakmica> listaUtakmicaKola = k.dajListuUtakmica();
                foreach (Utakmica u in listaUtakmicaKola)
                {
                    listaUtakmica.Add(u);
                }
            }
            List<Sastav> listaSastava = new List<Sastav>();
            foreach (Utakmica u in listaUtakmica)
            {
                List<Sastav> listaSastavaUtakmice = u.dajListuSastavaKraj();
                foreach (Sastav s in listaSastavaUtakmice)
                {
                    listaSastava.Add(s);
                }
            }

            return listaSastava;
        }
    }
}
