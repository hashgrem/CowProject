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



        public float CalculAire()
        {      
            float aire=0;
            float x1, x2;
            float y1, y2;

            //Liaison entre le segment 0 et n-1
            float fermetureCloture = ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count-1).Ordonnee - ListePiquets.ElementAt(ListePiquets.Count-1).Abscisse * ListePiquets.ElementAt(0).Ordonnee;

            Console.WriteLine("Abcisse du dernier : {0} et ordonnee du dernier {1} ", ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse, ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee);



            for (int i=0; i < ListePiquets.Count-1; i++)
            {
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i+1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i+1).Ordonnee;

                aire += (x1 * y2) - (x2 * y1);
            }

            //modulo n 
            aire += fermetureCloture%ListePiquets.Count;
            
            return aire/2;

            /* 
             * Voir : quand on calcul avec le segment n-1, ajouté le premier segment, donc quand 4 : 
             * segment 3 calculé avec segment4.Abcisse + abcisse du segment 0 .. 
             * Mettre if(i == ListePiquets.Count-1){ajouté au segment i+1 l'abcisse et ordonnee du segment 0}
             * */

        }

        

    }
}
