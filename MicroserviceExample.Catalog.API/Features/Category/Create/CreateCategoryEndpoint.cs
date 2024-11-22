using MediatR;
using MicroserviceExample.Shared.Extensions;

namespace MicroserviceExample.Catalog.API.Features.Category.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/",
                async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult())
            .WithName("CreateCategory");
        
        return group;
    }
}