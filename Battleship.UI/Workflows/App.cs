using Battleship.UI.Actions;
using Battleship.UI.Interfaces;
using Battleship.UI.Ships;

namespace Battleship.UI.Workflows
{
    public class App
    {
        private readonly GameBoard _gameBoard1;
        private readonly GameBoard _gameBoard2;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly ShipType[] _shipTypeArray;

        public App(IPlayer player1, IPlayer player2)
        {
            _gameBoard1 = new GameBoard();
            _gameBoard2 = new GameBoard();
            _player1 = player1;
            _player2 = player2;
            _gameBoard1.PlayerName = _player1.Name;
            _gameBoard2.PlayerName = _player2.Name;
            _shipTypeArray = [ShipType.AircraftCarrier, ShipType.Battleship, ShipType.Cruiser, ShipType.Submarine, ShipType.Destroyer];
        }

        public void Run()
        {
            IPlayer currentPlayer = _player1;
            GameBoard currentGameBoard = _gameBoard1;

            SetupBoard(currentPlayer, currentGameBoard, _shipTypeArray);

            if (currentPlayer == _player1)
            {
                currentPlayer = _player2;
                currentGameBoard = _gameBoard2;
            }
            else
            {
                currentPlayer = _player1;
                
                currentGameBoard = _gameBoard1;
            }

            SetupBoard(currentPlayer, currentGameBoard, _shipTypeArray);

            do
            {
                if (currentPlayer == _player2)
                {
                    currentPlayer = _player1;
                    currentGameBoard = _gameBoard2;
                }
                else
                {
                    currentPlayer = _player2;
                    currentGameBoard = _gameBoard1;
                }

                PlayGame(currentPlayer, currentGameBoard);

                if (currentGameBoard.GameWon())
                {
                    Console.WriteLine($"{currentPlayer.Name} has won!");
                    return;
                }

                if (currentPlayer == _player2)
                {
                    currentPlayer = _player1;
                    currentGameBoard = _gameBoard2;
                }
                else
                {
                    currentPlayer = _player2;
                    currentGameBoard = _gameBoard1;
                }

                PlayGame(currentPlayer, currentGameBoard);

                if (currentGameBoard.GameWon())
                {
                    Console.WriteLine($"{currentPlayer.Name} has won!");
                    return;
                }

            } while (true);
        }

