using Life.Domain.Enums;

namespace Life.Domain.Entities;

public class Homework
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public HomeworkPriority Priority { get; private set; }
    public HomeworkFrequency Frequency { get; private set; }

    private Homework() { }

    public Homework(
        string description,
        HomeworkPriority priority,
        HomeworkFrequency frequency)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException(
                "Homework description is required.",
                nameof(description));

        if (description.Length > 50)
            throw new ArgumentException(
                "Homework description cannot exceed 50 characters.",
                nameof(description));

        if (!Enum.IsDefined(priority))
            throw new ArgumentException(
                "Invalid homework priority.",
                nameof(priority));

        if (!Enum.IsDefined(frequency))
            throw new ArgumentException(
                "Invalid homework frequency.",
                nameof(frequency));

        Id = Guid.NewGuid();
        Description = description;
        Priority = priority;
        Frequency = frequency;
    }
}