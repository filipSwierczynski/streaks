var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var habits = new List<HabitDto> { new(1, "Read"), new(2, "Stretch") };

app.MapGet("/habits", () => habits);

app.MapGet("/habits/{id:int}", (int id) => habits.FirstOrDefault(h => h.Id == id) is { } habit ? Results.Ok(habit) : Results.NotFound()
);

app.MapPost("/habits", (CreateHabit body) =>
{
  var habit = new HabitDto(habits.Max(h => h.Id) + 1, body.Name);
  habits.Add(habit);
  return Results.Created($"/habits/{habit.Id}", habit);
});

app.Run();

internal sealed record HabitDto(int Id, string Name);
internal sealed record CreateHabit(string Name);
