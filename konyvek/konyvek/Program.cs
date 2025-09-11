using System.IO;
using System.Runtime.InteropServices;
namespace konyvek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Konyv> Books = new List<Konyv>();

            foreach (var i in File.ReadAllLines("kiadas2.txt"))
            {
                Books.Add(new Konyv(i));
            }

            Console.Write("2. feladat:\r\nSzerző: ");
            string name = Console.ReadLine();
            int numb = 0;
            foreach (var book in Books)
            {
                if (book.Who.Contains(name))
                {
                    numb++;
                }
            }

            if (numb > 0)
            {
                Console.WriteLine($"{numb} könyvkiadás");
            }
            else
            {
                Console.WriteLine("Nem adtak ki");
            }

            int all = 0;
            int many = 0;
            foreach (var book in Books)
            {
                if (book.TheCount > all)
                {
                    all = book.TheCount;
                }
            }
            foreach (var book in Books)
            {
                if (book.TheCount == all)
                {
                    many++;
                }
            }
            Console.WriteLine("3. feladat:\r\nLegnagyobb példányszám: " + all + ", előfordult " + many + " alkalommal");

            Console.WriteLine("4. feladat:");
            foreach (var book in Books)
            {   
                if (book.TheCount >= 40000 && book.Where == "kf")
                {
                    Console.WriteLine($"{book.Year}/{book.AFourth}. {book.Who}");
                    break;
                }
            }

            List<int> years = new List<int>();
            foreach (var book in Books)
            {
                if (!years.Contains(book.Year))
                {
                    years.Add(book.Year);
                }
            }

            StreamWriter sw = new StreamWriter("tabla.html");
            sw.WriteLine("<table><tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi kiadás</th><th>Külföldi példányszám</th></tr>");

            
            Console.WriteLine("5. feladat:\r\nÉv\tMagyar kiadás\tMagyar példányszám\tKülföldi kiadás\tKülföldi példányszám");
            foreach (var year in years)
            {
                int[] db = new int[4];
                foreach (var book in Books)
                {  
                    if (book.Year == year)
                    {
                        if (book.Where == "ma")
                        {
                            db[0]++;
                            db[1] += book.TheCount;
                        }
                        else
                        {
                            db[2]++;
                            db[3] += book.TheCount;
                        }
                    }
                }

                Console.WriteLine(year + "\t\t" + db[0] + "\t\t" + db[1] + "\t\t" + db[2] + "\t\t" + db[3]);
                sw.WriteLine($"<tr><td>{year}</td><td>{db[0]}</td><td>{db[1]}</td><td>{db[2]}</td><td>{db[3]}</td></tr>");

            }
            sw.Write("</table>");
            sw.Close();
            Console.WriteLine("6. feladat:\r\nLegalább kétszer, nagyobb példányszámban újra kiadott könyvek:");
            List<Konyv> list = new List<Konyv>() { Books[0] };
            foreach (var book in Books)
            {
                bool van = false;
                foreach (var data in list)
                {
                    if (data.Who == book.Who)
                    {
                        van = true; break;
                    }
                }
                if (!van)
                {
                    list.Add(book);
                }
            }
            
            foreach (var e in list)
            {
                int yes = 0;
                foreach (var book in Books)
                {
                    if (book.Who == e.Who && book.TheCount > e.TheCount)
                    {
                        yes++;
                    }
                }
                if (yes >= 2)
                {
                    Console.WriteLine(e.Who);
                }
            }

            Console.ReadKey();
        }
    }
}
