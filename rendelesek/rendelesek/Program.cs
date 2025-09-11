using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rendelesek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<raktar> raktarkeszlet = new List<raktar>();
            List<rendeles1> r1 = new List<rendeles1>();
            List<rendeles2> r2 = new List<rendeles2>();
            foreach (string x in File.ReadAllLines("raktar.csv"))
            {
                raktarkeszlet.Add(new raktar(x));
            }
            foreach (string x in File.ReadAllLines("rendeles.csv"))
            {
                if (x.Split(';')[0] == "M") 
                {
                    r1.Add(new rendeles1(x));
                }
                else
                {
                    r2.Add(new rendeles2(x));
                }

            }


            //2. feladat
            bool teljesitheto=true;
            int ossz = 0;
            
            
            Dictionary<string, int> varakozas = new Dictionary<string, int>();
            Dictionary<int, int> temp = new Dictionary<int, int>();

            StreamWriter levelek = new StreamWriter("levelek.csv");
            StreamWriter beszerzes = new StreamWriter("beszerzes.csv");
            foreach (var m in r1)
            {
                teljesitheto = true;
                ossz = 0;
                int counter = 0;
                int counter2 = 0;
                for (int j=0;j<r2.Count;j++)
                {
                    if (m.key == r2[j].key)
                    {
                        counter++;
                        for (int i = 0; i < raktarkeszlet.Count; i++)
                        {
                            if (r2[j].termekkod == raktarkeszlet[i].termekkod)
                            {
                                if (raktarkeszlet[i].keszlet < r2[j].menny)
                                {
                                    teljesitheto = false;
                                    if (!varakozas.ContainsKey(raktarkeszlet[i].termekkod))
                                    {
                                        varakozas[raktarkeszlet[i].termekkod] = r2[j].menny - raktarkeszlet[i].keszlet;
                                    }
                                    else
                                    {
                                        varakozas[raktarkeszlet[i].termekkod] += (r2[j].menny - raktarkeszlet[i].keszlet);
                                    }
                                }
                                else
                                {
                                    counter2++;
                                    temp[i] = j;
                                }
                            }
                        }
                        
                    }
                }
                if (teljesitheto && counter == counter2)
                {
                    foreach(var t in temp)
                    {
                        raktarkeszlet[t.Key].keszlet -= r2[t.Value].menny;
                        ossz+= raktarkeszlet[t.Key].ar * r2[t.Value].menny;
                    }
                    
                    levelek.WriteLine($"{m.email};A rendelését két napon belül szállítjuk. A rendelés értéke: "+ ossz);
                    temp.Clear();
                }
                else
                {
                    levelek.WriteLine($"{m.email};A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.");
                }

            }
            foreach(var t in varakozas)
            
                {
                beszerzes.WriteLine($"{t.Key};{t.Value}");

            }
            levelek.Close();
            beszerzes.Close();



            Console.ReadKey();
        }

        
    }
}
