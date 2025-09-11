using kraterek.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace kraterek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Krater> lrater = new List<Krater>();
            foreach (string x in File.ReadAllLines("felszin_tvesszo.txt"))
            {
                lrater.Add(new Krater(x));
            }



            Console.WriteLine("2. feladat:\nA kráterek száma: " + lrater.Count);

            Console.Write("3. feladat\nadd meg a krate rnevet es en nerdy leszek rola: ");
            string kerelem = Console.ReadLine();
            int id = 0;
            foreach (Krater K in lrater)
            {
                if (kerelem == K.Nev)
                {
                    break;
                }
                id++;
            }

            Console.WriteLine($"A(z) {kerelem} középpontja X = {lrater[id].X} Y = {lrater[id].Y} sugara R = {lrater[id].R}");

            id = 0;
            double maxverstappen = 0;
            int NEMTUDFOM = 0;
            foreach (Krater K in lrater)
            {
                if (K.R >= maxverstappen)
                {
                    maxverstappen = K.R;
                    NEMTUDFOM = id;
                }
                id++;
            }
            Console.WriteLine("4.feladat\nA legnagyobb kráter neve és sugara: " + lrater[NEMTUDFOM].Nev + " " + lrater[NEMTUDFOM].R);


            Console.Write("6.feladat\nKérem egy kráter nevét: ");
            string egyes = Console.ReadLine();
            id = 0;
            foreach (Krater K in lrater)
            {
                if (kerelem == K.Nev)
                {
                    break;
                }
                id++;
            }
            List<string> nemmetszi = new List<string>();
            foreach (Krater K in lrater)
            {
                if (tavolsag(lrater[id].X, K.X, lrater[id].Y, K.Y) > (lrater[id].R + K.R) && lrater[id].X != K.X)
                {
                    nemmetszi.Add(K.Nev);

                }
            }
            Console.Write("Nincs közös része: ");
            foreach (string n in nemmetszi)
            {
                if (n != nemmetszi[nemmetszi.Count - 1])
                {
                    Console.Write(n + ", ");
                }
                else {
                    Console.Write(n + ".\n");

                }
            }


            Console.WriteLine("7. feladat");
            foreach (Krater K in lrater) { 
            for (int i = 0; i < lrater.Count; i++)
            {
                Krater a = K;
                Krater b = lrater[i];
                /*if (b.R > a.R)            tudok ilyet is csak ez tulbonyolitja a tortenetet 😛
                {
                    Krater t = b;
                    b = a;
                    a = t;
                } */
                if (tavolsag(a.X, b.X, a.Y, b.Y) < (a.R - b.R))
                {
                    Console.WriteLine($"A(z) {a.Nev} kráter tartalmazza a(z) {b.Nev} krátert.");
                }
            }
        }

            



            Console.ReadKey();

        }


        static double tavolsag(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1));
        }
    }
}
