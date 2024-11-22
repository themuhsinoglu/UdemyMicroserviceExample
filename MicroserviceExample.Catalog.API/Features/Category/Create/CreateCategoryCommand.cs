using MediatR;
using MicroserviceExample.Shared;

namespace MicroserviceExample.Catalog.API.Features.Category.Create;

public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;