using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.FactoryMethodTablice
{
    abstract class CreatorIspis
    {
        public abstract IProductIspis odrediVrstuTablice(string vrsta);
    }
}
