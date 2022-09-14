using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mäng_Valkrusman
{
    internal class Ese:IÜksus
    {
         string nimetus;
         int arv;

      public Ese (string nimetus, int arv)
      {
            this.nimetus = nimetus;
            this.arv = arv;
      }
      
       public int punktideArv() { return arv; }
       public string info() { return nimetus; }



    }
}

