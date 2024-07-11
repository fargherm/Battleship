using Battleship.UI.Actions;
using Battleship.UI.Ships;
using NUnit.Framework;

namespace Battleship.Tests
{

    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void GridPosition_50()
        {
            Coordinate coordinate = new Coordinate(0, 5);
            GameBoard gameBoard = new GameBoard();

            var result = gameBoard.GetGridPosition(coordinate);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void GridPosition_75()
        {
            Coordinate coordinate = new Coordinate(5, 7);
            GameBoard gameBoard = new GameBoard();

            var result = gameBoard.GetGridPosition(coordinate);

            Assert.That(result, Is.EqualTo(75));
        }

        [Test]
        public void GetChoice_F8()
        {
            Coordinate coordinate = new Coordinate(5, 7);
            GameBoard gameBoard = new GameBoard();

            var result = gameBoard.GetChoicePosition(coordinate);

            Assert.That(result, Is.EqualTo("F8"));
        }

    }
}
