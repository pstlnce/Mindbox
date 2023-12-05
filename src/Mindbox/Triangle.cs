namespace Mindbox.Geometric.Figures;

public class Triangle : ISquareCalculable
{
    public double Side1 { get; }
    public double Side2 { get; }
    public double Side3 { get; }

    ///<exception cref="ArgumentOutOfRangeException">If at least one of the sides is negative</exception>
    ///<exception cref="InvalidTriangleSidesException">If one side is greater than the sum of the others</exception>
    public Triangle(double side1, double side2, double side3)
    {
        ThrowHelper.ThrowIfSideIsNegativeNumber(side1);
        ThrowHelper.ThrowIfSideIsNegativeNumber(side2);
        ThrowHelper.ThrowIfSideIsNegativeNumber(side3);

        ThrowHelper.ThrowIfInvalidSidesOfTriangle(side1, side2, side3);

        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    // По заданию дополнительно оценивается проверка на то, является ли треугольник прямоугольным,
    // но не сказано где ее использовать. Как я предполагаю, она нужна для более быстрого расчета площади,
    // но легче было бы посчитать площадь заранее и хранить в свойстве,
    // чем указывать отдельные поля для катетов, увеличивая потребляемую память, или менять порядок получаемых
    // размеров сторон, указывая самую большую в одном из трех свойств, что могло бы привести к неожиданному поведению
    // для пользователя, если доступ к размерам сторон делать частью поставляемого интерфейса
    // Потому проверка на прямоугольность просто вынесена в свойство
    public bool IsRightAngled
    {
        get
        {
            var isRighAngled = Assumption(Side1, Side2, Side3) ||
                Assumption(Side1, Side3, Side2) ||
                Assumption(Side2, Side3, Side1);

            return isRighAngled;
        }
    }

    public double Square => GetSquare();

    public double Perimeter => Side1 + Side2 + Side3;

    public double GetSquare()
    {
        var half = Perimeter / 2;
        var squareArea = half * (half - Side1) * (half - Side2) * (half - Side3);

        return Math.Sqrt(squareArea);
    }

    private bool Assumption(double leg1, double leg2, double hypotenuse)
        => (leg1 * leg1) + (leg2 * leg2) == hypotenuse * hypotenuse;
}
