using MicroserviceExample.Catalog.API.Features.Courses.Dtos;

namespace MicroserviceExample.Catalog.API.Features.Courses.Update;

public record UpdateCourseCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string? ImageUrl,
    Guid CategoryId,
    Feature Feature) : IRequestByServiceResult;