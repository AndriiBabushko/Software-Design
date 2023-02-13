namespace TicTacToeLibrary
{
    public class Player
    {
        protected int Number;
        protected string Role;
        protected int Core;

        public Player(int playerNumber, string checkRole = "")
        {
            Number = playerNumber;
            Role = EnterPlayerRole(playerNumber, checkRole);
            Core = 0;
        }

        public static string EnterPlayerRole(int PlayerNumber, string CheckRole = "")
        {
            string Role;

            switch (CheckRole)
            {
                case "X": Console.WriteLine("Existing roles: O."); break;
                case "O": Console.WriteLine("Existing roles: X."); break;
                default: Console.WriteLine("Existing roles: X, O."); break;
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

        public string GetRole() => Role;
    }
}
