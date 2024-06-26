using System.ComponentModel.DataAnnotations;
using MatchSystem.Enums;
using MatchSystem.Helpers;

namespace MatchSystem.Elements;

public class Individual
{
    public Individual()
    {
        Id = IndividualIdGenerator.GetNextId();
    }
    public int Id { get; }
    public Gender Gender { get; set; }
    public int Age { get; private set; }
    [MaxLength(200)]
    public string Intro { get; set; } = string.Empty;
    public string Habits { get; private set; } = string.Empty;
    public required Coord Coord { get; set; }

    public void SetHabits(IEnumerable<string> habits)
    {
        var habitList = new List<string>();
        foreach(var habit in habits)
        {
            if (string.IsNullOrWhiteSpace(habit) || habit.Length > 10)
                throw new Exception("Habit length should be 0 to 10.");
            habitList.Add(habit);
        }
        Habits = string.Join(',', [.. habitList]);
    }

    public void SetAge(int age)
    {
        if (age < 18)
            throw new Exception("Age must be older than 18 years old.");
        Age = age;
    }
}
