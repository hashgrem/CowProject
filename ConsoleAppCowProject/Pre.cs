using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppCowProject
{
    public class Pre
    {
        private List<Piquet> listeDePiquets;
        private double aire;
        private double graviteX;
        private double graviteY;


        public Pre (List<Piquet> listeDePiquets)
        {
            this.listeDePiquets = listeDePiquets;
        }
        public List<Piquet> ListePiquets {
            get { return listeDePiquets; }
            set { listeDePiquets = value; }
        }



        public double CalculAire()
        {      
            double aire=0;
            double x1, x2;
            double y1, y2;

            //Liaison entre le segment 0 et n-1
            double fermetureCloture = ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse * ListePiquets.ElementAt(0).Ordonnee - ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee;


            for (int i=0; i < ListePiquets.Count-1; i++)
            {
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i+1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i+1).Ordonnee;


                aire += (x1 * y2) - (x2 * y1);

            }

            aire += fermetureCloture;
            
            return aire/2;

        }


        public string CentreGravite()
        {

            double x1, x2;
            double y1, y2;

            double absCentreGravite = 0, ordoCentreGravite = 0, aire;

            double totalX=0, totalY=0;

            double premierMembre;

            double partieGauche;

            double fermetureX, fermetureY;


            string res;

            aire = CalculAire();

            premierMembre = (6*aire);
            partieGauche = 1 / premierMembre;

           

            for (int i = 0; i < ListePiquets.Count-1; i++)
            {
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i + 1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i + 1).Ordonnee;

                absCentreGravite += (x1 + x2) * (x1 * y2 - x2 * y1);
                ordoCentreGravite += ((y1 + y2) * ((x1 * y2) - (x2 * y1)));

            }


            fermetureX = (ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse + ListePiquets.ElementAt(0).Abscisse) * ((ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse * ListePiquets.ElementAt(0).Ordonnee) -
                (ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee));

            fermetureY = (ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee + ListePiquets.ElementAt(0).Ordonnee) * ((ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse * ListePiquets.ElementAt(0).Ordonnee) 
                - (ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee));

    

            totalX = partieGauche *(absCentreGravite + fermetureX);
            totalY = partieGauche * (ordoCentreGravite + fermetureY);

            this.graviteX = totalX;
            this.graviteY = totalY;

            res = "("+totalX+","+totalY+")"; 

            return res;

        }
        
        public string Appartenance()
        {
            double thetaI;
            double centreGravX = this.graviteX;
            double centreGravY = this.graviteY;

            double x1, x2;
            double y1, y2;

            double vecteurGS1_x, vecteurGS1_y,  vecteurGS2_x, vecteurGS2_y;

            double numerateur, denumerateur;

            double normeGS1, normeGS2;

            double somme = 0;

            string res;

            double determinant;
         
            for (int i = 0; i < ListePiquets.Count - 1; i++)
            {
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i + 1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i + 1).Ordonnee;

                vecteurGS1_x = x1 - centreGravX;
                vecteurGS1_y = y1 - centreGravY;

                vecteurGS2_x = x2 - centreGravX;
                vecteurGS2_y = y2 - centreGravY;

                numerateur = vecteurGS1_x * vecteurGS2_x + vecteurGS1_y * vecteurGS2_y;


                //Calcul de la norme des vecteurs
                normeGS1 = (double)Math.Sqrt((vecteurGS1_x * vecteurGS1_x) + (vecteurGS1_y * vecteurGS1_y));
                normeGS2 = (double)Math.Sqrt((vecteurGS2_x * vecteurGS2_x) + (vecteurGS2_y * vecteurGS2_y));

                denumerateur = normeGS1 * normeGS2;

                //Calcul du déterminant
                determinant = (vecteurGS1_x * vecteurGS2_y) - (vecteurGS1_y * vecteurGS2_x);

                
                
                thetaI = (double)Math.Acos(numerateur / denumerateur);

                //Prise en compte du signe de l'angle
                if (determinant < 0)
                    thetaI = -thetaI;

                somme += thetaI;

            }

            vecteurGS1_x = ListePiquets.ElementAt(ListePiquets.Count-1).Abscisse - centreGravX;
            vecteurGS1_y = ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee - centreGravY;

            vecteurGS2_x = ListePiquets.ElementAt(0).Abscisse - centreGravX;
            vecteurGS2_y = ListePiquets.ElementAt(0).Ordonnee - centreGravY;

            normeGS1 = Math.Sqrt((vecteurGS1_x * vecteurGS1_x) + (vecteurGS1_y * vecteurGS1_y));
            normeGS2 = Math.Sqrt((vecteurGS2_x * vecteurGS2_x) + (vecteurGS2_y * vecteurGS2_y));

            denumerateur = normeGS1 * normeGS2;

            numerateur = vecteurGS1_x * vecteurGS2_x + vecteurGS1_y * vecteurGS2_y;

            thetaI = Math.Acos(numerateur / denumerateur);

            somme += thetaI;


            if (somme != 0)
                res = "La vache est dans le pré";

            else
                res = "Attention, la vache est hors du pré";

            return res;

        } 
    }
}
