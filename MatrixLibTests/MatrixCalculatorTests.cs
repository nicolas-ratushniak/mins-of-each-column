namespace MatrixLibTests;

[TestClass]
public class MatrixCalculatorTests
{
    [TestMethod]
    public void GetMinsOfEachColomn()
    {
        // Arrange
        double[,] matrix =
        {
            {12.4, 3.004},
            {3,    34.1 },
            {-33.33, 10 }
        };
        double[] expected = { -33.33, 3.004 };

        // Act
        double[] actual = MatrixCalculator.GetMinsOfEachColomn(matrix);

        // Assert
        Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
    }

    [TestMethod]
    public void GetMinsOfEachColomn_Null_ThrowsArgumentNullException()
    {
        // Arrange
        double[,] matrix = null;

        // Act
        Action ThrowsEx = () => MatrixCalculator.GetMinsOfEachColomn(matrix);

        // Assert
        Assert.ThrowsException<ArgumentNullException>(ThrowsEx);
    }
}