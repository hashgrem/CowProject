using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppCowProject
{
    public class Pre
    {
        private List<Piquet> listeDePiquets;
        private double graviteX;
        private double graviteY;


        public Pre(List<Piquet> listeDePiquets)
        {
            this.listeDePiquets = listeDePiquets;
        }
        public List<Piquet> ListePiquets
        {
            get { return listeDePiquets; }
            set { listeDePiquets = value; }
        }



        public double CalculAire()
        {
            double aire = 0;

            //Coordonnées des piquets.
            double x1, x2;
            double y1, y2;

            // Fermeture --> Combinaison entre le segment n-1 et le segment 0.
            double fermetureCloture = ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse * ListePiquets.ElementAt(0).Ordonnee - ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee;

            // Le 'sigma' de la formule de l'aire est traduit par une boucle FOR.
            // On parcourt les différentes coordonnées à l'aide de la méthode ElementAt().
            // Par exemple, 'ListePiquets.ElementAt(i).Abscisse' correspond à l'abscisse du piquet i.
            // Ainsi, on récupère l'abscisse et l'ordonnée du piquet i et i+1 à chaque itération.

            for (int i = 0; i < ListePiquets.Count - 1; i++)
            {
                //Coordonnées du piquet i et i+1.
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i + 1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i + 1).Ordonnee;


                aire += (x1 * y2) - (x2 * y1);

            }

            //On cloture le pré, puis on divise par 2 pour obtenir la valeur finale de l'aire
            aire += fermetureCloture;

            return aire / 2;

        }


        public string CentreGravite()
        {

            double x1, x2; // Coordonnées des piquets
            double y1, y2;

            double absCentreGravite = 0, ordoCentreGravite = 0; // Coordonnées du centre de gravité

            double aire;

            double totalX = 0, totalY = 0;

            double premierMembre;

            double partieGauche;

            double fermetureX, fermetureY;


            string res;

            aire = CalculAire();

            // Nous avons décomposé le calcul en plusieurs variables

            premierMembre = (6 * aire); // --> 6A
            partieGauche = 1 / premierMembre; // --> 1 / 6A

            // De la même manière que précedemment, on traduit le 'sigma' par une boucle FOR
            // et on récupère chaque coordonnée avec la méthode ElementAt().

            for (int i = 0; i < ListePiquets.Count - 1; i++)
            {
                //Coordonnées du piquet i et i+1.
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i + 1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i + 1).Ordonnee;

                absCentreGravite += (x1 + x2) * (x1 * y2 - x2 * y1);
                ordoCentreGravite += ((y1 + y2) * ((x1 * y2) - (x2 * y1)));

            }

            // On récupère les coordonnées de la combinaison entre le segment n-1 et le segment 0.
            // Distinctivement, car on veut obtenir l'abscisse et l'ordonnée du centre de gravité.

            fermetureX = (ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse + ListePiquets.ElementAt(0).Abscisse) * ((ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse * ListePiquets.ElementAt(0).Ordonnee) -
                (ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee));

            fermetureY = (ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee + ListePiquets.ElementAt(0).Ordonnee) * ((ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse * ListePiquets.ElementAt(0).Ordonnee)
                - (ListePiquets.ElementAt(0).Abscisse * ListePiquets.ElementAt(ListePiquets.Count - 1).Ordonnee));


            // Calcul final
            totalX = partieGauche * (absCentreGravite + fermetureX);
            totalY = partieGauche * (ordoCentreGravite + fermetureY);

            this.graviteX = totalX;
            this.graviteY = totalY;

            res = "(" + totalX + "," + totalY + ")";

            return res;

        }

        public string Appartenance()
        {
            double thetaI;
            // Coordonnées du centre de gravité.
            double centreGravX = this.graviteX;
            double centreGravY = this.graviteY;

            double x1, x2;
            double y1, y2;

            double vecteurGS1_x, vecteurGS1_y, vecteurGS2_x, vecteurGS2_y;

            double numerateur, denumerateur;

            double normeGS1, normeGS2;

            double somme = 0;

            string res;

            double determinant;

            // On cherche à calculer l'angle entre chaque segments, donc entre chaque piquets consécutifs.
            // On utilise donc une boucle for pour les parcourir.

            for (int i = 0; i < ListePiquets.Count - 1; i++)
            {
                //Coordonnées du piquet i et i+1.
                x1 = ListePiquets.ElementAt(i).Abscisse;
                x2 = ListePiquets.ElementAt(i + 1).Abscisse;

                y1 = ListePiquets.ElementAt(i).Ordonnee;
                y2 = ListePiquets.ElementAt(i + 1).Ordonnee;

                //Coordonnées des vecteurs GSi et GSi+1.
                vecteurGS1_x = x1 - centreGravX;
                vecteurGS1_y = y1 - centreGravY;

                vecteurGS2_x = x2 - centreGravX;
                vecteurGS2_y = y2 - centreGravY;

                // On calcule le produit scalire de ces 2 vecteurs
                // et on obtient le numérateur de la disivions.
                numerateur = vecteurGS1_x * vecteurGS2_x + vecteurGS1_y * vecteurGS2_y;


                //Calcul de la norme des vecteurs et du dénominateur.
                normeGS1 = (double)Math.Sqrt((vecteurGS1_x * vecteurGS1_x) + (vecteurGS1_y * vecteurGS1_y));
                normeGS2 = (double)Math.Sqrt((vecteurGS2_x * vecteurGS2_x) + (vecteurGS2_y * vecteurGS2_y));

                denumerateur = normeGS1 * normeGS2;

                // Calcul final
                thetaI = (double)Math.Acos(numerateur / denumerateur);


                // ----------------- Récupération de la valeur signée de l'angle: ------------------- //

                //Calcul du déterminant
                determinant = (vecteurGS1_x * vecteurGS2_y) - (vecteurGS1_y * vecteurGS2_x);


                //Prise en compte du signe de l'angle
                if (determinant < 0)
                    thetaI = -thetaI;

                somme += thetaI;

                // ---------------------------------------------------------------------------------- //

            } // FIN POUR 

            vecteurGS1_x = ListePiquets.ElementAt(ListePiquets.Count - 1).Abscisse - centreGravX;
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
