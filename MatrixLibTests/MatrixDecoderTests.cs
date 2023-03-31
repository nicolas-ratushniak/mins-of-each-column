namespace MatrixLibTests;

[TestClass]
internal class MatrixDecoderTests
{
    [TestMethod]
    public void MatrixToString()
    {
        // Arrange
        double[,] matrix =
        {
            {12.4, 3.004},
            {3,    34.1 },
            {-33.33, 10 }
        };
        string expected = "12.4 3.004\n3 34.1\n-33.33 10";

        // Act
        string actual = MatrixDecoder.MatrixToString(matrix);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TryParseToMatrix_ValidString()
    {
        // Arrange
        string matrixInput = "12.4 3.004\n3 34.1\n-33.33 10";

        double[,] expected =
        {
            {12.4, 3.004},
            {3,    34.1 },
            {-33.33, 10 }
        };

        // Act
        MatrixDecoder.TryParseToMatrix(matrixInput, out double[,] actual);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TryParseToMatrix_MatrixIsNotRectangular_False()
    {
        // Arrange
        string matrixInput = "12.4 3.004 45.1\n3 34.1\n-33.33 10";

        // Act
        bool shouldBeFalse = MatrixDecoder.TryParseToMatrix(matrixInput, out _);

        // Assert
        Assert.IsFalse(shouldBeFalse);
    }

        [TestMethod]
    public void TryParseToMatrix_InvalidSeparatorUsed_False()
    {
        // Arrange
        string matrixInput = "12.4, 3.004\n3, 34.1\n-33.33, 10";

        // Act
        bool shouldBeFalse = MatrixDecoder.TryParseToMatrix(matrixInput, out _);

        // Assert
        Assert.IsFalse(shouldBeFalse);
    }
}
