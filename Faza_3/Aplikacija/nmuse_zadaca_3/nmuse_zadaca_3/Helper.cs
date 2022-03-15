using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3
{
    class Helper
    {

        public int odrediBrojAtributa(string linija)
        {
            int brojAtributa = 0;

            string[] podatci = linija.Split(';');

            brojAtributa = podatci.Length;
            foreach (string p in podatci)
            {
                if (p == "")
                {
                    brojAtributa--;
                }
            }


            return brojAtributa;
        }

    }
}
