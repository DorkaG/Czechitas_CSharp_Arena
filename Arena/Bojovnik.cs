using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Bojovnik
    {
        public string Jmeno { get; private set; }
        public int Sila { get; private set; }
        private int brneni;
        public int Brneni {
            get { return brneni; }
            private set {
                if (value < 0) value = 0;
                else if (value > 50) value = 50;
                brneni = value;
            }
        }
        private int zivot;
        public int Zivot {
            get { return zivot; }
            private set {
                if (value < 0) value = 0;
                else if (value > 100) value = 100;     
                zivot = value;
            } 
        }
        
        public Zbrane Zbran { get; private set; }        

        public Bojovnik(string jmeno, int sila, int brneni, int zivot, Zbrane zbran)
        {
            Jmeno = jmeno;
            Zbran = zbran;
            Sila = sila < 10 ? 10 : sila;            
            Brneni = brneni;            
            Zivot = zivot;
            
            
        }

        public void UtocNa (Bojovnik obet)
        {
            if (Zbran == Zbrane.Mec)
            {
                if (obet.Brneni == 0) obet.Zivot -= this.Sila;
                else if (obet.Brneni > 0)
                {
                    obet.Zivot = obet.Zivot - this.Sila + obet.Brneni;
                    obet.Brneni = obet.Brneni - (this.Sila / 10);
                }
            }
            else if (Zbran == Zbrane.Palcat)
            {
                obet.Zivot = obet.Zivot - (this.Sila / 4);
                if (obet.Brneni != 0) obet.Brneni = obet.Brneni - (this.Sila / 4);                
            }            
        }

        public void UzdraveniAVyzbrojeni ()
        {
            this.Zivot += 40;
            this.Brneni += 20;
        }
    }
}
