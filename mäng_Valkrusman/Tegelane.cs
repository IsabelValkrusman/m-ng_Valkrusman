using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mäng_Valkrusman
{
    internal class Tegelane:IÜksus, IComparable<Tegelane>
    {
        private string nimi;
        List<Ese> esemeteNimekiri = new List<Ese>();

       

        public Tegelane()
        {
            this.esemeteNimekiri = new List<Ese>();
            this.nimi = "";
        }

        public Tegelane(string nimi)
        {
            this.nimi = nimi;
        }

        public void LisaEse(Ese ese)
        {
            esemeteNimekiri.Add(ese);
        }

        public int PunktideArv()
        {
            int summa = 0;

            foreach (Ese ese in esemeteNimekiri)
            {
                summa += ese.PunktideArv();
            }
            return summa;
        }
        public string Info()
        {

            return $"tegelase nimi on {this.nimi} tal on {this.esemeteNimekiri.Count} eset ja punktide arv on {this.PunktideArv()}";



        }
        
        public void VäljastaEsemed()
        {
            foreach(Ese ese in esemeteNimekiri)
            {
                Console.WriteLine(ese.Info());
            }
        }
    
        public int CompareTo(Tegelane other)
        {
            if (this.esemeteNimekiri.Count > other.esemeteNimekiri.Count)
            {
                return -1;
            }
            else if(this.esemeteNimekiri.Count < other.esemeteNimekiri.Count) 
            {
                return 1;
            } else
            {
                return 0;
            }

        }
    }
   
        
}
