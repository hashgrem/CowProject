using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCowProject
{
    /// <summary>
    /// Classe Piquet contenant une abscisse et une ordonnée
    /// </summary>
    public class Piquet
    {
        private double abscisse;
        private double ordonnee;

        /// <summary>
        /// Création:
        //      - constructeur de piquet
        //      - getter & setter Abscisse
        //      - getter & setter Ordonnée
        /// </summary>
        /// <param name="abscisse"></param>
        /// <param name="ordonnee"></param>
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
