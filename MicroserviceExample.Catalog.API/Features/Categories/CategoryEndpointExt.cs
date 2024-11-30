using Asp.Versioning.Builder;
using MicroserviceExample.Catalog.API.Features.Categories.Create;
using MicroserviceExample.Catalog.API.Features.Categories.GetAll;
using MicroserviceExample.Catalog.API.Features.Categories.GetById;

namespace MicroserviceExample.Catalog.API.Features.Categories;

public static class CategoryEndpointExt
{
    public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
            .WithApiVersionSet(apiVersionSet)
            .CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint();
    }
}