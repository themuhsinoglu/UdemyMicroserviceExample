namespace MicroserviceExample.Catalog.API.Features.Categories;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<Courses.Course>? Courses { get; set; }
}