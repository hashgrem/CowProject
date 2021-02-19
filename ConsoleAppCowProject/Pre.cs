using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppCowProject
{
    public class Pre
    {
        private List<Piquet> listeDePiquets;
        private float aire;

        public Pre (List<Piquet> listeDePiquets)
        {
            this.listeDePiquets = listeDePiquets;
        }
        public List<Piquet> ListePiquets {
            get { return listeDePiquets; }
            set { listeDePiquets = value; }
        }

        public void Affiche()
        {

            for (int i=0; i < ListePiquets.Count ;i++)
            {
                //Console.WriteLine("abscisse {0} | ordonnee {1}", ListePiquets.ElementAt(1).Abscisse, ListePiquets.ElementAt(1).Ordonnee);

            }

           for (int i = 0; i < ListePiquets.Count-1; i++)
            {
              //  Console.WriteLine((ListePiquets.ElementAt(i).Abscisse * ListePiquets.ElementAt(i + 1).Ordonnee) - (ListePiquets.ElementAt(i + 1).Abscisse * ListePiquets.ElementAt(i).Ordonnee));
                Console.WriteLine(ListePiquets.ElementAt(i).Abscisse * ListePiquets.ElementAt(i+1).Ordonnee);
                Console.WriteLine(ListePiquets.ElementAt(i+1).Abscisse * ListePiquets.ElementAt(i).Ordonnee);

            }

        }

        public float CalculAire()
        {
            float aire2=0;
            float x1, x2;
            float y1, y2;

            for(int i=0; i < ListePiquets.Count-1; i++)
            {
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i+1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i+1).Ordonnee;

                aire2 = aire2 + ( ( x1 * y2 ) - (x2 * y1));
                

            }

            float aireFinale = 0;
            aireFinale = 0.5f * aire2;

            return aireFinale;

        }
        

    }
}
