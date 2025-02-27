using System.Numerics;
using MatrixiaApi.Entities;

namespace MatrixiaApi.Services;

public static class MatrixService
{
    public static DeterminantResult CalculateDeterminant(double[][] matrix, bool showSteps, bool useFractions)
    {
        if (!IsSquareMatrix(matrix))
        {
            throw new ArgumentException("Invalid input: Please provide a square matrix.");
        }

        if (useFractions)
        {
            var fractionMatrix = matrix
                .Select(row => row.Select(value => new Fraction((BigInteger)value, 1)).ToArray())
                .ToArray();
            var steps = new List<Fraction[][]>();
            var determinant = GaussEliminationWithFractions(fractionMatrix, steps, showSteps);
            var stepsJson = steps.Select(s => s.Select(row => row.Select(f => new FractionJson(f)).ToArray()).ToArray()).ToArray();

            return new DeterminantResult((int)determinant.Numerator,
                [.. stepsJson.Select(s => s.Cast<object>().ToArray())]);
        }
        else
        {
            var steps = new List<double[][]>();
            double determinant = GaussElimination(matrix, steps, showSteps);
            return new DeterminantResult((int)Math.Round(determinant), [.. steps.Select(step => step.Cast<object>().ToArray())]);
        }
    }

    public static int CalculateRank(double[][] matrix)
    {
        return GetRank(matrix);
    }

    public static double[][] CalculateInverse(double[][] jaggedMatrix)
    {
        int n = jaggedMatrix.Length;
        int m = jaggedMatrix[0].Length;

        if (n != m)
        {
            throw new ArgumentException("Invalid input: Please provide a square matrix.");
        }

        double[,] matrix = new double[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = jaggedMatrix[i][j];
            }
        }

        double[,] inverse = GetInverse(matrix);
        if (inverse is null)
        {
            throw new InvalidOperationException("Matrix is not invertible.");
        }

        double[][] inverseJagged = new double[n][];
        for (int i = 0; i < n; i++)
        {
            inverseJagged[i] = new double[n];
            for (int j = 0; j < n; j++)
            {
                inverseJagged[i][j] = inverse[i, j];
            }
        }

