namespace TicTacToeLibrary
{
    public class Player
    {
        public struct Core
        {
            public int X;
            public int O;
            public int TotalGames;

            public Core()
            {
                X = 0;
                O = 0;
                TotalGames = 0;
            }

            public Core(int x, int o, int totalGames)
            {
                X = x;
                O = o;
                TotalGames = totalGames;
            }
        }

        protected int Number;
        protected string Role;
        protected Core Rating;

        public Player(int number, string checkRole = "")
        {
            Number = number;
            Role = EnterPlayerRole(number, checkRole);
            Rating = new Core();
        }

        public Player(int number, string role, int x, int o, int totalGames)
        {
            Number = number;
            Role = role;
            Rating = new Core(x, o, totalGames);
        }

        public static string EnterPlayerRole(int PlayerNumber, string CheckRole = "")
        {
            string Role;

            switch (CheckRole)
            {
                case "X": return "O";
                case "O": return "X";
                default: Console.WriteLine("Existing game roles: X, O."); break;
            }

            do
            {
                Console.Write($"Player {PlayerNumber} role: "); 
                Role = Console.ReadLine();
                if (CheckRole != Role && (Role == "X" || Role == "O"))
                    break;
                else
                {
                    Console.Write("Error! Role is entered wrong. Repeat: "); 
                    Role = Console.ReadLine();
                }
            } while (CheckRole == Role && (Role == "X" || Role == "O"));

            return Role;
        }

        public void SetRating(string RatingKey)
        {
            switch (RatingKey)
            {
                case "X":
                    {
                        Rating.X++;
                        Rating.TotalGames++;
                        break;
                    }
                case "O":
                    {
                        Rating.O += 1;
                        Rating.TotalGames++;
                        break;
                    }
                case "TotalGames":
                    {
                        Rating.TotalGames++;
                        break;
                    } 
            }
        }

        public void SetRole(string NewRole)
        {
            if (NewRole != "X" && NewRole != "O")
                return;

            Role = NewRole;
        }
        public int GetNumber() => Number;
        public string GetRole() => Role;
        public double GetRating(string RatingKey = "")
        {
            switch (RatingKey)
            {
                case "X": return Rating.X;
                case "O": return Rating.O;
                case "TotalGames": return Rating.TotalGames;
            }

            return 0;
        }
    }
}
