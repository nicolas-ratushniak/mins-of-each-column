using System.Globalization;
using System.Text;

namespace MatrixLib;

public class MatrixDecoder
{
    public NumberStyles NumStyles { get; set; }
    public CultureInfo Culture { get; set; }

    private const char _separator = ' ';
    private const char _newLine = '\n';

    public MatrixDecoder(NumberStyles numStyles, CultureInfo culture)
    {
        NumStyles = numStyles;
        Culture = culture;
    }

    public MatrixDecoder(CultureInfo culture)
    {
        NumStyles = NumberStyles.Float;
        Culture = culture;
    }

    public string MatrixToString(double[,] matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        StringBuilder sb = new();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sb.Append(matrix[i, j].ToString(Culture));

                if (j < matrix.GetLength(1) - 1)
                {
                    sb.Append(_separator);
                }
            }
            if (i < matrix.GetLength(0) - 1)
            {
                sb.Append(_newLine);
            }
        }
        return sb.ToString();
    }

    public bool TryParseToMatrix(string? text, out double[,]? matrix)
    {
        matrix = null;

        if (string.IsNullOrEmpty(text))
        {
            return false;
        }

        string[] rows = text.Split(_newLine, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < rows.Length; i++)
        {
            string[] elemsOfRow = rows[i].Split(_separator, StringSplitOptions.RemoveEmptyEntries);

            if (matrix is null)
            {
                matrix = new double[rows.Length, elemsOfRow.Length];
            }
            else if (elemsOfRow.Length != matrix.GetLength(1))
            {
                matrix = null;
                return false;
            }

            for (int j = 0; j < elemsOfRow.Length; j++)
            {
                if (double.TryParse(elemsOfRow[j], NumStyles, Culture, out double num))
                {
                    matrix[i, j] = num;
                }
                else
                {
                    matrix = null;
                    return false;
                }
            }
        }
        return true;
    }
}
