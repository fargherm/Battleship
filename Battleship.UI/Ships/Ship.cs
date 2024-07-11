using Battleship.UI.Actions;

namespace Battleship.UI.Ships
{
    public class Ship
    {
        public int Size { get; private set; }
        public int Health { get; private set; }
        public bool IsSunk { get; private set; } = false;
        public Coordinate[] Coordinates { get; private set; }
        public ShipType ShipType { get; private set; }
        public ShipDirection ShipDirection { get; private set; }

        public Ship (int size, ShipType shipType, ShipDirection shipDirection)
        {
            Size = size;
            Health = size;
            ShipType = shipType;
            ShipDirection = shipDirection;
            Coordinates = new Coordinate[size];
        }

        public ShotResult TryHit(Coordinate c)
        {
            if (Coordinates.Contains(c) && Health == 1)
            {
                Health = 0;
                IsSunk = true;
                return ShotResult.HitAndSunk;
            }
            else if (Coordinates.Contains(c))
            {
                Health--;
                return ShotResult.Hit;
            }
            else
            {
                return ShotResult.Miss;
            }
        }
    }
}
