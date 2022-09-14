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

        public Tegelane SuurimaEsemeteArvuga()
        {
            List<Tegelane> voitjad = new List<Tegelane>(tegelased);
            voitjad.Sort();
            if(voitjad.Count > 0)
            {
                return voitjad[0];
            }
            throw new Exception();
        }

        public Tegelane SuurimaPunktideArvuga()
        {
            int parim = 0;
            Tegelane voitja = tegelased[0];
            foreach(var t in tegelased)
            {
                int arv = t.PunktideArv();
                if(arv>parim)
                {
                    parim = arv;
                    voitja = t;

                }
               
            }
            return voitja;
        }
            
    }
}
