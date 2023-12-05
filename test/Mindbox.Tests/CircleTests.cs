using FluentAssertions;
using Mindbox.Geometric.Figures;

namespace Mindbox.Tests;

public class CircleTests
{
	[InlineData(2, 12.57)]
	[InlineData(1, 3.14)]
	[InlineData(0, 0)]
	[Theory]
	public void Square_ShouldReturnCorrectSquare_WhenRadiusIsValid(double radius, double expectedSquare)
	{
		//arrange
		ISquareCalculable sut = new Circle(radius);

		//act
		var square = sut.Square;

		//assert
		Math.Round(square, 2).Should().Be(expectedSquare);
	}

	[InlineData(double.MinValue)]
	[InlineData(-1)]
	[InlineData(-.0000001)]
	[Theory]
	public void Creation_ShouldThrowException_WhenRadiusIsNegativeNumber(double radius)
	{
		//arrange
		var creation = () => new Circle(radius);

		//assert
		creation.Should().Throw<ArgumentOutOfRangeException>();
	}
}
