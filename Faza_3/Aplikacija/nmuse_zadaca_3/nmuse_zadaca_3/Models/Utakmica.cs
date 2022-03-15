using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    class Utakmica : INogometnoPrvenstvo
    {
        public int Broj { get; set; }
        public int Kolo { get; set; }
        public Klub Domacin { get; set; }
        public Klub Gost { get; set; }
        public DateTime Pocetak { get; set; }

        List<Sastav> ListaSastavaPocetak = new List<Sastav>();
        List<Sastav> ListaSastavaKraj = new List<Sastav>();
        List<Dogadaj> ListaDogadaja = new List<Dogadaj>();

        public Utakmica(int broj, int kolo, Klub domacin, Klub gost, DateTime pocetak)
        {
            Broj = broj;
            Kolo = kolo;
            Domacin = domacin;
            Gost = gost;
            Pocetak = pocetak;
        }

        public void dodajDijete(INogometnoPrvenstvo dijete)
        {
            ListaDogadaja.Add(dijete as Dogadaj);
        }

        public void dodajDijeteSastav(INogometnoPrvenstvo dijete)
        {
            ListaSastavaPocetak.Add(dijete as Sastav);
        }

        public void dodajDijeteSastavKraj(INogometnoPrvenstvo dijete)
        {
            ListaSastavaKraj.Add(dijete as Sastav);
        }

        public List<Sastav> dajListuSastava()
        {
            return ListaSastavaPocetak;
        }

        public List<Sastav> dajListuSastavaKraj()
        {
            return ListaSastavaKraj;
        }

        public List<Dogadaj> dajListuDogadaja()
        {
            return ListaDogadaja;
        }

    }
}
