using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estate
{
    abstract class Emlak
    {
        private string emlakk = "";
        public string Emlakk
        {
            get
            {
                return emlakk;
            }

            set
            {
                emlakk = value;
            }
        }

        private int metreKare = 0;
        public int MetreKare
        {
            get
            {
                return metreKare;
            }

            set
            {
                metreKare = value;
            }
        }

        private string musteriAdi = "";
        public string MusteriAdi
        {
            get
            {
                return musteriAdi;
            }

            set
            {
                musteriAdi = value;
            }
        }

        private string telNo = "";
        public string TelNo
        {
            get
            {
                return telNo;
            }

            set
            {
                telNo = value;
            }
        }

        private double fiyat = 0;
        public double Fiyat
        {
            get
            {
                return fiyat;
            }

            set
            {
                fiyat = value;
            }
        }

        private string satilikKiralik = "";
        public string SatilikKiralik
        {
            get
            {
                return satilikKiralik;
            }

            set
            {
                satilikKiralik = value;
            }
        }
    }
}
