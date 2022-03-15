using nmuse_zadaca_3.ModeliTablice;
using nmuse_zadaca_3.VisitorAktivnosti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.FactoryMethodTablice
{
    interface IProductIspis
    {
        void ispisiTablicu(List<ITablica> listaTablica);
        void accept(IVisitorObradaAktivnosti visitor);
    }
}
