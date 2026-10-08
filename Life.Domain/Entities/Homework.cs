using Life.Domain.Enums;

namespace Life.Domain.Entities;

public class Homework
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public HomeworkPriority Priority { get; private set; }
    public HomeworkFrequency Frequency { get; private set; }

    private Homework() { }

    public Homework(
        string title,
        HomeworkPriority priority,
        HomeworkFrequency frequency)
    {
        Validate(title, priority, frequency);

        Id = Guid.NewGuid();
        Title = title;
        Priority = priority;
        Frequency = frequency;
    }

    public void Update(
        string title,
        HomeworkPriority priority,
        HomeworkFrequency frequency)
    {
        Validate(title, priority, frequency);

        Title = title;
        Priority = priority;
        Frequency = frequency;
    }

    private static void Validate(
        string title,
        HomeworkPriority priority,
        HomeworkFrequency frequency)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Homework title is required.",
                nameof(title));

        if (title.Length > 50)
            throw new ArgumentException(
                "Homework title cannot exceed 50 characters.",
                nameof(title));

        if (!Enum.IsDefined(priority))
            throw new ArgumentException(
                "Invalid homework priority.",
                nameof(priority));

        if (!Enum.IsDefined(frequency))
            throw new ArgumentException(
                "Invalid homework frequency.",
                nameof(frequency));
    }
}