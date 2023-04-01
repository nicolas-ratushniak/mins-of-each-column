namespace MatrixLibTests;

[TestClass]
public class MatrixBuilderTests
{
    [TestMethod]
    public void Build_MartixWithExpectedSize()
    {
        // Arrange
        double[,] matrix;
        MatrixBuilder builder = new();

        builder.SetSize(3, 4);

        // Act
        matrix = builder.Build();

        // Assert
        Assert.AreEqual(matrix.GetLength(0), 3);
        Assert.AreEqual(matrix.GetLength(1), 4);
    }

    [TestMethod]
    public void Build_RandomlyFilledMatrix_ValuesInExpectedRange()
    {
        // Arrange
        double[,] matrix;
        MatrixBuilder builder = new();

        builder.SetSize(10, 10);
        builder.SetPrecision(1);
        builder.SetRange(1, 5);

        // Act
        matrix = builder.Build();

        // Assert
        foreach (int i in matrix)
        {
            Assert.IsTrue(i >= 1.0 && i <= 5.0);
        }
    }

    [TestMethod]
    public void Build_InvalidValueRange_ThrowsArgumentException()
    {
        // Arrange
        MatrixBuilder builder = new();

        // Act
        builder.SetSize(2, 2);
        builder.SetRange(12, 4);

        // Assert
        Assert.ThrowsException<ArgumentException>(() => builder.Build());
    }

    [TestMethod]
    [DataRow(0, 0)]
    [DataRow(0, 12)]
    [DataRow(-1, -3)]
    public void Build_InvalidSize_ThrowsInvalidOperationException(int invalidRows, int invalidCols)
    {
        // Arrange
        MatrixBuilder builder = new();

        // Act
        builder.SetSize(invalidRows, invalidCols);

        // Assert
        Assert.ThrowsException<InvalidOperationException>(() => builder.Build());
    }
}
