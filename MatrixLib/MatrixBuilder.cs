namespace MatrixLib;

public class MatrixBuilder
{
    private int _rows;
    private int _cols;
    private bool _fillRandomly;
    private int _minValue;
    private int _maxValue;
    private int _precision;
    private Random _random = new();

    public void SetSize(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
    }

    public void SetRange(int min, int max)
    {
        _fillRandomly = true;
        _minValue = min;
        _maxValue = max;
    }

    public void SetPrecision(int digits)
    {
        _precision = digits;
    }

    public double[,] Build()
    {
        if (_rows <= 0 || _cols <= 0)
        {
            throw new InvalidOperationException("Cannot build a matrix with non-positive number of rows or colomns.");
        }
        if (_minValue > _maxValue)
        {
            throw new ArgumentException("Max value should be greater then or equal to min value.");
        }
        if (_precision < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(_precision));
        }

        var matrix = new double[_rows, _cols];

        if (_fillRandomly)
        {
            PopulateWithRandoms(matrix, _minValue, _maxValue, _precision, _random);
        }
        return matrix;
    }

    /// <summary>
    /// Populates matrix with random numbers ranging from min to max exclusively.
    /// </summary>
    /// <param name="matrix">Not null matrix</param>
    /// <param name="min">The inclusive lower bound of the random number returned</param>
    /// <param name="max">The exclusive upper bound of the random number returned.</param>
    /// <param name="precision">Max amount of digits in fractional part.</param>
    /// <param name="rand">An instance of random number generator</param>
    private static void PopulateWithRandoms(double[,] matrix, int min, int max, int precision, Random rand)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int wholePart = rand.Next(min, max);
                double fractionalPart = Math.Round(rand.NextDouble(), precision);

                matrix[i, j] = wholePart + fractionalPart;
            }
        }
    }
}
