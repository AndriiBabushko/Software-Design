namespace TicTacToeLibrary
{
    public class TicTacToe
    {
        protected static Player[] Players = new Player[2];
        protected static string[,] GameField = new string[3, 3];

        protected static void InitializatePlayers()
        {
            if (Players[0] is null && Players[1] is null)
            {
                Players[0] = new Player(1);
                Players[1] = new Player(2, Players[0].GetRole());
            }   
        }

        protected static void InitializateGameFields()
        {
            int FieldNumber = 1;
            
            for (int i = 0; i < GameField.GetLength(0); i++)
            {
                for (int j = 0; j < GameField.GetLength(1); j++)
                {
                    GameField[i, j] = FieldNumber.ToString();
                    FieldNumber++;
                }
            }
        }

        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Tic Tac Toe!\n");

            InitializatePlayers();
            Menu();
        }

        protected static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\tMenu");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Rating");
            Console.WriteLine("3. Exit");

            int MenuOption;
            do
            {
                Console.Write($"\nSelect menu option: ");
                if (int.TryParse(Console.ReadLine(), out MenuOption) && (MenuOption >= 1 && MenuOption <= 3))
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"There is no option with '{MenuOption}' in menu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nEnter valid option: ");
                }
            } while (!int.TryParse(Console.ReadLine(), out MenuOption) && (MenuOption >= 1 && MenuOption <= 3));

            switch (MenuOption)
            {
                case 1:
                    {
                        Console.Clear();
                        Play();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        ShowPlayersRating();
                        break;
                    }
                case 3:
                    {
                        return;
                    }
            }
        }

        protected static void Play()
        {
            string? PlayAgain;

            do
            {
                Game();

                Console.Write("Do you want to play again? (y/n) ");
                PlayAgain = Console.ReadLine();
                if (PlayAgain == null || (PlayAgain != "y" && PlayAgain != "n"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Not 'y' or 'n'.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nEnter correct symbol: ");
                    PlayAgain = Console.ReadLine();
                }

                if(PlayAgain == "y")
                {
                    string TempRole = Players[0].GetRole();
                    Players[0].SetRole(Players[1].GetRole());
                    Players[1].SetRole(TempRole);
                }
            } while (PlayAgain == "y");

            StartGame();
        }

        protected static void Game()
        {
            InitializateGameFields();

            bool Playing = true;
            uint PlayerNumber;

            if (Players[0].GetRole() == "X")
                PlayerNumber = 1;
            else
                PlayerNumber = 2;

            Console.Clear();

            while (Playing)
            {
                Console.WriteLine("Let's play Tic Tac Toe!\n");
                Console.WriteLine($"Player {PlayerNumber}'s turn. Player's role '{Players[PlayerNumber - 1].GetRole()}'.\nSelect from 1 to 9 the game board.\n");

                ShowGameField();

                if (CheckWin(Players[0].GetRole()))
                {
                    Console.WriteLine("\n\n\tCongrats!");
                    Console.WriteLine("First player won!");
                    Players[0].SetRating(Players[0].GetRole());
                    Players[1].SetRating("TotalGames");
                    break;
                }
                else if (CheckWin(Players[1].GetRole()))
                {
                    Console.WriteLine("\n\n\tCongrats!");
                    Console.WriteLine("Second player won!");
                    Players[1].SetRating(Players[1].GetRole());
                    Players[0].SetRating("TotalGames");
                    break;
                }
                else if (IsNoMoves())
                {
                    Console.WriteLine("\n\nDraw!");
                    Console.WriteLine("No players won!");
                    Players[0].SetRating("TotalGames");
                    Players[1].SetRating("TotalGames");
                    break;
                }

                int Move;
                do
                {
                    do
                    {
                        Console.Write($"\n\nEnter number: ");
                        if (int.TryParse(Console.ReadLine(), out Move) && (Move >= 1 && Move <= 9))
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"There is no field with '{Move}' on the field.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nEnter valid field: ");
                        }
                    } while (!int.TryParse(Console.ReadLine(), out Move) && (Move >= 1 && Move <= 9));
                } while (!TickGameField(Move, Players[PlayerNumber - 1].GetRole()));

                switch (PlayerNumber)
                {
                    case 1: PlayerNumber = 2; break;
                    case 2: PlayerNumber = 1; break;
                }

                Console.Clear();
            }
        }

        protected static bool TickGameField(int Move, string Role)
        {
            bool[] IsTicked = new bool[9];
            int NumericMove;

            switch (Move)
            {
                // 1-st line
                case 1: 
                    { 
                        if(int.TryParse(GameField[0, 0], out NumericMove))
                            GameField[0, 0] = Role;
                        else IsTicked[0] = true;

                        break;
                    }  
                case 2:
                    {
                        if (int.TryParse(GameField[0, 1], out NumericMove))
                            GameField[0, 1] = Role;
                        else IsTicked[1] = true;

                        break;
                    }
                case 3:
                    {
                        if (int.TryParse(GameField[0, 2], out NumericMove))
                            GameField[0, 2] = Role;
                        else IsTicked[2] = true;

                        break;
                    }
                // 2-nd line
                case 4:
                    {
                        if (int.TryParse(GameField[1, 0], out NumericMove))
                            GameField[1, 0] = Role;
                        else IsTicked[3] = true;

                        break;
                    }
                case 5:
                    {
                        if (int.TryParse(GameField[1, 1], out NumericMove))
                            GameField[1, 1] = Role;
                        else IsTicked[4] = true;

                        break;
                    }
                case 6:
                    {
                        if (int.TryParse(GameField[1, 2], out NumericMove))
                            GameField[1, 2] = Role;
                        else IsTicked[5] = true;

                        break;
                    }
                // 3-rd line
                case 7:
                    {
                        if (int.TryParse(GameField[2, 0], out NumericMove))
                            GameField[2, 0] = Role;
                        else IsTicked[6] = true;

                        break;
                    }
                case 8:
                    {
                        if (int.TryParse(GameField[2, 1], out NumericMove))
                            GameField[2, 1] = Role;
                        else IsTicked[7] = true;

                        break;
                    }
                case 9:
                    {
                        if (int.TryParse(GameField[2, 2], out NumericMove))
                            GameField[2, 2] = Role;
                        else IsTicked[8] = true;

                        break;
                    }
            }

            for (int i = 0; i < IsTicked.Length; i++)
                if (IsTicked[i])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{i + 1} field is already ticked! Choose another one.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
                   
            return true;
        }

        protected static bool IsNoMoves()
        {
            bool IsNoMoves = true;

            for (int i = 0; i < GameField.GetLength(0); i++)
                for (int j = 0; j < GameField.GetLength(1); j++)
                {
                    int Numeric;
                    if (int.TryParse(GameField[i, j], out Numeric))
                    {
                        IsNoMoves = false;
                        break;
                    }

                }

            return IsNoMoves;
        }

        protected static void ShowGameField()
        {
            for (int i = 0; i < GameField.GetLength(0); i++)
            {
                for (int j = 0; j < GameField.GetLength(1); j++)
                {
                    Console.Write($" {GameField[i, j]} ");

                    if(j != GameField.GetLength(1) - 1)
                        Console.Write("|");
                }

                if(i != GameField.GetLength(0) - 1)
                    Console.WriteLine("\n---+---+---");
            }
        }

        protected static void ShowPlayersRating()
        {
            Console.WriteLine("\tRating");
            

            for (int i = 0; i < Players.Length; i++)
            {
                double WinRate = 0;
                if (Players[i].GetRating("TotalGames") != 0)
                    WinRate = Math.Round((Players[i].GetRating("X") + Players[i].GetRating("Y")) / Players[i].GetRating("TotalGames") * 100, 2);

                Console.WriteLine($"\n\tPlayer {i + 1}");
                Console.WriteLine($"X wins: {(int)Players[i].GetRating("X")}");
                Console.WriteLine($"O wins: {(int)Players[i].GetRating("O")}");
                Console.WriteLine($"Total games: {(int)Players[i].GetRating("TotalGames")}");
                Console.WriteLine($"Win rate: {WinRate}%");
            }
            
            Console.Write("\nPress any KEY to go back to menu..."); 
            Console.ReadKey();

            StartGame();
        }

        protected static bool CheckWin(string PlayerRole)
        {
            // Horizontal
            if (GameField[0, 0] == PlayerRole && GameField[0, 1] == PlayerRole && GameField[0, 2] == PlayerRole)
                return true;
            
            if (GameField[1, 0] == PlayerRole && GameField[1, 1] == PlayerRole && GameField[1, 2] == PlayerRole)
                return true;

            if (GameField[2, 0] == PlayerRole && GameField[2, 1] == PlayerRole && GameField[2, 2] == PlayerRole)
                return true;

            // Diagonal 
            if (GameField[0, 0] == PlayerRole && GameField[1, 1] == PlayerRole && GameField[2, 2] == PlayerRole)
                return true;

            if (GameField[0, 2] == PlayerRole && GameField[1, 1] == PlayerRole && GameField[2, 0] == PlayerRole)
                return true;

            // Coloumns
            if (GameField[0, 0] == PlayerRole && GameField[1, 0] == PlayerRole && GameField[2, 0] == PlayerRole)
                return true;

            if (GameField[0, 1] == PlayerRole && GameField[1, 1] == PlayerRole && GameField[2, 1] == PlayerRole)
                return true;

            if (GameField[0, 2] == PlayerRole && GameField[1, 2] == PlayerRole && GameField[2, 2] == PlayerRole)
                return true;

            return false;
        }
    }
}