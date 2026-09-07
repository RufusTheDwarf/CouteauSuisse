using System;
using System.Collections.Generic;

namespace CouteauSuisse
{
    internal class Program
    {
        static byte n;
        static bool valid;

        static void Main(string[] args)
        {
            /// ETML 
            /// Auteur : Rafael Melo
            /// Date : 31/08/2026
            /// Description : Traducteur de code morse en C# (console)

            n = BaseMenu();

            valid = VerifyBaseChoice(n);

            if (!valid)
            {
                ForceTrue();
            }

            ClassifyPath(n);
        }

        static byte BaseMenu()
        {
            Console.WriteLine(" === Convertisseur de bases ===");
            Console.WriteLine(" 1. Décimal > Binaire");
            Console.WriteLine(" 2. Binaire > Décimal");
            Console.WriteLine(" 3. Binaire > Octal");
            Console.WriteLine(" 4. Octal > Binaire");
            Console.WriteLine(" Veuillez entrer votre choix : ");
            byte BaseChoice = byte.Parse(Console.ReadLine());
            return BaseChoice;
        }

        static bool VerifyBaseChoice(byte n)
        {
            bool valid = true;

            if (n < 1 || n > 4)
            {
               valid = false;
            }
            return valid;
        }

        static bool ForceTrue()
        {
            while (!valid)
            {
                Console.WriteLine("Choix invalide. Veuillez réessayer : ");
                n = byte.Parse(Console.ReadLine());
                valid = VerifyBaseChoice(n);
            }
            return true;
        }

        static void ClassifyPath(byte n)
        {
            switch (n)
            {
                case 1:
                    DecimalToBinary();
                    break;
                case 2:
                    BinaryToDecimal();
                    break;
                case 3:
                    BinaryToOctal();
                    break;
                case 4:
                    OctalToBinary();
                    break;
            }
        }

        static int DecimalToBinary()
        {
            Console.WriteLine("Veuillez entrer un nombre décimal : ");
            int decimalNumber = int.Parse(Console.ReadLine());
            string binaryNumber = Convert.ToString(decimalNumber, 2);
            Console.WriteLine($"Le nombre binaire correspondant est : {binaryNumber}");
            return decimalNumber;
        }

        static int BinaryToDecimal()
        {
            Console.WriteLine("Veuillez entrer un nombre binaire : ");
            string binaryNumber = Console.ReadLine();
            int decimalNumber = Convert.ToInt32(binaryNumber, 2);
            Console.WriteLine($"Le nombre décimal correspondant est : {decimalNumber}");
            return decimalNumber;
        }

        static int BinaryToOctal()
        {
            Console.WriteLine("Veuillez entrer un nombre binaire : ");
            string binaryNumber = Console.ReadLine();
            int decimalNumber = Convert.ToInt32(binaryNumber, 2);
            string octalNumber = Convert.ToString(decimalNumber, 8);
            Console.WriteLine($"Le nombre octal correspondant est : {octalNumber}");
            return decimalNumber;
        }

        static int OctalToBinary()
        {
            Console.WriteLine("Veuillez entrer un nombre octal : ");
            string octalNumber = Console.ReadLine();
            int decimalNumber = Convert.ToInt32(octalNumber, 8);
            string binaryNumber = Convert.ToString(decimalNumber, 2);
            Console.WriteLine($"Le nombre binaire correspondant est : {binaryNumber}");
            return decimalNumber;
        }
    }
}