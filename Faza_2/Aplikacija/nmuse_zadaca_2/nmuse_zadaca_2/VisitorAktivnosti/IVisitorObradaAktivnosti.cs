using nmuse_zadaca_2.FactoryMethodTablice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.VisitorAktivnosti
{
    interface IVisitorObradaAktivnosti
    {
        void visitKartoni(IspisKartona ispisKartona);
        void visitKlubovi(IspisKlubova ispisKlubovi);
        void visitRezultatiUtakmica(IspisRezultataUtakmica ispisRezultataUtakmica);
        void visitStrijelci(IspisStrijelaca ispisStrijelaca);
    }
}
