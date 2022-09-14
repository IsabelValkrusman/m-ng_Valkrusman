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

        public static List<Ese> LoeEsemed()
        {
            List<Ese> esemeteNimekiri = new List<Ese>();
            using (StreamReader sr= new StreamReader(@"../../../items.txt"))
            {
                while(!sr.EndOfStream)
                {
                    string[] rida = sr.ReadLine().Split(";");
                    Ese ese=new Ese(rida[0].ToString(), Int32.Parse(rida[1]));
                }
            }
            return esemeteNimekiri;
        }

        static Tegelane[] Mangijad(int tegelasekogus)
        {
            if (tegelasekogus < 2) throw new Exception();
            Tegelane[] mangijad =new Tegelane[tegelasekogus];
            for(int i = 0; i < tegelasekogus; i++)
            {
                Tegelane mangija = new Tegelane(Mangijate_loetelu());
                mangijad[i] = mangija;
            }
            List<Ese> esed = LoeEsemed();
            if (esed.Count<=0) throw new ArgumentOutOfRangeException();   
        }





        static public void Uus_mang(int kogus)
        {
            Tegelane[] mangija = Mangijad(kogus);
            Mangu_klass mang = new Mangu_klass(mangijad);
            foreach(Tegelane v in mang.SuurimaEsemeteArvuga())
            {
                Console.WriteLine(v.info());
            }
            Tegelane voitja = mang.suurimaPunktideArvuga();
            Console.WriteLine(voitja.info());  
            Console.WriteLine("Mängijal olid järgmised esed:");
            voitja.valjastaEsemed();

        }
       
        
    }
}
