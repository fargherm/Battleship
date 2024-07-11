using Battleship.UI.Actions;
using Battleship.UI.Interfaces;
using Battleship.UI.Ships;

namespace Battleship.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public bool IsHuman { get; private set; } = true;
        public string Name { get; private set; }
        public string OpponentName { get; private set; }

        public HumanPlayer(string name)
        {
            Name = name;
        }

        public Coordinate GetGridCoordinate(string prompt)
        {
            return ConsoleIO.GetPlayerCoordinate(prompt);
        }

        public ShipDirection GetShipDirection()
        {
            return ConsoleIO.GetPlayerShipDirection();
        }
    }
}
