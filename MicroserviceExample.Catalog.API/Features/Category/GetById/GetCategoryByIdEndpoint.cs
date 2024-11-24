using System.Net;
using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using MicroserviceExample.Catalog.API.Features.Category.Dtos;
using MicroserviceExample.Catalog.API.Repositories;
using MicroserviceExample.Shared;
using MicroserviceExample.Shared.Extensions;

namespace MicroserviceExample.Catalog.API.Features.Category.GetById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;

public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var hasCategory = await context.Categories.FindAsync(request.Id,cancellationToken);

        if (hasCategory == null)
        {
            return ServiceResult<CategoryDto>.Error("Category not found", $"The category with id {request.Id} was not found", HttpStatusCode.NotFound);
        }
        
        var categoryAsDto = mapper.Map<CategoryDto>(hasCategory);
        
        return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
    }
}

public static class GetCategoryByIdEndpoint
{
    public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
            (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult())
            .WithName("GetByIdCategory");
        
        return group;
    }
}