        public static void SetupBoard(IPlayer currentPlayer, GameBoard currentGameBoard, ShipType[] shipTypeArray)
        {
            PlacementResult result;

            for (int i = 0; i < shipTypeArray.Length; i++)
            {
                if (currentPlayer.IsHuman)
                {
                    Console.WriteLine($"\nHello {currentPlayer.Name}, let's place your ships!\n");
                    ConsoleIO.PrintGameBoard(currentGameBoard.Grid);
                    Console.WriteLine("\nCoordinates should be from A-J (column) and 1-10 (row).");
                    Console.WriteLine("You will be prompted for the starting coordinate and the direction of placement.\n");

                    Console.WriteLine($"Ship to place: {ConsoleIO.ShipTypeName(shipTypeArray[i])} | Size: {ConsoleIO.ShipTypeSize(shipTypeArray[i])}");

                    do
                    {
                        Coordinate coordinate = currentPlayer.GetGridCoordinate("Enter target coordinate (ex: A5): ");
                        ShipDirection shipDirection = currentPlayer.GetShipDirection();
                        currentGameBoard.Ships[i] = currentGameBoard.CreateShip(ConsoleIO.ShipTypeSize(shipTypeArray[i]), shipTypeArray[i], shipDirection);

                        result = currentGameBoard.PlaceShip(currentGameBoard.Ships[i], coordinate);

                        if (result == PlacementResult.ShipOffGrid)
                        {
                            Console.WriteLine("Attempted to place ship off grid, try again!");
                        }
                        else if (result == PlacementResult.ShipOverlap)
                        {
                            Console.WriteLine("A ship is already place there, try again!");
                        }
                        else
                        {
                            Console.WriteLine($"You have placed your {ConsoleIO.ShipTypeName(shipTypeArray[i])}");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    } while (result != PlacementResult.ShipPlaced);

                }
                else
                {
                    do
                    {
                        Coordinate coordinate = currentPlayer.GetGridCoordinate("");
                        ShipDirection shipDirection = currentPlayer.GetShipDirection();
                        currentGameBoard.Ships[i] = currentGameBoard.CreateShip(ConsoleIO.ShipTypeSize(shipTypeArray[i]), shipTypeArray[i], shipDirection);

                        result = currentGameBoard.PlaceShip(currentGameBoard.Ships[i], coordinate);
                    } while (result != PlacementResult.ShipPlaced);
                }
            }
        }

        public static void PlayGame(IPlayer currentPlayer, GameBoard currentGameBoard)
        {
            ShotResult result = ShotResult.Miss;
            Coordinate coordinate;
            int position;

            if (currentPlayer.IsHuman)
            {
                Console.WriteLine($"{currentGameBoard.PlayerName} has {currentGameBoard.shipCount} ships remaining with {currentGameBoard.GetShipCountHits(currentGameBoard.Ships)} hits left.\n");
                Console.WriteLine($"{currentPlayer.Name}'s turn.\n");

                ConsoleIO.PrintGameBoard(currentGameBoard.DisplayGrid);
                do
                {
                    coordinate = currentPlayer.GetGridCoordinate("\nEnter target coordinate (ex: A5): ");
                    position = currentGameBoard.GetGridPosition(coordinate);
                    if (currentGameBoard.DisplayGrid[position] == "-")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You already tried shooting at that square, try a different one.");
                    }
                } while (true);
                
                Console.WriteLine($"\n{currentPlayer.Name} fires at {currentGameBoard.GetChoicePosition(coordinate)}");
            }
            else
            {
                Console.WriteLine($"{currentGameBoard.PlayerName} has {currentGameBoard.shipCount} ships remaining with {currentGameBoard.GetShipCountHits(currentGameBoard.Ships)} hits left.\n");
                Console.WriteLine($"{currentPlayer.Name}'s turn.\n");
                do
                {
                    coordinate = currentPlayer.GetGridCoordinate("\nEnter target coordinate (ex: A5): ");
                    position = currentGameBoard.GetGridPosition(coordinate);
                    if (currentGameBoard.DisplayGrid[position] == "-")
                    {
                        break;
                    }
                } while (true);
                Console.WriteLine($"\n{currentPlayer.Name} fires at {currentGameBoard.GetChoicePosition(coordinate)}");

            }

            for (int i = 0; i < currentGameBoard.Ships.Length; i++)
            {
                result = currentGameBoard.Ships[i].TryHit(coordinate);

                if (result == ShotResult.HitAndSunk)
                {
                    position = currentGameBoard.GetGridPosition(coordinate);
                    currentGameBoard.DisplayGrid[position] = "H";
                    currentGameBoard.shipCount--;
                    
                    break;
                }
                else if (result == ShotResult.Hit)
                {
                    position = currentGameBoard.GetGridPosition(coordinate);
                    currentGameBoard.DisplayGrid[position] = "H";
                    
                    break;
                }
                else if (result == ShotResult.Miss)
                {
                    position = currentGameBoard.GetGridPosition(coordinate);
                    currentGameBoard.DisplayGrid[position] = "M";
                    
                }
            }

            switch (result)
            {
                case ShotResult.Miss:
                    Console.WriteLine("Splash! The shot missed!");
                    break;
                case ShotResult.Hit:
                    Console.WriteLine("Boom! They hit something!");
                    break;
                case ShotResult.HitAndSunk:
                    Console.WriteLine("Boom! Gurgle! The ship is sunk!");
                    break;
                default:
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
