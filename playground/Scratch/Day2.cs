namespace Scratch;

public class Counter
{
  public int Value { get; set; }
}

public struct CounterStruct
{
  public int Value { get; set; }
}

public readonly record struct DateRange(DateOnly From, DateOnly To)
{
  public int Days
}