        return inverseJagged;
    }

    public static double[][] CalculateTranspose(double[][] jaggedMatrix)
    {
        if (jaggedMatrix is null || jaggedMatrix.Length == 0)
        {
            throw new ArgumentException("Matrix cannot be null or empty.");
        }

        int rows = jaggedMatrix.Length;
        int cols = jaggedMatrix[0].Length;

        double[][] transposedMatrix = new double[cols][];
        for (int i = 0; i < cols; i++)
        {
            transposedMatrix[i] = new double[rows];
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposedMatrix[j][i] = jaggedMatrix[i][j];
            }
        }

        return transposedMatrix;
    }

    public static double[][] CalculateAdjoint(double[][] jaggedMatrix)
    {
        if (jaggedMatrix is null || jaggedMatrix.Length == 0)
        {
            throw new ArgumentException("Matrix cannot be null or empty.");
        }

        int n = jaggedMatrix.Length;

        if (!IsSquareMatrix(jaggedMatrix))
        {
            throw new ArgumentException("Invalid input: Please provide a square matrix.");
        }

        // Create the cofactor matrix
        double[][] cofactorMatrix = new double[n][];
        for (int i = 0; i < n; i++)
        {
            cofactorMatrix[i] = new double[n];
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cofactorMatrix[i][j] = GetCofactor(jaggedMatrix, i, j);
            }
        }

        // Transpose the cofactor matrix to get the adjoint
        double[][] adjointMatrix = new double[n][];
        for (int i = 0; i < n; i++)
        {
            adjointMatrix[i] = new double[n];
            for (int j = 0; j < n; j++)
            {
                adjointMatrix[i][j] = cofactorMatrix[j][i]; // Transpose
            }
        }

        return adjointMatrix;
    }

    private static bool IsSquareMatrix(double[][] matrix)
    {
        return matrix.Length > 0 && matrix.All(row => row.Length == matrix.Length);
    }

    private static double GaussElimination(double[][] matrix, List<double[][]> steps, bool showSteps)
    {
        int n = matrix.Length;
        double determinant = 1;

        for (int i = 0; i < n; i++)
        {
            double pivot = matrix[i][i];

            if (Math.Abs(pivot) < 1e-10)
            {
                return 0;
            }

            determinant *= pivot;

            for (int j = i + 1; j < n; j++)
            {
                double factor = matrix[j][i] / pivot;
                for (int k = i; k < n; k++)
                {
                    matrix[j][k] -= factor * matrix[i][k];
                }
            }

            if (showSteps)
            {
                var roundedMatrix = matrix.Select(row => row.Select(value => Math.Round(value, 2)).ToArray()).ToArray();
                steps.Add(roundedMatrix);
            }
        }

        return Math.Round(determinant, 2);
    }

    private static Fraction GaussEliminationWithFractions(Fraction[][] matrix, List<Fraction[][]> steps, bool showSteps)
    {
        int n = matrix.Length;
        Fraction determinant = new Fraction(1, 1);

        for (int i = 0; i < n; i++)
        {
            Fraction pivot = matrix[i][i];
            if (pivot.Numerator == 0)
            {
                return new Fraction(0, 1);
            }

            determinant *= pivot;

            for (int j = i + 1; j < n; j++)
            {
                Fraction factor = matrix[j][i] / pivot;
                for (int k = i; k < n; k++)
                {
                    matrix[j][k] -= factor * matrix[i][k];
                }
            }

            if (showSteps)
            {
                var stepMatrix = matrix.Select(row =>
                    row.Select(value => new Fraction(value.Numerator, value.Denominator)).ToArray()).ToArray();
                steps.Add(stepMatrix);
            }
        }

        return determinant;
    }

    private static int GetRank(double[][] matrix)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        double[][] tempMatrix = matrix.Select(row => row.ToArray()).ToArray();

        int rank = 0;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                if (Math.Abs(tempMatrix[row][col]) > 1e-10)
                {
                    rank++;

                    for (int i = row + 1; i < n; i++)
                    {
                        double factor = tempMatrix[i][col] / tempMatrix[row][col];
                        for (int j = col; j < m; j++)
                        {
                            tempMatrix[i][j] -= factor * tempMatrix[row][j];
                        }
                    }

                    break;
                }
            }
        }

        return rank;
    }

    private static double[,] GetInverse(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        double[,] augmented = new double[n, 2 * n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                augmented[i, j] = matrix[i, j];
            }

            augmented[i, i + n] = 1;
        }

        // Perform Gauss-Jordan elimination
        for (int i = 0; i < n; i++)
        {
            double pivot = augmented[i, i];
            if (Math.Abs(pivot) < 1e-10)
            {
                return new double[0, 0];
            }

            for (int j = 0; j < 2 * n; j++)
            {
                augmented[i, j] /= pivot;
            }

            for (int k = 0; k < n; k++)
            {
                if (k != i)
                {
                    double factor = augmented[k, i];
                    for (int j = 0; j < 2 * n; j++)
                    {
                        augmented[k, j] -= factor * augmented[i, j];
                    }
                }
            }
        }

        double[,] inverse = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                inverse[i, j] = augmented[i, j + n];
            }
        }

        return inverse;
    }

    private static double GetCofactor(double[][] matrix, int row, int col)
    {
        int n = matrix.Length;
        double[][] minor = new double[n - 1][];

        for (int i = 0, minorRow = 0; i < n; i++)
        {
            if (i == row) continue; // Skip the row

            minor[minorRow] = new double[n - 1];
            for (int j = 0, minorCol = 0; j < n; j++)
            {
                if (j == col) continue; // Skip the column

                minor[minorRow][minorCol] = matrix[i][j];
                minorCol++;
            }

            minorRow++;
        }

        return ((row + col) % 2 == 0 ? 1 : -1) * CalculateDeterminant(minor, false, false).Determinant;
    }
}