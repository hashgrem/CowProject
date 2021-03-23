using System;
using System.Collections.Generic;

namespace ConsoleAppCowProject
{
    class Program
    {
        static void Main(string[] args)
        {
            float aire;
            string centreGravite;

           
            Pre monPre = new Pre(new List<Piquet>());
            Console.WriteLine("Saisir un nombre de piquets \n");
            //try catch
            int nombreDePiquet = int.Parse(Console.ReadLine()); 
            float abscisse;
            float ordonnee;

            for (int i=0; i< nombreDePiquet ;i++)
            {
                Console.WriteLine("Saisir le piquet {0}", i+1);
                abscisse = float.Parse(Console.ReadLine());
                ordonnee = float.Parse(Console.ReadLine());


                Piquet monNouveauPiquet = new Piquet(abscisse, ordonnee);
                monNouveauPiquet.Abscisse = abscisse;
                monNouveauPiquet.Ordonnee = ordonnee;

                monPre.ListePiquets.Add(monNouveauPiquet);

            }

            aire = Math.Abs(monPre.CalculAire());
            Console.WriteLine(aire);

            centreGravite = monPre.CentreGravite();
            Console.WriteLine("Centre de gravité: {0}",centreGravite);
            


         
        }
    }
}
