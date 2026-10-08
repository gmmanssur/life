using Life.Domain.Enums;

namespace Life.Application.UseCases.Homeworks;

public sealed class HomeworkRequest
{
    public required string Title { get; init; }
    public HomeworkPriority Priority { get; init; }
    public HomeworkFrequency Frequency { get; init; }
}