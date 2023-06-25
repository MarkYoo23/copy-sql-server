using Domain.SeedWorks;

namespace Domain.Models.Samples;

public class Sample : Entity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime CurrentDateTime { get; set; }
}
