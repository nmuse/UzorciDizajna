using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
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
            //this.dogadaj.Igrac = prvenstvo.ListaIgraca.Find(x => x.ImePrezime.Contains(igrac));
            Klub trazeniKlub = prvenstvo.ListaKlubova.Find(x => x.Kratica.Equals(klub));
            if(trazeniKlub==null)
            {
                return;
            }
            List<Igrac> igraciKluba = trazeniKlub.dajIgrace();
            this.dogadaj.Igrac = igraciKluba.Find(x => x.ImePrezime.Contains(igrac));

            if (this.dogadaj.Klub == null || this.dogadaj.Igrac == null)
            {
                return;
            }

        }
        public void Dogadaj6AtributaBuilder(String zamjena, String klub)
        {
            Prvenstvo prvenstvo = Prvenstvo.GetInstance();
            //this.dogadaj.Zamjena = prvenstvo.ListaIgraca.Find(x => x.ImePrezime.Contains(zamjena));
            Klub trazeniKlub = prvenstvo.ListaKlubova.Find(x => x.Kratica.Equals(klub));
            if (trazeniKlub == null) return;
            List<Igrac> igraciKluba = trazeniKlub.dajIgrace();
            this.dogadaj.Zamjena = igraciKluba.Find(x => x.ImePrezime.Contains(zamjena));

            if (this.dogadaj.Zamjena == null)
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
