using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rendelesek
{
    internal class rendeles1
    {
        public int key { get; set; }
        public string datum { get; set; }
        public string email { get; set; }
        

        public rendeles1(string x)
        {
            string[] t = x.Split(';');
            
                datum = t[1];
                key = int.Parse(t[2]);
                email = t[3];
        }
    }
}
