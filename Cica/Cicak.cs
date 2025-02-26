using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cica
{
    internal class Cicak
    {
        private string nev;
        private string fajta;
        private float suly;
        private int rendetlensegi_szint;

        public Cicak(string nev, string fajta, float suly, int rendetlensegi_szint)
        {
            this.nev = nev;
            this.fajta = fajta;
            this.suly = suly;
            this.rendetlensegi_szint = rendetlensegi_szint;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Fajta { get => fajta; set => fajta = value; }
        public float Suly { get => suly; set => suly = value; }
        public int Rendetlensegi_szint { get => rendetlensegi_szint; set => rendetlensegi_szint = value; }
    }
}
