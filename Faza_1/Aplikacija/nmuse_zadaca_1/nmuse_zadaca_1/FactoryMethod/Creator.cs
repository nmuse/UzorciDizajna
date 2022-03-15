using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethod
{
    public abstract class Creator
    {
        public abstract IProduct odrediVrstuUcitavanja(string nazivDatoteke);
    }
}
