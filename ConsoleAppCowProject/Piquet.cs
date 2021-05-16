using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCowProject
{
    public class Piquet
    {
        private double abscisse;
        private double ordonnee;

        // Création:
        //      - constructeur de piquet
        //      - getter & setter Abscisse
        //      - getter & setter Ordonnée
        public Piquet(double abscisse, double ordonnee)
        {
            this.abscisse = abscisse;
            this.ordonnee = ordonnee;

        }

        public double Abscisse
        {
            get { return abscisse; }

            set { abscisse = value; }
        }

        public double Ordonnee
        {
            get { return ordonnee; }

            set { ordonnee = value; }

        }

    }
}
