﻿using System;
using System.Collections.Generic;

namespace ConsoleAppCowProject
{
    class Program
    {
        static void Main(string[] args)
        {
            double aire;
            string centreGravite;
            string appartenancePre;

            try
            {
                Console.WriteLine("Saisir un nombre de piquets \n");
                Pre monPre = new Pre(new List<Piquet>());

                double abscisse;
                double ordonnee;
                int nombreDePiquet = int.Parse(Console.ReadLine());

                for (int i = 0; i < nombreDePiquet; i++)
                {
                    Console.WriteLine("Saisir le piquet {0}", i + 1);
                    abscisse = double.Parse(Console.ReadLine());
                    ordonnee = double.Parse(Console.ReadLine());


                    Piquet monNouveauPiquet = new Piquet(abscisse, ordonnee);
                    monNouveauPiquet.Abscisse = abscisse;
                    monNouveauPiquet.Ordonnee = ordonnee;

                    monPre.ListePiquets.Add(monNouveauPiquet);

                }

                aire = Math.Abs(monPre.CalculAire());
                Console.WriteLine(aire);

                centreGravite = monPre.CentreGravite();
                Console.WriteLine("Centre de gravité: {0}", centreGravite);

                appartenancePre = monPre.Appartenance();
                Console.WriteLine(appartenancePre);
            }
            catch(Exception e)
            {
                Console.WriteLine("Il faut entrer un nombre : {0}", e.Message);
            }
            
        }
    }
}
