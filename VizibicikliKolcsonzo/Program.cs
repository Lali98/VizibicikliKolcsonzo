using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VizibicikliKolcsonzo
{
    class Kolcsonzes
    {
        public string nev { get; set; }
        public char jazon { get; set; }
        //public int eora { get; set; }
        //public int eperc { get; set; }
        //public int vora { get; set; }
        //public int vperc { get; set; }
        public string e { get; set; }
        public string v { get; set; }

        public Kolcsonzes(string bemenet)
        {
            string[] data = bemenet.Split(';');
            nev = data[0];
            jazon = char.Parse(data[1]);
            //eora = int.Parse(data[2]);
            //eperc = int.Parse(data[3]);
            //vora = int.Parse(data[4]);
            //vperc = int.Parse(data[5]);

            e = $"{int.Parse(data[2]):00}:{int.Parse(data[3]):00}";
            v = $"{int.Parse(data[4]):00}:{int.Parse(data[5]):00}";
        }
    }

    class Adatbazis
    {
        public List<Kolcsonzes> kolcsonzes = new List<Kolcsonzes>();
        public void beolvas(string filename)
        {
            string[] file = File.ReadAllLines(filename);
            for (int i = 1, n = file.Length; i < n; i++)
            {
                Kolcsonzes kolcsonzes1 = new Kolcsonzes(file[i]);
                kolcsonzes.Add(kolcsonzes1);
            }
        }

        string feladat(int feladat)
        {
            return $"{feladat}. feladat:";
        }

        public void feladat5()
        {
            Console.WriteLine($"{feladat(5)} Napi kölcsönzés száma: {kolcsonzes.Count}");
        }
        public void feladat6()
        {
            Console.Write($"{feladat(6)} Kérek egy nevet: ");
            string nev = Console.ReadLine();
            Console.WriteLine($"\t{nev} kölcsönzései:");
            List<Kolcsonzes> a = new List<Kolcsonzes>();
            for (int i = 0, n = kolcsonzes.Count; i < n; i++)
            {
                if (nev == kolcsonzes[i].nev)
                {
                    a.Add(kolcsonzes[i]);
                }
            }
            if (a.Count != 0)
            {
                foreach (var item in a)
                {
                    Console.WriteLine($"\t{item.e}-{item.v}");
                }
            }
            else
            {
                Console.WriteLine("\tNem volt ilyen nevű kölcsönzö!");
            }
        }
        public void feladat7()
        {
            Console.Write($"{feladat(7)} Adjon meg egy időpontot óra:perc alakban: ");
            string[] oraperc = Console.ReadLine().Split(':');
            for (int i = 0, n = kolcsonzes.Count; i < n; i++)
            {
                
            }
        }
        public void feladat8()
        {
            int ossz_bevetel = 0;
            Console.WriteLine($"{feladat(8)} A nepi bevétel {ossz_bevetel} Ft");
        }
        public void feladat9()
        {
            StreamWriter sw = new StreamWriter("F.txt");
            for (int i = 0, n = kolcsonzes.Count; i < n; i++)
            {
                if (kolcsonzes[i].jazon == 'F')
                {
                    sw.WriteLine($"{kolcsonzes[i].e} - {kolcsonzes[i].v} : {kolcsonzes[i].nev}");
                }
            }
            sw.Close();
        }
        public void feladat10()
        {
            Console.WriteLine($"{feladat(10)} Statisztika");
            Dictionary<char, int> szotar = new Dictionary<char, int>();
            for (int i = 0, n = kolcsonzes.Count; i < n; i++)
            {
                if (!szotar.ContainsKey(kolcsonzes[i].jazon))
                {
                    szotar.Add(kolcsonzes[i].jazon, 1);
                }
                else
                {
                    szotar[kolcsonzes[i].jazon]++;
                }
            }
            var list = szotar.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                Console.WriteLine($"\t{key} - {szotar[key]}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Adatbazis feladat = new Adatbazis();

            feladat.beolvas("kolcsonzesek.txt");
            feladat.feladat5();
            feladat.feladat6();
            feladat.feladat7();
            feladat.feladat8();
            feladat.feladat9();
            feladat.feladat10();

            Console.ReadKey();
        }
    }
}
