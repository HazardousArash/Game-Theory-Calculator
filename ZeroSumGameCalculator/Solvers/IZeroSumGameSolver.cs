using System;
using ZeroSumGameCalculator.Domain;

namespace ZeroSumGameCalculator.Solvers
{
    public interface IZeroSumGameSolver
    {
        GameResult Solve(double[,] payoffMatrix, double tol = 1e-7);
    }
}
