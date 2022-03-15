using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.StateSastava
{
    abstract class StateSastavaUtakmice
    {
        protected ContextSastavaUtakmice contextSastavaUtakmice;
        public void inicijalizirajContext(ContextSastavaUtakmice contextSastavaUtakmice)
        {
            this.contextSastavaUtakmice = contextSastavaUtakmice;
        }
        public abstract void iskljuciIgraca(Sastav igrac);
        public abstract void zamijeniIgrace(Sastav igrac, Sastav zamjena);
    }
}
