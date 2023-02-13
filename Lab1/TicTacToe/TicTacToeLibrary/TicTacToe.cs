using System.Data;

namespace TicTacToeLibrary
{
    public class TicTacToe
    {
        protected static Player[] Players = new Player[2];
        protected static string[,] GameField = new string[3, 3];

        public static void InitializatePlayers()
        {
            Players[0] = new Player(1);
            Players[1] = new Player(2, Players[0].GetRole());
        }

        public static void InitializateGameFields()
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
            Console.WriteLine("Welcome to Tic Tac Toe!\n");

            InitializatePlayers();
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
                Console.WriteLine("\tLet's play Tic Tac Toe!\n");
                Console.WriteLine($"Player {PlayerNumber}'s turn. Player's role '{Players[PlayerNumber - 1].GetRole()}'.\nSelect from 1 to 9 the game board.\n");

                OutputGameField();

                if (CheckWin(Players[0].GetRole()))
                {
                    Console.WriteLine("First player win! Congrats!");
                    break;
                }
                else if (CheckWin(Players[1].GetRole()))
                {
                    Console.WriteLine("Second player win! Congrats!");
                    break;
                }

                int Move;
                do
                {
                    Console.Write($"\n\nEnter number: ");
                    if (int.TryParse(Console.ReadLine(), out Move) && (Move >= 1 && Move <= 9))
                        break;
                    else
                        Console.WriteLine("Error! Enter valid number: ");
                } while (!int.TryParse(Console.ReadLine(), out Move) && (Move >= 1 && Move <= 9));

                TickGameField(Move, Players[PlayerNumber - 1].GetRole());

                switch (PlayerNumber)
                {
                    case 1: PlayerNumber = 2; break;
                    case 2: PlayerNumber = 1; break;
                }

                Console.Clear();
            }
        }

        protected static void TickGameField(int Move, string Role)
        {
            switch (Move)
            {
                // 1-st line
                case 1: GameField[0, 0] = Role; break;
                case 2: GameField[0, 1] = Role; break;
                case 3: GameField[0, 2] = Role; break;
                // 2-nd line
                case 4: GameField[1, 0] = Role; break;
                case 5: GameField[1, 1] = Role; break;
                case 6: GameField[1, 2] = Role; break;
                // 3-rd line
                case 7: GameField[2, 0] = Role; break;
                case 8: GameField[2, 1] = Role; break;
                case 9: GameField[2, 2] = Role; break;
            }
        }

        protected static void OutputGameField()
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