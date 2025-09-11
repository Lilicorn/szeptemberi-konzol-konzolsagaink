using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace kraterek.Properties
{
    internal class Krater
    {
        public double X { get; set; }
        public double Y{ get; set; }
        public double R { get; set; }
        public string  Nev { get; set; }

        public Krater( string x ) 
        {
            X = Convert.ToDouble(x.Split('\t')[0]);
            Y = Convert.ToDouble(x.Split('\t')[1]);
            R = Convert.ToDouble(x.Split('\t')[2]);
            Nev = x.Split('\t')[3];
        }
    }
}
