using AutoMapper;
using MediatR;
using MicroserviceExample.Catalog.API.Features.Category.Dtos;
using MicroserviceExample.Catalog.API.Repositories;
using MicroserviceExample.Shared;
using MicroserviceExample.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceExample.Catalog.API.Features.Category.GetAll;

public record GetAllCategoriesQuery : IRequest<ServiceResult<List<CategoryDto>>>;

public class GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, ServiceResult<List<CategoryDto>>>
{
    public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await context.Categories.ToListAsync(cancellationToken);

        var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);

        return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoriesAsDto);
    }
}

public static class GetAllCategoriesEndpoint
{
    public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/",
            async (IMediator mediator) => (await mediator.Send(new GetAllCategoriesQuery())).ToGenericResult());

        return group;
    }
}