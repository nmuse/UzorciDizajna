using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.Models
{
    public class Trener : Osoba
    {
        public Trener(String klub, String imePrezime)
        {
            Klub = klub;
            ImePrezime = imePrezime;
        }
    }
}
