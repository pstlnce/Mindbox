using FluentAssertions;
using Mindbox.Geometric.Figures;

namespace Mindbox.Tests;

public class TriangleTests
{
    [InlineData(1, 1, 2)]
    [InlineData(1, 3, 4)]
    [Theory]
    public void Creation_ShouldThrowException_WhenOneSideGreaterThanOrEqualToSumOfOthers(double side1,
        double side2,
        double side3)
    {
        //arrange
        var creation = () => new Triangle(side1, side2, side3);

        //assert
        creation.Should().Throw<InvalidTriangleSidesException>();
    }

    [InlineData(1.5, 2, -1)]
    [InlineData(1.5, 2, 0)]
    [InlineData(1.5, -2, 1)]
    [InlineData(1.5, 0, 1)]
    [InlineData(-1.5, 2, 1)]
    [InlineData(0, 2, 1)]
    [InlineData(0, 2, 0)]
    [InlineData(-1.5, -2, -1)]
    [Theory]
    public void Creation_ShouldThrowException_WhenAtLeastOneOfTheSidesLessOrEqualToZero(double side1,
        double side2,
        double side3)
    {
        //arrange
        var creation = () => new Triangle(side1, side2, side3);

        //assert
        creation.Should().Throw<ArgumentOutOfRangeException>();
    }

    [InlineData(3, 4, 5, 6)]
    [InlineData(5, 12, 13, 30)]
    [Theory]
    public void Square_ShouldReturnCorrectArea_WhenTheSidesAreValid(double side1,
        double side2,
        double side3,
        double expectedSquare)
    {
        //arrange
        ISquareCalculable sut = new Triangle(side1, side2, side3);

        //act
        var square = sut.Square;

        //assert
        Math.Round(square, 2).Should().Be(expectedSquare);
    }

    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    [Theory]
    public void IsRighAngled_ShouldReturnTrue_WhenTheTriangleIsRightAngled(double side1,
        double side2,
        double side3)
    {
        //arrange
        var sut = new Triangle(side1, side2, side3);

        //act
        var isRightAngled = sut.IsRightAngled;

        //assert
        isRightAngled.Should().BeTrue();
    }

    [InlineData(4, 4, 5)]
    [InlineData(5, 11, 13)]
    [Theory]
    public void IsRighAngled_ShouldReturnFalse_WhenTheTriangleIsNotRightAngled(double side1,
        double side2,
        double side3)
    {
        //arrange
        var sut = new Triangle(side1, side2, side3);

        //act
        var isRightAngled = sut.IsRightAngled;

        //assert
        isRightAngled.Should().BeFalse();
    }
}
