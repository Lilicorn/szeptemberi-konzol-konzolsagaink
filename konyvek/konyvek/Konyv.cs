using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvek
{
    internal class Konyv
    {
        public int Year { get; set; }
        public int AFourth { get; set; }
        public string Where { get; set; }
        public string Who {  get; set; }
        public int TheCount { get; set; }

        public Konyv(string all)
        {
            Year = int.Parse(all.Split(';')[0]);
            AFourth = int.Parse(all.Split(';')[1]);
            Where = all.Split(';')[2];
            Who = all.Split(';')[3];
            TheCount = int.Parse(all.Split(';')[4]);
        }
    }
}
