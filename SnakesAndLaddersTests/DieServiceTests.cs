using FluentAssertions;
using SnakesAndLadders.Services.Interfaces;
using SnakesAndLadders.Entities;
using SnakesAndLadders.Services;

namespace SnakesAndLaddersTests
{
    public class DieServiceTests
    {
        [Fact]
        public void Should_return_a_value_between_one_and_six_when_the_player_rolls_a_die()
        {
            IDieService sut = new DieService();
            for (var i = 0; i < 10000; i++)
            {
                int actual = sut.Roll();

                actual.Should().BeInRange(Die.GetMinumumValue(), Die.GetMaximumValue());
            }
        }
    }
}
