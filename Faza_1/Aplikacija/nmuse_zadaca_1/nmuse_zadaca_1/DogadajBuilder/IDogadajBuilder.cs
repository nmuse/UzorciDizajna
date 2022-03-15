using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.Models
{
    public interface IDogadajBuilder
    {
        void DogadajPocetakIliKrajUtakmiceBuilder(int broj, int minuta, int vrsta);
        void Dogadaj5AtributaBuilder(String klub, String igrac);
        void Dogadaj6AtributaBuilder(String zamjena);
    }
}
