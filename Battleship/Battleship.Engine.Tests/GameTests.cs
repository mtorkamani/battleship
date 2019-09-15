using Xunit;

namespace Battleship.Engine.Tests
{
    public class GameTests
    {
        private readonly Game game;
        private readonly ShipFactory factory;

        public GameTests()
        {
            this.game = new Game();
            this.factory = new ShipFactory();
        }

        [Fact]
        public void Horizontal4ShipShouldGameOverAfter4Hits()
        {
            game.Setup();
            game.PlaceShip(factory.Create(4), 1, 0, Orientation.Horizontal);
            var status = CoordinateStatus.Unknown;

            Assert.False(game.IsOver());

            status = game.Hit(1, 0);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(1, 1);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(2, 3);
            Assert.Equal(CoordinateStatus.Missed, status);
            status = game.Hit(1, 2);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(1, 3);
            Assert.Equal(CoordinateStatus.Hit, status);

            Assert.True(game.IsOver());
        }

        [Fact]
        public void Vertical5ShipShouldGameOverAfter5Hits()
        {
            game.Setup();
            game.PlaceShip(factory.Create(5), 2, 2, Orientation.Vertical);
            var status = CoordinateStatus.Unknown;

            Assert.False(game.IsOver());

            status = game.Hit(2, 2);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(3, 2);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(4, 2);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(5, 2);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(6, 2);
            Assert.Equal(CoordinateStatus.Hit, status);

            Assert.True(game.IsOver());
        }

        [Fact]
        public void Vertical5ShipShouldNotGameOverAfter3Hits()
        {
            game.Setup();
            game.PlaceShip(factory.Create(5), 4, 6, Orientation.Vertical);
            var status = CoordinateStatus.Unknown;

            Assert.False(game.IsOver());

            status = game.Hit(4, 6);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(5, 6);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(6, 6);
            Assert.Equal(CoordinateStatus.Hit, status);
            status = game.Hit(4, 4);
            Assert.Equal(CoordinateStatus.Missed, status);

            Assert.False(game.IsOver());
        }
    }
}
