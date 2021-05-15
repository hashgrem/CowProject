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
            int nombreDePiquet;
            double abscisse;
            double ordonnee;
            Pre monPre;

            try
            {
                //On vérifie si l'utilisateur saisie au moins 3 piquets pour former un pré
                do
                {
                    Console.WriteLine("Saisir un nombre de piquets supérieur à 2\n");
                    nombreDePiquet = int.Parse(Console.ReadLine());
                }
                while (nombreDePiquet <= 2);

                monPre = new Pre(new List<Piquet>());

                for (int i = 0; i < nombreDePiquet; i++)
                {
                    Console.WriteLine("Saisir le piquet {0}", i + 1);
                    abscisse = double.Parse(Console.ReadLine());
                    ordonnee = double.Parse(Console.ReadLine());


                    Piquet monNouveauPiquet = new Piquet(abscisse, ordonnee)
                    {
                        Abscisse = abscisse,
                        Ordonnee = ordonnee
                    };

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
                Console.WriteLine("Erreur de saisie : {0}", e.Message);
            }
            
        }
    }
}
