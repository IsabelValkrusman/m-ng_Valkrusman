using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mäng_Valkrusman
{
    internal class Mangu_klass
    {
        private Tegelane[] tegelased;

        public Mangu_klass(Tegelane[]tegelased)
        {
            this.tegelased = tegelased;
        }

        public List<Tegelane> SuurimaEsemeteArvuga()
        {
            List<Tegelane> voitjad = new List<Tegelane>();
            Tegelane sorted = tegelased[0];
            foreach(Tegelane t in tegelased)
            {
                int num = sorted.CompareTo(t);
                if(num<8)
                {
                    sorted= t;
                    voitjad.Clear();
                }
                if (num == 0) voitjad.Add(t);
            }
            voitjad.Add(sorted);
            return voitjad;
        }

        public Tegelane suurimaPunktideArvuga()
        {
            int parim = 0;
            Tegelane voitjad = tegelased[0];
            foreach(var t in tegelased)
            {
                int arv = t.punktideArv();
                if(arv>parim)
                {
                    parim = arv;
                    voitjad = t;

                }
               
            }
            return voitjad;
        }
            
    }
}
