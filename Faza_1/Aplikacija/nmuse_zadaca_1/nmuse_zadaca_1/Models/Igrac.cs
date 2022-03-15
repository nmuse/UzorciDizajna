using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.Models
{
    class Igrac
    {
        //mozda bolje stavit da je klub string
        public Klub Klub { get; set; }
        public String ImePrezime { get; set; }
        public List<String> Pozicije { get; set; }
        public DateTime DatumRodenja { get; set; }

        //ovo triba jos doradit,ovo nije dobro ovako,triba one provjere klubova i to napravit
        //provjerit jeli taj klub stvarno postoji i tako to
        public Igrac(Klub klub, String imePrezime, List<String> listaPozicija, DateTime datumRodenja)
        {
            Klub = klub;
            ImePrezime = imePrezime;
            Pozicije = listaPozicija;
            DatumRodenja = datumRodenja;
        }
    }
}
