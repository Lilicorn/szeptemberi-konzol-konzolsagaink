using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rendelesek
{
    internal class raktar
    {
        public string termekkod { get; set; }
        public string nev { get; set; }
        public int ar { get; set; }
        public int keszlet { get; set; }
        public raktar(string x)
        {
            termekkod = x.Split(';')[0];
            nev = x.Split(';')[1];
            ar = int.Parse(x.Split(';')[2]);
            keszlet = int.Parse(x.Split(';')[3]);
        }
    }
}
