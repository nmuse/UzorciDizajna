using nmuse_zadaca_2.ModeliTablice;
using nmuse_zadaca_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.ObserverIspisDogadaja
{
    class ObserverDogadaj : IObserverIspis
    {
        ITablica tablicaState;
        public void update(ISubjectIspis s)
        {
            int goloviDomacinUkupno = 0;
            int goloviGostUkupno = 0;
            bool ispisLijevo = false;
            bool ispisDesno = false;
            tablicaState = s.getState();
            TablicaDogadaja dogadajState = tablicaState as TablicaDogadaja;
            foreach(Dogadaj d in dogadajState.ListaDogadaja)
            {
                if(d.Vrsta == 3)
                {
                    if(d.Klub.Kratica.Equals(dogadajState.Domacin.Kratica))
                    {
                        goloviGostUkupno++;
                        ispisLijevo = false;
                        ispisDesno = true;
                    }
                    else
                    {
                        goloviDomacinUkupno++;
                        ispisLijevo = true;
                        ispisDesno = false;
                    }
                }else if(d.Vrsta == 1 || d.Vrsta == 2)
                {
                    if (d.Klub.Kratica.Equals(dogadajState.Domacin.Kratica))
                    {
                        goloviDomacinUkupno++;
                        ispisLijevo = true;
                        ispisDesno = false;
                    }
                    else
                    {
                        goloviGostUkupno++;
                        ispisLijevo = false;
                        ispisDesno = true;
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,-60}{1,60}", "", d.Minuta));
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,-60}|{1,60}", "DOMAĆIN - " + dogadajState.Domacin.Naziv, "GOST - " + dogadajState.Gost.Naziv));
                Console.WriteLine(String.Format("{0,-60}|{1,60}", "UKUPNO GOLOVA: " + goloviDomacinUkupno, "UKUPNO GOLOVA: " + goloviGostUkupno));
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                if(ispisLijevo)
                {
                    Console.WriteLine(String.Format("{0,-60}|{1,60}", "GOL: " + d.Igrac.ImePrezime, ""));
                }
                else if(ispisDesno)
                {
                    Console.WriteLine(String.Format("{0,-60}|{1,60}", "", "GOL: " + d.Igrac.ImePrezime));
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                ispisLijevo = false;
                ispisDesno = false;
                if (d.Vrsta == 10)
                {
                    if (d.Klub.Kratica.Equals(dogadajState.Domacin.Kratica))
                    {
                        Console.WriteLine(String.Format("{0,-60}|{1,60}", "ŽUTI KARTON: " + d.Igrac.ImePrezime, ""));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0,-60}|{1,60}", "", "ŽUTI KARTON: " + d.Igrac.ImePrezime));
                    }
                }
                else if (d.Vrsta == 11)
                {
                    if (d.Klub.Kratica.Equals(dogadajState.Domacin.Kratica))
                    {
                        Console.WriteLine(String.Format("{0,-60}|{1,60}", "CRVENI KARTON: " + d.Igrac.ImePrezime, ""));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0,-60}|{1,60}", "", "CRVENI KARTON: " + d.Igrac.ImePrezime));
                    }
                }
                else if (d.Vrsta == 20)
                {
                    if (d.Klub.Kratica.Equals(dogadajState.Domacin.Kratica))
                    {
                        Console.WriteLine(String.Format("{0,-60}|{1,60}", "ZAMJENA: " + d.Zamjena.ImePrezime + " -> " + d.Igrac.ImePrezime, ""));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0,-60}|{1,60}", "", "ZAMJENA: " + d.Zamjena.ImePrezime + " -> " + d.Igrac.ImePrezime));
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(dogadajState.Sekunde * 1000);
            }
            
        }
    }
}
