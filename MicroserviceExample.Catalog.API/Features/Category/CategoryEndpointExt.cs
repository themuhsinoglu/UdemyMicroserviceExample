using MicroserviceExample.Catalog.API.Features.Category.Create;
using MicroserviceExample.Catalog.API.Features.Category.GetAll;
using MicroserviceExample.Catalog.API.Features.Category.GetById;

namespace MicroserviceExample.Catalog.API.Features.Category;

public static class CategoryEndpointExt
{
    public static void AddCategoryGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("api/categories").WithTags("Categories").CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint();
    }
}