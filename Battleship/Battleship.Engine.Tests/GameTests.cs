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

            Assert.False(game.IsOver());

            game.Hit(1, 0);
            game.Hit(1, 1);
            game.Hit(1, 2);
            game.Hit(1, 3);

            Assert.True(game.IsOver());
        }

        [Fact]
        public void Vertical5ShipShouldGameOverAfter5Hits()
        {
            game.Setup();
            game.PlaceShip(factory.Create(5), 2, 2, Orientation.Vertical);

            Assert.False(game.IsOver());

            game.Hit(2, 2);
            game.Hit(3, 2);
            game.Hit(4, 2);
            game.Hit(5, 2);
            game.Hit(6, 2);

            Assert.True(game.IsOver());
        }

        [Fact]
        public void Vertical5ShipShouldNotGameOverAfter3Hits()
        {
            game.Setup();
            game.PlaceShip(factory.Create(5), 4, 6, Orientation.Vertical);

            Assert.False(game.IsOver());

            game.Hit(4, 6);
            game.Hit(5, 6);
            game.Hit(6, 6);

            Assert.False(game.IsOver());
        }
    }
}
