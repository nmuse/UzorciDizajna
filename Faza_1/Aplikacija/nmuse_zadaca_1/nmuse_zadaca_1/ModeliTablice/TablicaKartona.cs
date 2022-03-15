using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.ModeliTablice
{
    class TablicaKartona
    {
        public Klub Klub { get; set; }
        public int BrojZutihKartona { get; set; }
        public int BrojDrugihZutihKartona { get; set; }
        public int BrojCrvenihKartona { get; set; }
        public int UkupanBrojKartona { get; set; }

        public TablicaKartona(Klub klub, int brojZutihKartona, int brojDrugihZutihKartona, int brojCrvenihKartona, int ukupanBrojKartona)
        {
            Klub = klub;
            BrojZutihKartona = brojZutihKartona;
            BrojDrugihZutihKartona = brojDrugihZutihKartona;
            BrojCrvenihKartona = brojCrvenihKartona;
            UkupanBrojKartona = ukupanBrojKartona;
        }
    }
}
