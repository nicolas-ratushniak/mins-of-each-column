using System.Text;

namespace MatrixLib;

public class MatrixDecoder
{
    private const char _separator = ' ';
    private const char _newLine = '\n';

    public static string MatrixToString(double[,] matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sb.Append(matrix[i, j]);
                sb.Append(j < matrix.GetLength(2) - 1 ? _separator : _newLine);
            }
        }
        return sb.ToString();
    }

    public static bool TryParseToMatrix(string? text, out double[,]? matrix)
    {
        matrix = null;

        if (text is null)
        {
            return false;
        }

        string[] rows = text.Split(_newLine, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < rows.Length; i++)
        {
            string[] elemsOfRow = rows[i].Split(_separator, StringSplitOptions.RemoveEmptyEntries);

            if (matrix is null)
            {
                matrix = new double[rows.Length, rows[0].Length];
            }

            for (int j = 0; j < rows[i].Length; j++)
            {
                try
                {
                    matrix[i, j] = double.Parse(elemsOfRow[j]);
                }
                catch (IndexOutOfRangeException)
                {
                    matrix = null;
                    return false;
                }
            }
        }
        return true;
    }
}
