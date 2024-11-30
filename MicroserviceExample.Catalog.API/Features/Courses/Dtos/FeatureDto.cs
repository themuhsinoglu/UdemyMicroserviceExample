namespace MicroserviceExample.Catalog.API.Features.Courses.Dtos;

public class FeatureDto
{
    public int Duration { get; set; }
    public float Rating { get; set; }
    public string EdacatorFullName { get; set; } = default!;
}