using Battleship.UI.Actions;
using Battleship.UI.Ships;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShipPlacementTests
    {
        [Test]
        public void ShipOverlap_True()
        {
            GameBoard gameBoard = new GameBoard();
            Ship testShip = new Ship(5, ShipType.AircraftCarrier, ShipDirection.Horizontal);
            Coordinate coordinate = new Coordinate(1, 5);

            gameBoard.PlaceShip(testShip, coordinate);

            var result = gameBoard.PlaceShip(testShip, coordinate);

            Assert.That(result, Is.EqualTo(PlacementResult.ShipOverlap));
        }

        [Test]
        public void ShipOverlap_Placed()
        {
            GameBoard gameBoard = new GameBoard();
            Ship testShip = new Ship(5, ShipType.AircraftCarrier, ShipDirection.Horizontal);
            Coordinate coordinate1 = new Coordinate(1, 5);
            Coordinate coordinate2 = new Coordinate(1, 6);

            gameBoard.PlaceShip(testShip, coordinate1);

            var result = gameBoard.PlaceShip(testShip, coordinate2);

            Assert.That(result, Is.EqualTo(PlacementResult.ShipPlaced));
        }
    }
}
