using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ChainOfResponsibilityObrade
{
    interface IObradaDogadaja
    {
        IObradaDogadaja postaviSljedeciHandler(IObradaDogadaja handler);
        int obradiDogadaj(Dogadaj dogadaj);
    }
}
