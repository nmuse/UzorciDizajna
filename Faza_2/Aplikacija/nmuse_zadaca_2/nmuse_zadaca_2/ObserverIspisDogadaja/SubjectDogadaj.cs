using nmuse_zadaca_2.ModeliTablice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.ObserverIspisDogadaja
{
    class SubjectDogadaj : ISubjectIspis
    {
        ITablica state;
        List<IObserverIspis> ListaObservers=new List<IObserverIspis>();
        public void addObserver(IObserverIspis s)
        {
            ListaObservers.Add(s);
        }

        public ITablica getState()
        {
            return state;
        }

        public void removeObserver(IObserverIspis s)
        {
            ListaObservers.Remove(s);
        }

        public void notifyObservers()
        {
            foreach (IObserverIspis s in ListaObservers)
            {
                s.update(this);
            }
        }

        public void setState(ITablica state)
        {
            this.state = state;
            notifyObservers();
        }

    }
}
