using Battleship.UI.Interfaces;
using Battleship.UI.Ships;
using System.Reflection.Metadata.Ecma335;

namespace Battleship.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        public bool IsHuman { get; private set; } = false;
        private static Random _rng = new Random();
        public string Name { get; private set; } = "CPU";
        public string OpponentName { get; private set; }

        public Coordinate GetGridCoordinate(string prompt)
        {
            int x = _rng.Next(0, 10);
            int y = _rng.Next(0, 10);

            return new Coordinate(x, y);
        }

        public ShipDirection GetShipDirection()
        {
            if (_rng.Next(1, 3) == 1)
            {
                return ShipDirection.Horizontal;
            }
            else
            {
                return ShipDirection.Vertical;
            }
        }
    }
}
