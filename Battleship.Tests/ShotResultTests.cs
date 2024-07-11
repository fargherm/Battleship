using Battleship.UI.Actions;
using Battleship.UI.Ships;
using NUnit.Framework;
using System.Net.WebSockets;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShotResultTests
    {
        [Test]
        public void ShotHit_True()
        {
            GameBoard gameBoard = new GameBoard();
            Ship testShip = new Ship(5, ShipType.AircraftCarrier, ShipDirection.Horizontal);
            gameBoard.Ships[0] = testShip;
            Coordinate coordinate = new Coordinate(1, 5);

            gameBoard.PlaceShip(testShip, coordinate);

            var result = gameBoard.Ships[0].TryHit(coordinate);

            Assert.That(result, Is.EqualTo(ShotResult.Hit));
        }

        [Test]
        public void ShotHit_False()
        {
            GameBoard gameBoard = new GameBoard();
            Ship testShip = new Ship(5, ShipType.AircraftCarrier, ShipDirection.Horizontal);
            gameBoard.Ships[0] = testShip;
            Coordinate coordinate = new Coordinate(1, 5);
            Coordinate shotCoordinate = new Coordinate(1, 6);

            gameBoard.PlaceShip(testShip, coordinate);

            var result = gameBoard.Ships[0].TryHit(shotCoordinate);

            Assert.That(result, Is.EqualTo(ShotResult.Miss));
        }

        [Test]
        public void ShotHitAndSunk_True ()
        {
            GameBoard gameBoard = new GameBoard();
            Ship testShip = new Ship(2, ShipType.Destroyer, ShipDirection.Horizontal);
            gameBoard.Ships[0] = testShip;
            Coordinate coordinate = new Coordinate(1, 5);
            Coordinate shotCoordinate = new Coordinate(2, 5);

            gameBoard.PlaceShip(testShip, coordinate);

            gameBoard.Ships[0].TryHit(coordinate);

            var result = gameBoard.Ships[0].TryHit(shotCoordinate);

            Assert.That(result, Is.EqualTo(ShotResult.HitAndSunk));
        }
    }
}
