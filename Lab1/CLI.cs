using TicTacToe;

namespace TicTacToeCLI;
public class CLI
{
    public static char EnterPlayerRole(int PlayerNumber, string CheckRole = "")
    {
        char Role;

        switch (CheckRole)
        {
            case "X":  Console.WriteLine("Existing roles: O."); break;
            case "O":  Console.WriteLine("Existing roles: X."); break;
            default:  Console.WriteLine("Existing roles: X, O."); break;
        }
       
        do
        {
            Console.Write($"Player {PlayerNumber} role: ");
            if(char.TryParse(Console.ReadLine(), out Role) && (CheckRole != Role.ToString()) && (Role == 'X' || Role == 'O'))
                break;
            else
            {
                Console.Write("Error! Role is entered wrong. Repeat: ");
            }
        } while(char.TryParse(Console.ReadLine(), out Role) && (CheckRole == Role.ToString()) && (Role == 'X' || Role == 'O'));
        
        return Role;
    }


    private static void Main(string[] args)
    {
        Console.WriteLine("Let's play Tic Tac Toe!");

        char FirstPlayerRole = EnterPlayerRole(1);
        char SecondPlayerRole = EnterPlayerRole(2, FirstPlayerRole.ToString());

        Console.WriteLine(FirstPlayerRole);
        Console.WriteLine(SecondPlayerRole);
    }
}
