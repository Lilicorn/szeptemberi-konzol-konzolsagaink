using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;
using System.CodeDom.Compiler;

namespace rgb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<pont> kep = new List<pont>();
            foreach(string line in File.ReadAllLines("kep.txt"))
            {
                string[]kepsor = line.Split(' ');
                List<int> pontyaaaa = new List<int>();
                for(int i = 0; i<kepsor.Length; i += 3)
                {
                    int r = int.Parse(kepsor[i].Trim());
                    int g = int.Parse(kepsor[i+1].Trim());
                    int b = int.Parse(kepsor[i+2].Trim());
                    kep.Add(new pont(r, g, b));

                }
            }


            //2. FELADAT
            Console.Write("2. feladat: \nKérem egy képpont adatait!\nSor:");
            int sor = Convert.ToInt32(Console.ReadLine())-1;
            Console.Write("Oszlop:");
            int oszl = Convert.ToInt32(Console.ReadLine())-1; // MEGIS LE KELL VENNI EN MEGORULOK

            int pontind = sor * 640 + oszl;
            //Console.WriteLine(pontind);
            Console.Write("A képpont színe ");
            kiiras(kep, pontind);


            //3. feladat
            int counter = 0;
            foreach(var p in kep)
            {
                if (p.R + p.G + p.B > 600) 
                { 
                    counter++; 
                }
            }
            Console.WriteLine("3. feladat:\nA világos képpontok száma: "+counter);


            //4. feldat
            int min = 765;
            List<pont> sotetember835= new List<pont>();
            foreach (var p in kep)
            {
                if (p.R + p.G + p.B < min)
                {
                    sotetember835.Clear();
                    min = p.R + p.G + p.B;
                    sotetember835.Add(p);
                }
                else if (p.R + p.G + p.B== min)
                {
                    sotetember835.Add(p);
                }
            }

            Console.WriteLine("A legsötétebb pont RGB összege: "+min);
            Console.WriteLine("A legsötétebb pixelek színe:");
            for(int i = 0; i<sotetember835.Count;i++)
            {
                kiiras(sotetember835, i);
            }



            //6. feladat
            Console.WriteLine("6. feladat");
            int elso = 0;
            int utolso = 640;
            for (int i = 0; i< 640; i++)
            {
                if (hatar(kep, i, 10))
                {
                    elso = i;
                    break;
                }
            }
            for (int i = 0; i < 640; i++)
            {
                if (hatar(kep, i, 10))
                {
                    utolso = i;
                }
            }
            Console.WriteLine("A felhő legfelső sora:" + elso );
            Console.WriteLine("A felhő legalsó sora:" + utolso );


            Console.ReadKey();

        }

        static void kiiras(List<pont> k, int ind)
        {
            Console.WriteLine("RGB("+k[ind].R + ", " + k[ind].G + ", " + k[ind].B+")");
        }


        //5. feldat
        static bool hatar(List<pont> k, int sorszam, int kulonbseg)
        {
            int sor = sorszam * 640;
            for (int i = sor; i < sor+360 && i <k.Count; i++)
            {
                int a = k[i].B;
                int b = k[i + 1].B;
                if (b > a) { int temp = a; a = b; b = temp; }

                if (a - b > kulonbseg) 
                { 
                return true; 
                }

            }
            return false;
        }
    }
}
