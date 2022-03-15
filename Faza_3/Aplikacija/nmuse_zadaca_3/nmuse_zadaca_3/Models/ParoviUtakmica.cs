using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    class ParoviUtakmica
    {
        public int kolo { get; set; }
        public Klub klubDomacin { get; set; }
        public Klub klubGost { get; set; }

        public ParoviUtakmica(int kolo, Klub klubDomacin, Klub klubGost)
        {
            this.kolo = kolo;
            this.klubDomacin = klubDomacin;
            this.klubGost = klubGost;
        }

    }
}
