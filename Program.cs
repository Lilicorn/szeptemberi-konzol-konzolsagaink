using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace létra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> dobasok = new List<int>();
            string[] mivan = File.ReadAllLines("dobasok.txt");
            mivan = mivan[0].Split(',');
            foreach (string m in mivan)
            {
                dobasok.Add(int.Parse(m.Trim()));
            }

            int poz = 0;
            int letracounter = 0;
            Console.WriteLine("2. feladat");
            foreach(int dobas in dobasok){
                poz += dobas;
                if ((poz) % 10 == 0)
                {
                    poz -= 3;
                    letracounter++;
                }
                Console.Write(poz + " ");
            }
            Console.WriteLine();

            Console.WriteLine($"3. feladat\nA játék során {letracounter} alkalommal lépett létrára.");

            if(poz >= 45)
            {
                Console.WriteLine($"4. feladat\nA játékot befejezte.");
            }
            else
            {
                Console.WriteLine($"4. feladat\n A játékot nem fejezte be.");

            }

            Console.ReadKey();
        }
    }
}
