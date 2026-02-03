using System;
using System.Linq;
using Google.OrTools.LinearSolver;
using ZeroSumGameCalculator.Domain;

namespace ZeroSumGameCalculator.Solvers
{
    public sealed class RowPlayerSolver
    {
        public (double value, double[] strategy, string status) Solve(double[,] A)
        {
            int m = A.GetLength(0);
            int n = A.GetLength(1);

            Solver solver = Solver.CreateSolver("GLOP");
            if (solver == null) throw new Exception("Could not create OR-Tools solver (GLOP).");

            var p = new Variable[m];
            for (int i = 0; i < m; i++)
                p[i] = solver.MakeNumVar(0.0, 1.0, $"p{i}"); // 0 <= p[i] <= 1                                           

            var v = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "v");
            // v is free: (-inf, +inf)

            var sumP = solver.MakeConstraint(1.0, 1.0, "sumP"); // lower=1, upper=1 means equality

            for (int i = 0; i < m; i++)
                sumP.SetCoefficient(p[i], 1.0);

            //   Σ_i p[i] * A[i,j] - v >= 0
            for (int j = 0; j < n; j++)
            {
                var ct = solver.MakeConstraint(0.0, double.PositiveInfinity, $"col_{j}");

                // Add Σ_i p[i] * A[i,j]
                for (int i = 0; i < m; i++)
                    ct.SetCoefficient(p[i], A[i, j]);

                // Add -v to the expression
                ct.SetCoefficient(v, -1.0);
            }

            // Objective: maximize v
            var obj = solver.Objective();   
            obj.SetCoefficient(v, 1.0);      
            obj.SetMaximization();

            var status = solver.Solve();

            if (status != Solver.ResultStatus.OPTIMAL)
            {
                return (double.NaN, Array.Empty<double>(), $"RowPlayer: Not optimal (status {status})");
            }

            return 
            (
                v.SolutionValue(),
                p.Select(x => x.SolutionValue()).ToArray(),
                "RowPlayer: Optimal (LP via OR-Tools GLOP)"
            );
        }
    }
}
