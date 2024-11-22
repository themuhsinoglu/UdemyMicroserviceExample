using System.Net;
using MassTransit;
using MediatR;
using MicroserviceExample.Catalog.API.Repositories;
using MicroserviceExample.Shared;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceExample.Catalog.API.Features.Category.Create;

public class
    CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
{
    public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var existCategory = await context.Categories.AnyAsync(c => c.Name == request.Name, cancellationToken: cancellationToken);

        if (existCategory)
        {
            return ServiceResult<CreateCategoryResponse>.Error("Category already exists",$"The category name '{request.Name}' already exists.", HttpStatusCode.BadRequest);
        }

        var category = new Category()
        {
            Name = request.Name,
            Id = NewId.NextSequentialGuid()
        };
        
        await context.Categories.AddAsync(category, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id),"<empty>");
        
    }
}