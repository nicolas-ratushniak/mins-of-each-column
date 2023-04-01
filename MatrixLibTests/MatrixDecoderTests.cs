using System.Globalization;
using System.Linq;

namespace MatrixLibTests;

[TestClass]
public class MatrixDecoderTests
{
    [TestMethod]
    public void MatrixToString()
    {
        // Arrange
        MatrixDecoder decoder = GetDefaultMatrixDecoder();
        double[,] matrix =
        {
            {12.4, -3.004},
            {3,    34.1 },
            {-33.33, 10 }
        };
        string expected = "12.4 -3.004\n3 34.1\n-33.33 10";

        // Act
        string actual = decoder.MatrixToString(matrix);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TryParseToMatrix_ValidString()
    {
        // Arrange
        MatrixDecoder decoder = GetDefaultMatrixDecoder();
        string matrixInput = "12.4 3.004\n3 34.1\n-33.33 10";

        double[,] expected =
        {
            {12.4, 3.004},
            {3,    34.1 },
            {-33.33, 10 }
        };

        // Act
        decoder.TryParseToMatrix(matrixInput, out double[,] actual);

        // Assert
        for (int i = 0; i < expected.GetLength(0); i++)
        {
            for (int j = 0; j < expected.GetLength(1); j++)
            {
                Assert.AreEqual(expected[i, j], actual[i, j]);
            }
        }
    }

    [TestMethod]
    public void TryParseToMatrix_MatrixIsNotRectangular_False()
    {
        // Arrange
        MatrixDecoder decoder = GetDefaultMatrixDecoder();
        string matrixInput = "12.4 3.004 45.1\n3 34.1\n-33.33 10";

        // Act
        bool shouldBeFalse = decoder.TryParseToMatrix(matrixInput, out _);

        // Assert
        Assert.IsFalse(shouldBeFalse);
    }

        [TestMethod]
    public void TryParseToMatrix_InvalidSeparatorUsed_False()
    {
        // Arrange
        MatrixDecoder decoder = GetDefaultMatrixDecoder();
        string matrixInput = "12.4, 3.004\n3, 34.1\n-33.33, 10";

        // Act
        bool shouldBeFalse = decoder.TryParseToMatrix(matrixInput, out _);

        // Assert
        Assert.IsFalse(shouldBeFalse);
    }

    private static MatrixDecoder GetDefaultMatrixDecoder()
    {
        MatrixDecoder decoder = new(new CultureInfo("en-US"));
        return decoder;
    }
}
