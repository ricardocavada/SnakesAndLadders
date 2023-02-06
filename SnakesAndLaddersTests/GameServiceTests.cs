using FluentAssertions;
using Moq;
using SnakesAndLadders.Entities;
using SnakesAndLadders.Services;
using SnakesAndLadders.Services.Interfaces;

namespace SnakesAndLaddersTests
{
    public class GameServiceTests
    {
        [Fact]
        public void Should_be_the_players_on_initial_square_when_the_game_starts()
        {
            int expectedSquare = 1;
            int numberOfSquares = 100;
            int numberOfPlayers = 3;
            Mock<IDieService> dieService = new();

            GameService sut = new(dieService.Object);
            sut.StartGame(numberOfSquares, numberOfPlayers);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                int actual = sut.game.Players.ToArray()[i].GetCurrentSquare();

                actual.Should().Be(expectedSquare);
            }
        }

        [Fact]
        public void Should_move_the_squares_by_the_dice_when_the_player_rolls_the_dice()
        {
            int expectedSquare = 4;
            int expectedRollResult = 3;
            int numberOfSquares = 100;
            int numberOfPlayers = 1;
            Mock<IDieService> dieService = new();
            dieService.Setup(s => s.Roll()).Returns(expectedRollResult);
            GameService sut = new(dieService.Object);

            sut.StartGame(numberOfSquares, numberOfPlayers);
            sut.MovePlayer(sut.game.Players.First());

            int actual = sut.game.Players.First().GetCurrentSquare();

            actual.Should().Be(expectedSquare);
        }

        [Fact]
        public void Should_move_the_square_when_the_player_plays_twice()
        {
            int expectedSquare = 8;
            int expectedFirtsRollResult = 3;
            int expectedSecondRollResult = 4;
            int numberOfSquares = 100;
            int numberOfPlayers = 1;
            Mock<IDieService> dieService = new();
            dieService.Setup(s => s.Roll()).Returns(expectedFirtsRollResult);
            GameService sut = new(dieService.Object);

            sut.StartGame(numberOfSquares, numberOfPlayers);
            Player currentPlayer = sut.game.Players.First();
            sut.MovePlayer(currentPlayer);
            dieService.Setup(s => s.Roll()).Returns(expectedSecondRollResult);
            sut.MovePlayer(currentPlayer);

            int actual = currentPlayer.GetCurrentSquare();

            actual.Should().Be(expectedSquare);
        }

        [Fact]
        public void Should_not_be_winner_when_his_movement_cross_the_board_limit()
        {
            int expectedFirtsRollResult = 96;
            int expectedSecondRollResult = 4;
            int numberOfSquares = 100;
            int numberOfPlayers = 1;
            Mock<IDieService> dieService = new();

            GameService sut = new(dieService.Object);

            sut.StartGame(numberOfSquares, numberOfPlayers);
            dieService.Setup(s => s.Roll()).Returns(expectedFirtsRollResult);
            sut.MovePlayer(sut.game.Players.First());
            dieService.Setup(s => s.Roll()).Returns(expectedSecondRollResult);
            sut.MovePlayer(sut.game.Players.First());
            Player actual = sut.game.Players.First();

            actual.Winner.Should().BeFalse();
        }

        [Fact]
        public void Should_be_winner_when_his_movement_cross_the_board_limit()
        {
            int expectedFirtsRollResult = 96;
            int expectedSecondRollResult = 3;
            int numberOfSquares = 100;
            int numberOfPlayers = 1;
            Mock<IDieService> dieService = new();
            GameService sut = new(dieService.Object);

            sut.StartGame(numberOfSquares, numberOfPlayers);
            dieService.Setup(s => s.Roll()).Returns(expectedFirtsRollResult);
            sut.MovePlayer(sut.game.Players.First());
            dieService.Setup(s => s.Roll()).Returns(expectedSecondRollResult);
            sut.MovePlayer(sut.game.Players.First());

            Player actual = sut.game.Players.First();
            actual.Winner.Should().BeTrue();
        }
    }
}
