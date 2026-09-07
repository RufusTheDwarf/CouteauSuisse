using System;
using System.Collections.Generic;

namespace CouteauSuisse
{
    internal class Program
    {
        static Dictionary<char, string> morseCode;
        static string text;
        static string morse;
        static bool valid;

        static void Main(string[] args)
        {
            /// ETML 
            /// Auteur : Rafael Melo
            /// Date : 31/08/2026
            /// Description : Traducteur de code morse en C# dans la console

            Menu();                                     // Affiche le menu

            byte Choice = VerifyChoice();               // Vérifie que le choix est valide

            Console.Clear();

            morseCode = CreateDictionary();             // Crée le dictionnaire de code Morse

            text = CatchInput();                        // Lecture du input

            bool valid = VerifyChar(text, morseCode);        // Vérifie que tous les caractères sont supportés

            if (!valid)
            {
                text = ForceTrue(text, morseCode, valid);
            }

            morse = ConvertToMorse(text, morseCode);    // Convertit le texte en code Morse

            DisplayMorse(morse);                        // Affiche le code Morse
        }

        //Menu de base
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
            Console.WriteLine(" Veuillez choisir une option : ");
        }

        //Vérifie que le choix est valide
        static byte VerifyChoice()
        {
            byte choice;
            while (!byte.TryParse(Console.ReadLine(), out choice) || choice != 1)
            {
                Console.WriteLine(" Choix indisponible, veuillez réessayer. ");
            }
            return choice;
        }

        //Crée le dictionnaire de code Morse
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

        //Lecture du input
        static string CatchInput()
        {
            Console.WriteLine("=== Convertisseur de texte en code Morse ===");
            Console.WriteLine("Entrez un mot ou une phrase (chiffres 0-9 et lettres sans accents) : ");

            string text = Console.ReadLine().ToUpper();

            return text;
        }

        // vérifier d'abord que tous les caractères sont supportés
        static bool VerifyChar(string text, Dictionary<char, string> morseCode)
        {
            bool valid = true;

            foreach (char c in text)
            {
                if (c != ' ' && !morseCode.ContainsKey(c))
                {
                    valid = false;
                }
            }

            return valid;
        }

        //Forcer vrai
        static string ForceTrue(string text, Dictionary<char, string> morseCode, bool valid)
        {
            while (!valid)
            {
                Console.WriteLine("Vous avez entré un caractère non supporté. Veuillez réessayer : ");
                text = Console.ReadLine()?.ToUpper() ?? "";
                valid = VerifyChar(text, morseCode);
            }
            return text;
        }

        //Convertir le texte en code Morse
        static string ConvertToMorse(string text, Dictionary<char, string> morseCode)
        {
            string morse = "";

            foreach (char c in text)
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

        //Afficher le code Morse
        static void DisplayMorse(string morse)
        {
            Console.WriteLine($"Résultat en Morse : {morse}");
        }
    }
}