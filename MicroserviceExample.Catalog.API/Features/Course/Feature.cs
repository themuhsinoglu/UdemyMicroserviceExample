namespace MicroserviceExample.Catalog.API.Features.Course;

public class Feature
{
    public int Duration { get; set; }
    public float Rating { get; set; }
    public string EducatorFullName { get; set; } = default!;
}