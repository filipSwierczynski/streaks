namespace Scratch;

public interface IHasName
{
  string Name { get; }
}

public sealed record Habit(string Name, int TargetPerWeek) : IHasName;

public static class Day1
{
  public static void Run()
  {
    object thing = new Habit("Read", 7);

    Console.WriteLine(thing.GetType().FullName);
    Console.WriteLine(thing is Habit);
    Console.WriteLine(thing is IHasName);

    foreach (var property in thing.GetType().GetProperties())
    {
      Console.WriteLine($"{property.Name}: {property.PropertyType.Name} = {property.GetValue(thing)}");
    }

    var numbers = new List<int> { 1, 2, 3 };
    var words = new List<string> { "a" };

    Console.WriteLine(numbers.GetType() == words.GetType());
    Console.WriteLine(numbers.GetType().GetGenericArguments()[0].Name);
  }
}
