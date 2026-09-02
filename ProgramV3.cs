using System;
using System.Collections.Generic;

namespace CouteauSuisse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// ETML 
            /// Auteur : Rafael Melo
            /// Date : 31/08/2026
            /// Description : Traducteur de code morse en C# (console)

            Menu();

            byte choix = ReadChoice();

            Console.Clear();

            Dictionary<char, string> morseCode = CreateDictionary();

            string texte = CatchInput();

            bool valide = VerifyChar(texte, morseCode);

            if (!valide)
            {
                ForceTrue(texte, morseCode);
            }

            string morse = ConvertToMorse(texte, morseCode);

            DisplayMorse(morse);
        }

        static void Menu()
        {
            Console.WriteLine(" ╔═════════════════════════════════════╗ ");
            Console.WriteLine(" ║                                     ║ ");
            Console.WriteLine(" ║           Couteau suisse            ║ ");
            Console.WriteLine(" ║                                     ║ ");
            Console.WriteLine(" ╚═════════════════════════════════════╝ ");
            Console.WriteLine(" === Couteau Suisse – Utilitaires ===");
            Console.WriteLine(" 1. Convertir du texte en code Morse");
            Console.WriteLine(" 2. (à venir)");
            Console.WriteLine(" 3. (à venir)");
            Console.WriteLine("Veuillez choisir une option : ");
        }

        static byte ReadChoice()
        {
            byte choix;
            while (!byte.TryParse(Console.ReadLine(), out choix) || choix != 1)
            {
                Console.WriteLine("Choix indisponible, veuillez réessayer. ");
            }
            return choix;
        }

        static Dictionary<char, string> CreateDictionary()
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>()
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
                {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
                {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."},
                {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
                {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
                {'8', "---.."}, {'9', "----."},
                {'.', ".-.-.-"}, {',', "--..--"}, {':', "---..."},
                {'?', "..--.."}, {'!', "-.-.--"}, {'-', "-....-"},
                {'/', "-..-."}, {'(', "-.--."}, {')', "-.--.-"},
                {'&', ".-..."}, {';', "-.-.-."}, {'=', "-...-"},
                {'+', ".-.-."}, {'_', "..--.-"}, {'"', ".-..-."},
                {'$', "...-..-"}, {'@', ".--.-."}
            };

            return morseCode;
        }

        static string CatchInput()
        {
            Console.WriteLine("=== Convertisseur de texte en code Morse ===");
            Console.WriteLine("Entrez un mot ou une phrase (chiffres 0-9 et lettres sans accents) : ");

            string texte = Console.ReadLine().ToUpper();

            return texte;
        }

        // vérifier d'abord que tous les caractères sont supportés
        static bool VerifyChar(string texte, Dictionary<char, string> morseCode)
        {
            bool valide = true;

            foreach (char c in texte)
            {
                if (c != ' ' && !morseCode.ContainsKey(c)) //Le caractère '{c}' n'est pas supporté.
                {
                    valide = false;
                }
            }

            return valide;
        }

        static bool ForceTrue(string texte, Dictionary<char, string> morseCode)
        {
            bool valide = VerifyChar(texte, morseCode);
            
            while (!valide)
            {
                Console.WriteLine("Vous avez entré un caractère non supporté. Veuillez réessayer : ");
                texte = Console.ReadLine().ToUpper();
                valide = VerifyChar(texte, morseCode);
            }
            return true;
        }

        static string ConvertToMorse(string texte, Dictionary<char, string> morseCode)
        {
            string morse = "";

            foreach (char c in texte)
            {
                if (c == ' ')
                {
                    morse += "/ ";
                    continue;
                }

                if (morseCode.ContainsKey(c))
                {
                    morse += morseCode[c] + " ";
                }
            }

            return morse;
        }

        static void DisplayMorse(string morse)
        {
            Console.WriteLine($"Résultat en Morse : {morse}");
        }
    }
}
