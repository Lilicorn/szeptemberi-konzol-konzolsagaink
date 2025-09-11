using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rendelesek
{
    internal class rendeles2
    {
        public int key { get; set; }
        public string termekkod { get; set; }
        public int menny { get; set; }

        public rendeles2(string x)
        {
            string[] t = x.Split(';');

            key = int.Parse(t[1]);
            termekkod = t[2];
            menny = Convert.ToInt32(t[3]);
        }
    }
}
