using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mäng_Valkrusman
{
    internal class Tegelane:IÜksus, Comparable<Tegelane>
    {
        private List<string> nimi;
        List<Ese> esemeteNimekiri = new List<Ese>();

       

        public Tegelane()
        {
            this.esemeteNimekiri = new List<Ese>();
            this.nimi = new List<string>();
        }

        public Tegelane(List<string> nimi)
        {
            this.nimi = nimi;
        }

        public void LisaEse(Ese ese)
        {
            esemeteNimekiri.Add(ese);
        }

        public int punktideArv()
        {
            int summa = 0;

            foreach (Ese ese in esemeteNimekiri)
            {
                summa += ese.punktideArv();
            }
            return summa;
        }
        public string info()
        {

            return $"tegelase nimi on {this.nimi} tema ese on {this.esemeteNimekiri} ja punktide arv on{this.punktideArv()}";



        }
        
        public void väljastaEsemed()
        {
            foreach(Ese ese in esemeteNimekiri)
            {
                Console.WriteLine(ese.info());
            }
        }
        public int CompareTo(Tegelane other)
        {
            
            if(this.esemeteNimekiri.Count > other.esemeteNimekiri.Count)
            {
                return 1;
            }
            
            else
            {
                return -1;     
            }
        }
          
        private int EsesKogus() { return this.esemeteNimekiri.Count; }  
    }
   
        
}
