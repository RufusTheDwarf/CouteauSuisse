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
            /// Description : Traducteur de code morse en C# dans la console

            Menu();                                     // Affiche le menu

            byte choice = VerifyChoice();               // Vérifie que le choix est valide

            Console.Clear();

            switch (choice)
            {
                case 1:
                {
                    var morseCode = CreateDictionary();                     // crée le dictionnaire de code Morse
                    string text = CatchInput();                             // Lecture du input
                    bool valid = VerifyChar(text, morseCode);               // Vérifie que tous les caractères sont supportés

                    if (!valid)
                    {
                        text = ForceTrue(text, morseCode, valid);           // Forcer valide si c'est pas valide
                    }

                    string morse = ConvertToMorse(text, morseCode);         // Convertit le texte en code Morse
                    DisplayMorse(morse);                                    // Affiche le code Morse
                    ExecuteSound(morse);                                    // Exécute le son du code Morse
                    break;
                }

                case 2:
                case 3:
                    Console.WriteLine("Cette fonctionnalité n'est pas encore disponible.");
                    break;
            }

            choicerestart();
        }

        //#########################################################################################################################################################################
        //Partie code Morse

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
            Console.Write    (" Veuillez choisir une option : ");
        }

        //Vérifie que le choix est valide
        static byte VerifyChoice()
        {
            byte choice;
            while (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
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
            {'$', "...-..-"}, {'@', ".--.-."},
            {'\'', ".----."}
        };
            return morseCode;
        }

        //Lecture du input
        static string CatchInput()
        {
            Console.WriteLine("=== Convertisseur de texte en code Morse ===");
            Console.Write("Entrez un mot ou une phrase (chiffres 0-9 et lettres sans accents) : ");

            string text = Console.ReadLine()?.ToUpper() ?? "";

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
                Console.Write("Vous avez entré un caractère non supporté. Veuillez réessayer : ");
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

        //Exécuter le son du code Morse
        static void ExecuteSound(string morse)
        {
            const int dotDuration = 200;
            const int frequency = 800;

            foreach (char c in morse)
            {
                switch (c)
                {
                    case '.':
                        Console.Beep(frequency, dotDuration);
                        break;
                    case '-':
                        Console.Beep(frequency, dotDuration * 3);
                        break;
                    case ' ':
                        System.Threading.Thread.Sleep(dotDuration);
                        break;
                    case '/':
                        System.Threading.Thread.Sleep(dotDuration * 7);
                        break;
                }
            }
        }

        //#########################################################################################################################################################################
        //Partie convertisseur de bases

        //#########################################################################################################################################################################
        //partie sténographie

        //#########################################################################################################################################################################
        //continuer ?

        static void choicerestart()
        {
            Console.Write(" Voulez-vous redémarrer ? [O]oui [N]non :");
            string restart = Console.ReadLine()?.ToUpper() ?? "";

            while (restart != "O" && restart != "N")
            {
                Console.Write("Veuillez choisir entre [O] et [N] : ");
                restart = Console.ReadLine()?.ToUpper() ?? "";
            }

            if (restart == "O")
            {
                Menu();
            }
        }
    }
}