using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCowProject
{
    public class Piquet
    {
        private float abscisse;
        private float ordonnee;

        public Piquet(float abscisse, float ordonnee)
        {
            this.abscisse = abscisse;
            this.ordonnee = ordonnee;

        }

        public float Abscisse
        {
            get {  return abscisse; }

            set { abscisse = value; }
        }

        public float Ordonnee
        {
            get { return ordonnee; }

            set { ordonnee = value; }

        }

    }
}
