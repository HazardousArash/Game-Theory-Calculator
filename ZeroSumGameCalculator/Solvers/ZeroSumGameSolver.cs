using System;
using ZeroSumGameCalculator.Domain;           
using ZeroSumGameCalculator.MathTools;

namespace ZeroSumGameCalculator.Solvers
{
    // 1) checks for saddle point (pure strategies)
    // 2) otherwise solves LPs for both players
    // 3) merges results into a single GameResult
    public sealed class ZeroSumGameSolver : IZeroSumGameSolver
    {
        private readonly RowPlayerSolver _rowSolver = new();
        private readonly ColPlayerSolver _colSolver = new();

        public GameResult Solve(double[,] payoffMatrix, double tol = 1e-7)
        {
            // STEP 1 — Check for saddle point (pure strategies)
            var saddle = SaddlePointDetector.TryFind(payoffMatrix, tol);
            if (saddle != null)
                return saddle;

            // STEP 2 — Solve row player's LP (maximize v)
            var (rowV, p, rowStatus) = _rowSolver.Solve(payoffMatrix);

            // STEP 3 — Solve column player's LP (minimize v)
            var (colV, q, colStatus) = _colSolver.Solve(payoffMatrix);

            // STEP 4 — Decide final game value
            var status = rowStatus.Replace("RowPlayer:", "Optimal:");

            if (double.IsFinite(rowV) &&
                double.IsFinite(colV) &&
                Math.Abs(rowV - colV) > 1e-5)
            {
                status += $" | Warning: row v={rowV:F6}, col v={colV:F6}";
            }
            return new GameResult
            {
                Status = status,
                Value = rowV,
                RowStrategy = p.Length == 0 ? null : p,
                ColStrategy = q.Length == 0 ? null : q
            };
        }
    }
}