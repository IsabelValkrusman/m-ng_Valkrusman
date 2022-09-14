using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace mäng_Valkrusman
{
    internal static class Peaklass
    {

        public static List<Ese> LoeEsemed(string failiNimi)
        {
            List<Ese> esemeteNimekiri = new List<Ese>();
            using (StreamReader sr = new StreamReader(failiNimi))
            {
                while (!sr.EndOfStream)
                {
                    string[] rida = sr.ReadLine().Split(";");
                    Ese ese = new Ese(rida[0].ToString(), Int32.Parse(rida[1]));
                    esemeteNimekiri.Add(ese);
                }
            }
            return esemeteNimekiri;
        }

        static Tegelane[] LooMangijad(int tegelasekogus,List<Ese> esemed, List<string> nimed)
        { 
            Tegelane[] tegelased = new Tegelane[tegelasekogus];
           
            for (int i = 0; i < tegelasekogus; i++)
            {
                Random r = new Random();
                // leiame suvalise arvu vahemikus 2 - 10, kuna 11 pole kaasa arvatud
                int esemeteArv = r.Next(2, 11);
                // muudame esemete järjekorda, lahenduse leidsin https://www.techiedelight.com/randomize-a-list-in-csharp/
                esemed.OrderBy(_ => r.Next(0, esemed.Count));
                // leiame suvalise nime
                string nimi = nimed[r.Next(0, nimed.Count)];
                Tegelane tegelane = new Tegelane(nimi);

                for (int j = 0; j < esemed.Count; j++)
                {
                    // kontrollime, et praeguste esemete arv oleks väiksem, kui lubatud esemete arv. vastasel juhul lähme tsüklist välja
                    if(j <= esemeteArv)
                    {
                        tegelane.LisaEse(esemed[j]);
                    }
                    else
                    {
                        break;
                    }
                    
                }
                // lisame tegelase massiivi
                tegelased[i] = tegelane;
            }

            return tegelased;
        }





        static public void Uus_mang(int kogus)
        {
            List<Ese> esemed = LoeEsemed(@"..\..\..\items.txt");
            List<String> nimed = new List<string>();
            nimed.Add("a");
            nimed.Add("b");
            nimed.Add("c");
            nimed.Add("d");
            nimed.Add("e");
            nimed.Add("f");
            nimed.Add("g");
            Tegelane[] tegelased = LooMangijad(kogus, esemed, nimed);

            Mangu_klass mang = new Mangu_klass(tegelased);

            foreach(Tegelane tegelane in tegelased)
            {
                Console.WriteLine(tegelane.Info());
                tegelane.VäljastaEsemed();
            }

            Tegelane suurimateEsemetega = mang.SuurimaEsemeteArvuga();
            Console.WriteLine(suurimateEsemetega.Info());

            Tegelane suurimatePunktidega = mang.SuurimaPunktideArvuga();
            Console.WriteLine(suurimatePunktidega.Info());
        }
       
        
    }
}
