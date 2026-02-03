namespace ZeroSumGameCalculator.Domain
{
    public sealed class GameResult
    {
        public string Status { get; init; } = "";
        public double Value { get; init;  }
        public double[]? RowStrategy { get; init; }
        public double[]? ColStrategy { get; init; }

    }
}
