using System;
using System.Collections.Generic;
    class TicTacToe
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer;
        private char computerPlayer;

        public TicTacToe()
        {
            InitializeBoard();
            currentPlayer = 'X'; // Починає перший гравець
            computerPlayer = 'O'; // Комп'ютер
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        private void PrintBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private bool IsBoardFull()
        {
            foreach (char cell in board)
            {
                if (cell == '-')
                    return false;
            }
            return true;
        }

        private bool CheckWin()
        {
            // Перевірка рядків
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '-' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;
            }

            // Перевірка стовпців
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != '-' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                    return true;
            }

            // Перевірка діагоналей
            if (board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;

            if (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }

        public void PlayWithComputer()
        {
            Console.WriteLine("Welcome to Tic Tac Toe with Computer!");
            InitializeBoard();
            PrintBoard();

            while (true)
            {
                int row, col;

                if (currentPlayer == 'X')
                {
                    Console.WriteLine("Your turn (enter row and column):");
                    string[] input = Console.ReadLine().Split();
                    row = int.Parse(input[0]);
                    col = int.Parse(input[1]);
                }
                else
                {
                    do
                    {
                        row = random.Next(0, 3);
                        col = random.Next(0, 3);
                    } while (board[row, col] != '-');
                }

                if (board[row, col] == '-')
                {
                    board[row, col] = currentPlayer;
                    PrintBoard();

                    if (CheckWin())
                    {
                        Console.WriteLine($"{currentPlayer} wins!");
                        break;
                    }

                    if (IsBoardFull())
                    {
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Cell already taken! Try again.");
                }
            }
        }

        public void PlayWithPlayer()
        {
            Console.WriteLine("Welcome to Tic Tac Toe with Player!");
            InitializeBoard();
            PrintBoard();

            while (true)
            {
                int row, col;

                Console.WriteLine($"{currentPlayer}'s turn (enter row and column):");
                string[] input = Console.ReadLine().Split();
                row = int.Parse(input[0]);
                col = int.Parse(input[1]);

                if (board[row, col] == '-')
                {
                    board[row, col] = currentPlayer;
                    PrintBoard();

                    if (CheckWin())
                    {
                        Console.WriteLine($"{currentPlayer} wins!");
                        break;
                    }

                    if (IsBoardFull())
                    {
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Cell already taken! Try again.");
                }
            }
        }
    }

    class MorseCodeTranslator
    {
        private static Dictionary<char, string> morseAlphabet = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
            {'9', "----."}
        };

        public static string TranslateToMorseCode(string text)
        {
            text = text.ToUpper();
            string morseCode = "";
            foreach (char character in text)
            {
                if (morseAlphabet.ContainsKey(character))
                {
                    morseCode += morseAlphabet[character] + " ";
                }
                else
                {
                    morseCode += " ";
                }
            }
            return morseCode.Trim();
        }

        public static string TranslateToText(string morseCode)
        {
            string[] words = morseCode.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string text = "";
            foreach (string word in words)
            {
                if (morseAlphabet.ContainsValue(word))
                {
                    foreach (KeyValuePair<char, string> entry in morseAlphabet)
                    {
                        if (entry.Value == word)
                        {
                            text += entry.Key;
                            break;
                        }
                    }
                }
                else
                {
                    text += " ";
                }
            }
            return text;
        }
    }

    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Play Tic Tac Toe with Computer");
            Console.WriteLine("2. Play Tic Tac Toe with Player");
            Console.WriteLine("3. Translate text to Morse Code");
            Console.WriteLine("4. Translate Morse Code to text");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PlayTicTacToeWithComputer();
                    break;
                case 2:
                    PlayTicTacToeWithPlayer();
                    break;
                case 3:
                    TranslateToMorse();
                    break;
                case 4:
                    TranslateToText();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }

        static void PlayTicTacToeWithComputer()
        {
            TicTacToe game = new TicTacToe();
            game.PlayWithComputer();
        }

        static void PlayTicTacToeWithPlayer()
        {
            TicTacToe game = new TicTacToe();
            game.PlayWithPlayer();
        }

        static void TranslateToMorse()
        {
            Console.WriteLine("Enter text to translate to Morse code:");
            string textToTranslate = Console.ReadLine();
            string morseCode = MorseCodeTranslator.TranslateToMorseCode(textToTranslate);
            Console.WriteLine($"Morse code: {morseCode}");
        }

        static void TranslateToText()
        {
            Console.WriteLine("Enter Morse code to translate to text:");
            string morseText = Console.ReadLine();
            string translatedText = MorseCodeTranslator.TranslateToText(morseText);
            Console.WriteLine($"Translated text: {translatedText}");
        }
    }

