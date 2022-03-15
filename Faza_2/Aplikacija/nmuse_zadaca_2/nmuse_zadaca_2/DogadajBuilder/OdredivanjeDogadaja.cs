using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.Models
{
    class OdredivanjeDogadaja
    {
        private IDogadajBuilder dogadajBuilder;

        public IDogadajBuilder DogadajBuilder
        {
            set { dogadajBuilder = value; }
        }

        public void odrediDogadaj(int brojAtributa, String linija)
        {
            string[] podaci = linija.Split(';');
            uljepsajZapisLinije(podaci);
            if (podaci[1].Contains("+"))
            {
                string[] minuteNadoknade = podaci[1].Split('+');
                podaci[1] = (Int32.Parse(minuteNadoknade[0]) +
                    Int32.Parse(minuteNadoknade[1])).ToString();
            }
            int result = 0;
            if (!Int32.TryParse(podaci[0], out result) || !Int32.TryParse(podaci[1], out result) || !Int32.TryParse(podaci[2], out result))
            {
                Console.WriteLine("Pogrešan zapis događaja u liniji : " + linija);
                return;
            }
            if (brojAtributa == 3)
            {
                dogadajBuilder.DogadajPocetakIliKrajUtakmiceBuilder(Int32.Parse(podaci[0]), Int32.Parse(podaci[1]), Int32.Parse(podaci[2]));
            }
            else if (brojAtributa == 5)
            {
                dogadajBuilder.DogadajPocetakIliKrajUtakmiceBuilder(Int32.Parse(podaci[0]), Int32.Parse(podaci[1]), Int32.Parse(podaci[2]));
                dogadajBuilder.Dogadaj5AtributaBuilder(podaci[3], podaci[4]);
            }
            else if (brojAtributa == 6)
            {
                dogadajBuilder.DogadajPocetakIliKrajUtakmiceBuilder(Int32.Parse(podaci[0]), Int32.Parse(podaci[1]), Int32.Parse(podaci[2]));
                dogadajBuilder.Dogadaj5AtributaBuilder(podaci[3], podaci[4]);
                dogadajBuilder.Dogadaj6AtributaBuilder(podaci[5], podaci[3]);
            }
            else
            {
                Console.WriteLine("Pogrešan broj atributa za događaj u liniji : " + linija);
            }
        }

        private static void uljepsajZapisLinije(string[] podaci)
        {
            for (int i = 0; i < podaci.Length; i++)
            {
                podaci[i] = podaci[i].Replace("\"", "");
                podaci[i] = podaci[i].Trim();
            }
        }
    }

}


