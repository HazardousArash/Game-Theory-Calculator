using System;
using System.Linq;
using System.Linq.Expressions;
using ZeroSumGameCalculator.Domain;

namespace ZeroSumGameCalculator.MathTools
{
    public static class SaddlePointDetector
    {
        public static GameResult? TryFind(double[,] A, double tol)
        {
            int m = A.GetLength(0);
            int n = A.GetLength(1);

            double[] rowMins = new double[m];
            for (int i=0 ; i < m; i++)
            {
                double min = double.PositiveInfinity;
                for (int j = 0; j < n; j++) min = Math.Min(min, A[i, j]);
                rowMins[i] = min;
            }
            double vLower = rowMins.Max();
            int bestRow = Array.IndexOf(rowMins, vLower);

            double[] colMaxs = new double[n];
            for (int j = 0 ; j < n; j++)
            {
                double max = double.NegativeInfinity;
                for (int i = 0 ; i < m; i++) max = Math.Max(max, A[i, j]);
                colMaxs[j] = max; 
            }
            double vUpper = colMaxs.Min();
            int bestCol = Array.IndexOf(colMaxs, vUpper);

            if(Math.Abs(vLower - vUpper) <= tol)
            {
                var p = new double[m];
                var q = new double[n];
                p[bestRow] = 1.0;
                q[bestCol] = 1.0;

                return new GameResult
                {
                    Status = "Saddle point (pure strategies)",
                    Value = vLower,
                    RowStrategy = p,
                    ColStrategy = q
                };
            }
            return null; 
        }
    }
}
