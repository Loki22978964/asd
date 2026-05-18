using System;

namespace ConsoleApp2
{
    public class LupSolver
    {
        public static (double[,] L, double[,] U, int[] P) Decompose(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] L = new double[n, n];
            double[,] U = (double[,])A.Clone();
            int[] P = new int[n];

            for (int i = 0; i < n; i++) P[i] = i;

            for (int i = 0; i < n; i++)
            {
                int pivotRow = i;
                for (int r = i + 1; r < n; r++)
                {
                    if (Math.Abs(U[r, i]) > Math.Abs(U[pivotRow, i]))
                        pivotRow = r;
                }

                if (pivotRow != i)
                {
                    SwapRows(U, i, pivotRow);
                    SwapRows(L, i, pivotRow);
                    int temp = P[i]; P[i] = P[pivotRow]; P[pivotRow] = temp;
                }

                for (int r = i + 1; r < n; r++)
                {
                    double factor = U[r, i] / U[i, i];
                    L[r, i] = factor;

                    for (int c = i; c < n; c++)
                    {
                        U[r, c] -= factor * U[i, c];
                    }
                }
            }

            for (int i = 0; i < n; i++) L[i, i] = 1.0;

            return (L, U, P);
        }

        public static double[] ForwardSubstitution(double[,] L, double[] b, int[] P)
        {
            int n = L.GetLength(0);
            double[] y = new double[n];

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += L[i, j] * y[j];
                }
                y[i] = b[P[i]] - sum;
            }
            return y;
        }

        public static double[] BackwardSubstitution(double[,] U, double[] y)
        {
            int n = U.GetLength(0);
            double[] x = new double[n];

            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += U[i, j] * x[j];
                }
                x[i] = (y[i] - sum) / U[i, i];
            }
            return x;
        }

        private static void SwapRows(double[,] matrix, int row1, int row2)
        {
            int cols = matrix.GetLength(1);
            for (int c = 0; c < cols; c++)
            {
                double temp = matrix[row1, c];
                matrix[row1, c] = matrix[row2, c];
                matrix[row2, c] = temp;
            }
        }
    }
}