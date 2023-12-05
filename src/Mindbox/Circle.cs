namespace Mindbox.Geometric.Figures;

public class Circle : ISquareCalculable
{
	public double Radius;

	///<exception cref="ArgumentOutOfRangeException">If the radius is negative</exception>
	public Circle(double radius)
	{
		ThrowHelper.ThrowIfRadiusIsNegativeNumber(radius);
		Radius = radius;
	}

	public double Square => Math.PI * Radius * Radius;
}
