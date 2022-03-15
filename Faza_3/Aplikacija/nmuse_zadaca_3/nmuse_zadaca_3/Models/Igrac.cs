using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    public class Igrac : Osoba
    {


        public List<String> Pozicije { get; set; }
        public DateTime DatumRodenja { get; set; }

        public Igrac(String klub, String imePrezime, List<String> listaPozicija, DateTime datumRodenja)
        {
            Klub = klub;
            ImePrezime = imePrezime;
            Pozicije = listaPozicija;
            DatumRodenja = datumRodenja;
        }
    }
}
