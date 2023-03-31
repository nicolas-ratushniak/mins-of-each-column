namespace MatrixLib;

public static class MatrixCalculator
{
    public static double[] GetMinsOfEachColomn(in double[,] matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        var result = new double[matrix.GetLength(1)];

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            double minInRow = matrix[0, col];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] < minInRow)
                {
                    minInRow = matrix[row, col];
                }
            }
            result[col] = minInRow;
        }
        return result;
    }
}