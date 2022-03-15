using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.StateSastava
{
    class StateIskljucen : StateSastavaUtakmice
    {
        public override void iskljuciIgraca(Sastav igrac)
        {
            Console.WriteLine("Igrač " + igrac + " je već isključen");
        }

        public override void zamijeniIgrace(Sastav igrac, Sastav zamjena)
        {
            Console.WriteLine("Igrača " + igrac + " nije moguće zamijeniti jer je isključen");
        }
    }
}
