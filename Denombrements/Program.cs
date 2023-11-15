using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denombrements
{
    class Program
    {
        static void Saisie(ref int nombre, string requete)
        {
            bool valide = false;
            do
            {
                try
                {
                    Console.Write(requete);
                    nombre = int.Parse(Console.ReadLine());
                    valide = true;
                }
                catch
                {
                    Console.WriteLine("Erreur de saisie, renseignez un nombre.");
                }
                if (nombre < 0)
                {
                    Console.WriteLine("Erreur de saisie, renseignez un nombre positif.");
                }
            } while (!valide || nombre < 0);
        }

        static long Permutation(int ensemble)
        {
            long resultat = 1;
            for (int k = 1; k <= ensemble; k++)
            {
                resultat *= k;
            }
            return resultat;
        }

        static long Arrangement(int ensemble, int nbElements)
        {
            long resultat = 1;
            for (int k = (ensemble - nbElements + 1); k <= ensemble; k++)
            {
                resultat *= k;
            }
            return resultat;
        }

        static void Main(string[] args)
        {
            int choix = -1;
            do
            {
                int ensemble = 0, nbElements = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Permutation ...................... 1");
                        Console.WriteLine("Arrangement ...................... 2");
                        Console.WriteLine("Combinaison ...................... 3");
                        Console.WriteLine("Quitter .......................... 0");
                        Console.Write("Choix :                            ");
                        choix = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Erreur de saisie.");
                    }
                    if (choix != 1 && choix != 2 && choix != 3 && choix != 0)
                    {
                        Console.WriteLine("Renseignez une valeur parmi les choix proposés : ");
                    }
                } while (choix != 1 && choix != 2 && choix != 3 && choix != 0);
                
                switch (choix)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Saisie(ref ensemble, "Nombre total d'éléments à gérer : ");
                        Console.WriteLine(ensemble + "! = " + Permutation(ensemble));
                        break;

                    case 2:
                        Saisie(ref ensemble, "Nombre total d'éléments à gérer : ");
                        Saisie(ref nbElements, "Nombre d'éléments dans le sous-ensemble : ");
                        Console.WriteLine("A(" + ensemble + "/" + nbElements + ") = " + Arrangement(ensemble, nbElements));
                        break;

                    case 3:
                        Saisie(ref ensemble, "Nombre total d'éléments à gérer : ");
                        Saisie(ref nbElements, "Nombre d'éléments dans le sous-ensemble : ");
                        Console.WriteLine("C(" + ensemble + "/" + nbElements + ") = " + (Arrangement(ensemble, nbElements) / Permutation(nbElements)));
                        break;
                }
            } while (choix != 0);
            Console.ReadLine();
        }
    }
}
