namespace Scratch;

public abstract record Schedule
{
  private Schedule() { }

  public sealed record Daily : Schedule;
  public sealed record TimesPerWeek(int Count) : Schedule;
  public sealed record Weekdays(int Mask) : Schedule;
}

public static class Day03
{
  public static string Describe(Schedule s) => s switch
  {
    Schedule.Daily => "every day",
    Schedule.TimesPerWeek t => $"{t.Count}x per week",
    _ => throw new ArgumentOutOfRangeException(nameof(s), s, "Unhandled schedule")
  };

  public static void Run()
  {
    Console.WriteLine(Describe(new Schedule.Daily()));
    Console.WriteLine(Describe(new Schedule.TimesPerWeek(3)));

    var cases = typeof(Schedule).GetNestedTypes().Where(t => t.IsSubclassOf(typeof(Schedule)));
    foreach (var type in cases)
    {
      Describe((Schedule)Activator.CreateInstance(type)!);
      Console.WriteLine($"case found: {type.Name}");
    }
  }
}


