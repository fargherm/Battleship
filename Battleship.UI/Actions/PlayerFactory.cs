using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Actions
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayerImplementation(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper();

                if (input == "H")
                {
                    string name = ConsoleIO.GetPlayerName();
                    return new HumanPlayer(name);
                }
                else if (input == "C")
                {
                    return new ComputerPlayer();
                }
                else
                {
                    Console.WriteLine("That is not a valid input!");
                }
            } while (true);
        }
    }
}
