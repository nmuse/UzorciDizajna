using nmuse_zadaca_3.ModeliTablice;
using nmuse_zadaca_3.Models;
using nmuse_zadaca_3.VisitorAktivnosti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.FactoryMethodTablice
{
    class IspisRezultataUtakmica : IProductIspis
    {
        public void accept(IVisitorObradaAktivnosti visitor)
        {
            visitor.visitRezultatiUtakmica(this);
        }

        public void ispisiTablicu(List<ITablica> listaTablica)
        {
        }
    }
}
