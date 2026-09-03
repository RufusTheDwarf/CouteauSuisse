using System;

namespace CouteauSuisseCorrige
{
    internal class Program
    {
        static byte n;
        static bool valid;
        static string input = "";
        static string result = "";

        static void Main(string[] args)
        {
            n = BaseMenu();

            valid = VerifyBaseChoice(n);

            if (!valid)
            {
                ForceTrue();
            }

            CatchInput();
            ConvertInput();
            DisplayOutput();
        }

        // Menu de base
        static byte BaseMenu()
        {
            Console.WriteLine(" === Convertisseur de bases ===");
            Console.WriteLine(" 1. Décimal > Binaire");
            Console.WriteLine(" 2. Binaire > Décimal");
            Console.WriteLine(" 3. Binaire > Octal");
            Console.WriteLine(" 4. Octal > Binaire");
            Console.WriteLine(" Veuillez entrer votre choix : ");

            byte.TryParse(Console.ReadLine(), out byte BaseChoice);

            return BaseChoice;
        }

        // Vérifie que le choix est valide
        static bool VerifyBaseChoice(byte n)
        {
            bool valid = true;

            if (n < 1 || n > 4)
            {
                valid = false;
            }

            return valid;
        }

        // Force l'utilisateur à entrer un choix valide
        static bool ForceTrue()
        {
            while (!valid)
            {
                Console.WriteLine("Choix invalide. Veuillez réessayer : ");
                byte.TryParse(Console.ReadLine(), out n);
                valid = VerifyBaseChoice(n);
            }

            return valid;
        }

        // Lecture du input
        static void CatchInput()
        {
            Console.WriteLine("Veuillez entrer un nombre : ");
            input = Console.ReadLine() ?? "";
        }

        // Décide quelle fonction appeler avec input dedans
        static void ConvertInput()
        {
            switch (n)
            {
                case 1:
                    result = DecimalToBinary(input);
                    break;
                case 2:
                    result = BinaryToDecimal(input);
                    break;
                case 3:
                    result = BinaryToOctal(input);
                    break;
                case 4:
                    result = OctalToBinary(input);
                    break;
            }
        }

        // Fonctions qui font la conversion selon le choix
        static string DecimalToBinary(string value)
        {
            int decimalNumber = int.Parse(value);
            return Convert.ToString(decimalNumber, 2);
        }

        static string BinaryToDecimal(string value)
        {
            int decimalNumber = Convert.ToInt32(value, 2);
            return decimalNumber.ToString();
        }

        static string BinaryToOctal(string value)
        {
            int decimalNumber = Convert.ToInt32(value, 2);
            return Convert.ToString(decimalNumber, 8);
        }

        static string OctalToBinary(string value)
        {
            int decimalNumber = Convert.ToInt32(value, 8);
            return Convert.ToString(decimalNumber, 2);
        }

        // Affiche le résultat de la conversion
        static void DisplayOutput()
        {
            Console.WriteLine($"Résultat : {result}");
        }
    }
}