﻿using System;
using System.Collections.Generic;

namespace ConsoleAppCowProject
{
    class Program
    {
        static void Main(string[] args)
        {
           
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

            monPre.Affiche();
            float res = monPre.CalculAire();
            Console.WriteLine(res);


         
        }
    }
}