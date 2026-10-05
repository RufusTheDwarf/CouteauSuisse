using System;
using System.Collections.Generic;

namespace CouteauSuisse
{
    internal class Program
    {
        private const int ACTION_MORSE  = 1;
        private const int ACTION_BASES  = 2;
        private const int ACTION_STENOGRAPHIE  = 3;

        static void Main(string[] args)
        {
            /// ETML 
            /// Auteur : Rafael Melo
            /// Date : 31/08/2026
            /// Description : Traducteur de code morse en C# dans la console

            bool restart = false;

            do
            {
                Menu();                                     // Affiche le menu

                byte choice = VerifyChoice();               // Vérifie que le choix est valide

                Console.Clear();

                switch (choice)
                {
                    case ACTION_MORSE:
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

                    case ACTION_BASES:
                        {
                            byte baseChoice = BaseMenu();                           //affiche le menu des bases

                            baseChoice = ForceBaseChoice(baseChoice);               //verrifie et éaisse passer si tout est bon

                            string input = CatchBaseInput();                        //prend ce que l'utilisateur à écrit
                            string result = ConvertInput(baseChoice, input);        //convetit dans une autre base
                            DisplayOutput(result);                                  //affiche la solution
                            break;
                        }

                    case ACTION_STENOGRAPHIE:
                        {
                            cryptchoice = StenographyMenu();                         //affiche le menu de la stéganographie

                            cryptchoice = ForceStenographyChoice(cryptchoice);       //verrifie et force l'utilisateur à choisir une option valide

                            cryptinput = CatchStenographyInput();                             //prend ce que l'utilisateur à écrit
                            cryptconvert


                            break;
                        }
                }

                restart = ChoiceRestart();

                if (restart)
                {
                    Console.Clear();
                }

            } while (restart == true);
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
            Console.WriteLine(" 2. Convertir des bases (Décimal, Binaire, Octal)");
            Console.WriteLine(" 3. Stéganographie : encodage et décodage");
            Console.Write(" Veuillez choisir une option : ");
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
            Console.WriteLine(" === Convertisseur de texte en code Morse ===");
            Console.Write(" Entrez un mot ou une phrase (chiffres 0-9 et lettres sans accents) : ");

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
                Console.Write(" Vous avez entré un caractère non supporté. Veuillez réessayer : ");
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
            Console.WriteLine($" Résultat en Morse : {morse}");
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

        // Menu de base
        static byte BaseMenu()
        {
            Console.WriteLine(" === Convertisseur de bases ===");
            Console.WriteLine(" 1. Décimal > Binaire");
            Console.WriteLine(" 2. Binaire > Décimal");
            Console.WriteLine(" 3. Binaire > Octal");
            Console.WriteLine(" 4. Octal > Binaire");
            Console.Write(" Veuillez entrer votre choix : ");

            byte.TryParse(Console.ReadLine(), out byte BaseChoice);

            return BaseChoice;
        }

        // Vérifie que le choix est valide
        static bool VerifyBaseChoice(byte baseChoice)
        {
            return baseChoice >= 1 && baseChoice <= 4;
        }

        // Force l'utilisateur à entrer un choix valide
        static byte ForceBaseChoice(byte baseChoice)
        {
            while (!VerifyBaseChoice(baseChoice))
            {
                Console.Write(" Choix invalide. Veuillez réessayer : ");
                byte.TryParse(Console.ReadLine(), out baseChoice);
            }

            return baseChoice;
        }

        // Lecture du input
        static string CatchBaseInput()
        {
            Console.Write(" Veuillez entrer un nombre : ");
            return Console.ReadLine() ?? "";
        }

        // Décide quelle fonction appeler avec l'input
        static string ConvertInput(byte baseChoice, string input)
        {
            switch (baseChoice)
            {
                case 1:
                    return DecimalToBinary(input);
                case 2:
                    return BinaryToDecimal(input);
                case 3:
                    return BinaryToOctal(input);
                case 4:
                    return OctalToBinary(input);
                default:
                    return "";
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
        static void DisplayOutput(string result)
        {
            Console.WriteLine($" Résultat : {result}");
        }

        //#########################################################################################################################################################################
        //partie sténographie



        //#########################################################################################################################################################################
        //continuer ?

        static bool ChoiceRestart()
        {
            Console.Write(" Voulez-vous redémarrer ? [O]oui [N]non :");
            string confirm = Console.ReadLine()?.ToUpper() ?? "";

            while (confirm != "O" && confirm != "N")
            {
                Console.Write(" Veuillez choisir entre [O] et [N] : ");
                confirm = Console.ReadLine()?.ToUpper() ?? "";
            }

            if (confirm == "O")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}