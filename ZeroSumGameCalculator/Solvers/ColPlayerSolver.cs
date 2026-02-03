using Google.OrTools.LinearSolver;     

namespace ZeroSumGameCalculator.Solvers
{
    public sealed class ColPlayerSolver
    {
        public (double value, double[] strategy, string status) Solve(double[,] A)
        {
            int m = A.GetLength(0);      
            int n = A.GetLength(1);     

            Solver solver = Solver.CreateSolver("GLOP");

            if (solver == null)
                throw new Exception("Could not create OR-Tools solver (GLOP).");

            var q = new Variable[n];
            for (int j = 0; j < n; j++)
                q[j] = solver.MakeNumVar(0.0, 1.0, $"q{j}");

            var v = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "v");

            // Constraint: Σ_j q[j] = 1
            var sumQ = solver.MakeConstraint(1.0, 1.0, "sumQ");
            for (int j = 0; j < n; j++)
                sumQ.SetCoefficient(q[j], 1.0);

            for (int i = 0; i < m; i++)
            {
                var ct = solver.MakeConstraint(double.NegativeInfinity, 0.0, $"row_{i}");

                // Add Σ_j q[j] * A[i,j]
                for (int j = 0; j < n; j++)
                    ct.SetCoefficient(q[j], A[i, j]);

                // Add -v
                ct.SetCoefficient(v, -1.0);
            }

            // Objective: minimize v
            var obj = solver.Objective();
            obj.SetCoefficient(v, 1.0);   
            obj.SetMinimization();      

            // Solve LP
            var status = solver.Solve();

            if (status != Solver.ResultStatus.OPTIMAL)
            {
                return (double.NaN, Array.Empty<double>(), $"ColPlayer: Not optimal (status {status})");
            }

            return 
            (
                v.SolutionValue(),                   
                q.Select(x => x.SolutionValue()).ToArray(),
                "ColPlayer: Optimal (LP)"
            );
        }
    }
}
