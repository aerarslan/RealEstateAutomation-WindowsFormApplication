using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estate
{
    class Konut:Emlak
    {
        private int salon = 0;
        public int Salon
        {
            get
            {
                return salon;
            }

            set
            {
                salon = value;
            }
        }

        private int odaSayisi = 0;
        public int OdaSayisi
        {
            get
            {
                return odaSayisi;
            }

            set
            {
                odaSayisi = value;
            }
        }

        private int balkonSayisi = 0;
        public int BalkonSayisi
        {
            get
            {
                return balkonSayisi;
            }

            set
            {
                balkonSayisi = value;
            }
        }

        private bool tuvalet = true;
        public bool Tuvalet
        {
            get
            {
                return tuvalet;
            }

            set
            {
                tuvalet = value;
            }
        }

        private int katSayisi = 0;
        public int KatSayisi
        {
            get
            {
                return katSayisi;
            }

            set
            {
                katSayisi = value;
            }
        }
    }
}
