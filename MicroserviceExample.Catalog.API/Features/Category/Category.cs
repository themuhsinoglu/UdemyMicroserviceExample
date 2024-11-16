using MicroserviceExample.Catalog.API.Repositories;

namespace MicroserviceExample.Catalog.API.Features.Category;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<Course.Course>? Courses { get; set; }
}