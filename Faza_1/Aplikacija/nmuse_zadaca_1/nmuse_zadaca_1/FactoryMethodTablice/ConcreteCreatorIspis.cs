using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethodTablice
{
    class ConcreteCreatorIspis : CreatorIspis
    {
        public override IProductIspis odrediVrstuTablice(string vrsta)
        {
            if (vrsta == "T")
            {
                return new IspisKlubova();
            }
            else if (vrsta == "S")
            {
                return new IspisStrijelaca();
            }
            else if (vrsta == "K")
            {
                return new IspisKartona();
            }
            else if (vrsta == "R")
            {
                return new IspisRezultataUtakmica();
            }
            else
            {
                throw new ApplicationException();
            }
        }
    }
}
