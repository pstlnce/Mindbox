using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Mindbox.Geometric.Figures;

public static class ThrowHelper
{
	///<exception cref="ArgumentOutOfRangeException"/>
	public static void ThrowIfRadiusIsNegativeNumber(double radius,
		[CallerArgumentExpression(nameof(radius))] string parameterName = "")
	{
		if (radius < 0)
			throw new ArgumentOutOfRangeException(parameterName, "The radius of the triangle must be zero or greater");
	}

	///<exception cref="ArgumentOutOfRangeException"/>
	public static void ThrowIfSideIsNegativeNumber(double side,
		[CallerArgumentExpression(nameof(side))] string parameterName = "")
	{
		if (side <= 0)
			throw new ArgumentOutOfRangeException(parameterName, "The side of the triangle must be greater than zero");
	}

	///<exception cref="InvalidTriangleSidesException"/>
	public static void ThrowIfInvalidSidesOfTriangle(double side1, double side2, double side3)
	{
		var side1TooBig = side1 >= side2 + side3;
		var side2TooBig = side2 >= side1 + side3;
		var side3TooBig = side3 >= side1 + side2;

		if (side1TooBig || side2TooBig || side3TooBig)
			throw new InvalidTriangleSidesException(side1, side2, side3);
	}
}

[System.Serializable]
public class InvalidTriangleSidesException : System.Exception
{
	private const string MESSAGE = "One side is greater than the sum of the others";

	private readonly double Side1;
	private readonly double Side2;
	private readonly double Side3;

	public InvalidTriangleSidesException(double side1,
		double side2,
		double side3) : this(side1, side2, side3, default) { }

	public InvalidTriangleSidesException(double side1,
		double side2,
		double side3,
		System.Exception? inner) : base(MESSAGE, inner)
	{
		Side1 = side1;
		Side2 = side2;
		Side3 = side3;
	}

	protected InvalidTriangleSidesException(
		SerializationInfo info,
		StreamingContext context) : base(info, context) { }

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);

		info.AddValue(nameof(Side1), Side1);
		info.AddValue(nameof(Side2), Side2);
		info.AddValue(nameof(Side3), Side3);
	}
}

