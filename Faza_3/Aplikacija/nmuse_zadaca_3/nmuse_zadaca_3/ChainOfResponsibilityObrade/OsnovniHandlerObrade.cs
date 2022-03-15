using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ChainOfResponsibilityObrade
{
    abstract class OsnovniHandlerObrade : IObradaDogadaja
    {
        private IObradaDogadaja handlerSljedbenik;
        public virtual int obradiDogadaj(Dogadaj dogadaj)
        {
            if (this.handlerSljedbenik == null)
            {
                return -1;
            }
            else
            {
                return this.handlerSljedbenik.obradiDogadaj(dogadaj);
            }
        }

        public IObradaDogadaja postaviSljedeciHandler(IObradaDogadaja handler)
        {
            this.handlerSljedbenik = handler;
            return handler;
        }
    }
}
