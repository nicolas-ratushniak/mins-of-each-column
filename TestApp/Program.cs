using MatrixLib;
using System.Globalization;
using System.Text;
using static System.Console;


Random rand = new();

for (int i = 0; i < 200; i++)
{
    int wholePart = rand.Next(0, 5);
    double randNum = rand.NextDouble();
    double fractionalPart = Math.Round(randNum, 2, MidpointRounding.AwayFromZero);
    Console.WriteLine($"{randNum} -> {fractionalPart} + {wholePart} = {fractionalPart + wholePart}");
}


//Random rand = new();

//int min = 0;
//int max = 1;

//for (int i = 0; i < 100; i++)
//{
//    int wholePart = rand.Next(min, max);
//    double fractionalPart = Math.Round(rand.NextDouble(), 1, MidpointRounding.AwayFromZero);

//    double result = wholePart + fractionalPart;
//    Console.WriteLine(result);
//}

//double[,] matrix = GenerateDefaultMatrix();
//PrintMatrix(matrix);
//WriteLine();
//WriteLine();

//MatrixDecoder decoder = new(new CultureInfo("en-US"));

//string result = decoder.MatrixToString(matrix);
//Console.WriteLine(result);

//static double[,] GenerateDefaultMatrix()
//{
//    double[,] matrix;

//    MatrixBuilder builder = new();
//    builder.SetSize(16, 16);
//    builder.SetPrecision(1);
//    builder.SetRange(0, 5);
//    matrix = builder.Build();

//    return matrix;
//}

//static void PrintMatrix(double[,] matrix)
//{
//    for (int i = 0; i < matrix.GetLength(0); i++)
//    {
//        for (int j = 0; j < matrix.GetLength(1); j++)
//        {
//            Write(matrix[i, j]);

//            if (j < matrix.GetLength(1) - 1)
//            {
//                Write(' ');
//            }
//        }
//        if (i < matrix.GetLength(0) - 1)
//        {
//            WriteLine();
//        }
//    }
//}