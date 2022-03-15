using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.Models
{
    class DogadajBuilder : IDogadajBuilder
    {
        private Dogadaj dogadaj = new Dogadaj();

        public DogadajBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.dogadaj = new Dogadaj();
        }

        public void DogadajPocetakIliKrajUtakmiceBuilder(int broj, int minuta, int vrsta)
        {
            this.dogadaj.Broj = broj;
            this.dogadaj.Minuta = minuta;
            this.dogadaj.Vrsta = vrsta;
        }

        public void Dogadaj5AtributaBuilder(String klub, String igrac)
        {
            Prvenstvo prvenstvo = Prvenstvo.GetInstance();
            this.dogadaj.Klub = prvenstvo.ListaKlubova.Find(x => x.Kratica.Contains(klub));
            this.dogadaj.Igrac = prvenstvo.ListaIgraca.Find(x => x.ImePrezime.Contains(igrac));

            if (this.dogadaj.Klub == null || this.dogadaj.Igrac == null)
            {
                return;
            }

        }
        public void Dogadaj6AtributaBuilder(String zamjena)
        {
            Prvenstvo prvenstvo = Prvenstvo.GetInstance();   
            this.dogadaj.Zamjena = prvenstvo.ListaIgraca.Find(x => x.ImePrezime.Contains(zamjena));
            if (this.dogadaj.Zamjena==null)
            {
                return;
            }
        }

        public Dogadaj GetDogadaj()
        {
            Dogadaj result = this.dogadaj;
            this.Reset();
            return result;
        }
    }
}
