using nmuse_zadaca_2.ModeliTablice;
using nmuse_zadaca_2.Models;
using nmuse_zadaca_2.VisitorAktivnosti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.FactoryMethodTablice
{
    class IspisKlubova : IProductIspis
    {
        public void accept(IVisitorObradaAktivnosti visitor)
        {
            visitor.visitKlubovi(this);
        }

        public void ispisiTablicu(List<ITablica> listaTablica)
        {
            List<TablicaKlubova> listaTabliceKlubovaSortirana = new List<TablicaKlubova>();
            foreach (ITablica t in listaTablica)
            {
                listaTabliceKlubovaSortirana.Add(t as TablicaKlubova);
            }

            Console.WriteLine("Tablica klubova");
            Console.WriteLine(String.Format("|{0,-20}|{1,-20}|{2,-20}|{3,-13}|{4,-16}|{5,-12}|{6,-18}|" +
                "{7,-25}|{8,-15}|{9,-12}|", "Klub", "Trener", "Broj odigranih kola", "Broj pobjeda", "Broj neriješenih", "Broj poraza",
                "Broj danih golova", "Broj primljenih golova", "Razlika golova", "Broj bodova"));
            int sumaPobjede = 0;
            int sumaNerijeseni = 0;
            int sumaPorazi = 0;
            int sumaDaniGolovi = 0;
            int sumaPrimljeniGolovi = 0;
            int sumaSviBodovi = 0;
            foreach (TablicaKlubova klub in listaTabliceKlubovaSortirana)
            {
                sumaPobjede += klub.BrojPobjeda;
                sumaNerijeseni += klub.BrojNerjesenih;
                sumaPorazi += klub.BrojPoraza;
                sumaDaniGolovi += klub.BrojDanihGolova;
                sumaPrimljeniGolovi += klub.BrojPrimljenihGolova;
                sumaSviBodovi += klub.BrojBodova;
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------" +
                    "------------------------------------------------------------------------");
                Console.WriteLine(String.Format("|{0,-20}|{1,-20}|{2,20}|{3,13}|{4,16}|{5,12}|{6,18}|" +
                    "{7,25}|{8,15}|{9,12}|", klub.Klub.Naziv, klub.Trener.ImePrezime, klub.BrojOdigranihKola, klub.BrojPobjeda, klub.BrojNerjesenih, klub.BrojPoraza,
                klub.BrojDanihGolova, klub.BrojPrimljenihGolova, klub.RazlikaGolova, klub.BrojBodova));
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------" +
                    "------------------------------------------------------------------------");
            Console.WriteLine(String.Format("|{0,-20}|{1,-20}|{2,20}|{3,13}|{4,16}|{5,12}|{6,18}|" +
                "{7,25}|{8,15}|{9,12}|", "", "", "", sumaPobjede, sumaNerijeseni,
                sumaPorazi, sumaDaniGolovi, sumaPrimljeniGolovi, "", sumaSviBodovi));
        }
    }
}

