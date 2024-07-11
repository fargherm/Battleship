using Battleship.UI.Ships;

namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        bool IsHuman { get; }
        string Name { get; }
        string OpponentName { get; }

        Coordinate GetGridCoordinate(string prompt);
        ShipDirection GetShipDirection();
    }
}
