namespace Scratch;

public class HabitA
{
  public string Name {get; private set;} = "";
  public bool IsArchived { get; set;}
  public DateTime? ArchivedAt {get; set;}
  public HabitA(string name){
    this.Name = name;
  }
   public void Archive(){
      this.IsArchived = true;
      this.ArchivedAt = DateTime.UtcNow;
    }
}



public abstract record HabitB(string Name)
{
  public sealed record Active(string Name) : HabitB(Name);
  public sealed record Archived(string Name, DateTime ArchivedAt) : HabitB(Name);
}

public static class Day02
{
  public static void Run()
  {
    // Compiles, but it's nonsense
    var bad = new HabitA("Read");
    bad.Archive();

    HabitB good = new HabitB.Active("Read");

    var r = new HabitB.Active("Read");
    var r2 = r with {Name = "Write"};
    var impossible = new HabitB.Active(("Impossible"));
    Console.WriteLine(impossible);


    Console.WriteLine(DescribeA(bad));
    Console.WriteLine(DescribeB(good));
    Console.WriteLine(new HabitB.Active("Read") == new HabitB.Active("Read"));
    Console.WriteLine(new HabitA("Read") == new HabitA("Read"));
  }

  private static string DescribeA(HabitA h) => h.IsArchived ? $"archived at {h.ArchivedAt}" : "active";

  private static string DescribeB(HabitB h) => h switch {
    HabitB.Archived a => $"archived at {a.ArchivedAt:yyy-MM-dd}",
    HabitB.Active => "active",
    _ => throw new InvalidOperationException("unknown state"),
  };
}
