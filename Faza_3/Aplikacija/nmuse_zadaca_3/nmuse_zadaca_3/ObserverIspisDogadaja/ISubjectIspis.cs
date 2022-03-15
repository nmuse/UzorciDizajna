﻿using nmuse_zadaca_3.ModeliTablice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ObserverIspisDogadaja
{
    interface ISubjectIspis
    {
        void addObserver(IObserverIspis s);
        void removeObserver(IObserverIspis s);
        ITablica getState();
        void setState(ITablica state);
    }
}
