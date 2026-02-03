using System.Text;

namespace ZeroSumGameCalculator.Domain
{
    public sealed class ZeroSumGameSolution
    {
        public static string ToPrettyString(GameResult r)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Status: {r.Status}");
            sb.AppendLine(double.IsNaN(r.Value) ? "Value: (n/a)" : $"Value (v): {r.Value:F6}");
            if(r.RowStrategy != null) 
                sb.AppendLine("Row strategy p: " + string.Join(", ", r.RowStrategy.Select(x => x.ToString("F6"))));
            if (r.ColStrategy != null)
                sb.AppendLine("Col strategy q: " + string.Join(", ", r.ColStrategy.Select(x => x.ToString("F6"))));

            return sb.ToString();
        }
    }
}
