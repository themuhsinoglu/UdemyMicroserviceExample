using MicroserviceExample.Catalog.API.Features.Categories.Create;
using MicroserviceExample.Catalog.API.Features.Categories.GetAll;
using MicroserviceExample.Catalog.API.Features.Categories.GetById;

namespace MicroserviceExample.Catalog.API.Features.Categories;

public static class CategoryEndpointExt
{
    public static void AddCategoryGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("api/categories").WithTags("Categories").CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint();
    }
}