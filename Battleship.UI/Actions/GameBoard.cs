using Battleship.UI.Ships;

namespace Battleship.UI.Actions
{
    public class GameBoard
    {
        public string[] Grid { get; private set; } //Enumerable.Repeat("-", 100).ToArray();
        public string[] DisplayGrid { get; private set; }
        public Ship[] Ships { get; private set; }
        public int shipCount { get; set; } = 5;
        public string PlayerName {get; set; }

        public GameBoard()
        {
            Ships = new Ship[shipCount];
            Grid = new string[100];
            DisplayGrid = new string[100];

            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = "-";
                DisplayGrid[i] = "-";
            }
        }  

        public Ship CreateShip(int size, ShipType shipType, ShipDirection shipDirection)
        {
            return new Ship(size, shipType, shipDirection);
        }

        public PlacementResult PlaceShip(Ship ship, Coordinate coordinate)
        {
            int position = GetGridPosition(coordinate);

            if (ShipOffGrid(ship, coordinate))
            {
                return PlacementResult.ShipOffGrid;
            }
            else if (ShipOverlap(ship, coordinate))
            {
                return PlacementResult.ShipOverlap;
            }
            else
            {
                ship.Coordinates[0] = coordinate;

                for (int i = 1; i < ship.Size; i++)
                {
                    if (ship.ShipDirection == ShipDirection.Horizontal)
                    {
                        ship.Coordinates[i] = new Coordinate(coordinate.X + i, coordinate.Y);
                    }
                    else
                    {
                        ship.Coordinates[i] = new Coordinate(coordinate.X, coordinate.Y + i);
                    }
                }

                if (ship.ShipDirection == ShipDirection.Horizontal)
                {
                    for (int i = position; i < ship.Coordinates.Length + position; i++)
                    {
                        Grid[i] = ConsoleIO.ShipTypeLetter(ship.ShipType);
                    }
                }
                else
                {
                    for (int i = position; i < ship.Coordinates.Length * 10 + position; i += 10)
                    {
                        Grid[i] = ConsoleIO.ShipTypeLetter(ship.ShipType);
                    }
                }

                return PlacementResult.ShipPlaced;
            }

        }

        public bool ShipOffGrid(Ship ship, Coordinate coordinate)
        {
            int position = GetGridPosition(coordinate);

            if ((position + 10 * (ship.Size - 1)) / 10 <= 9 && ship.ShipDirection == ShipDirection.Vertical || (position + ship.Size) - coordinate.Y * 10 <= 9 && ship.ShipDirection == ShipDirection.Horizontal)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ShipOverlap(Ship ship, Coordinate coordinate)
        {
            int position = GetGridPosition(coordinate);

            if (ship.ShipDirection == ShipDirection.Horizontal)
            {
                for (int i = position; i < ship.Coordinates.Length + position; i++)
                {
                    if (Grid[i] != "-")
                    {
                        return true;
                    }
                }
            }
            else if (ship.ShipDirection == ShipDirection.Vertical)
            {
                for (int i = position; i < ship.Coordinates.Length * 10 + position; i += 10)
                {
                    if (Grid[i] != "-")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetGridPosition(Coordinate coordinate)
        {
            int position;

            if (coordinate.Y == 0)
            {
                position = coordinate.X;
            }
            else
            {
                position = int.Parse(coordinate.Y.ToString() + coordinate.X.ToString());
            }
            return position;
        }

        public string GetChoicePosition(Coordinate coordinate)
        {
            int x = coordinate.X;
            string y = (coordinate.Y + 1).ToString();

            return ConsoleIO.CoordinateToCharacter(x) + y;
        }

        public int GetShipCountHits(Ship[] ships)
        {
            int count = 0;
            for(int i = 0; i < ships.Length; i++)
            {
                count += ships[i].Health;
            }
            return count;
        }

        public bool GameWon()
        {
            if (shipCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
