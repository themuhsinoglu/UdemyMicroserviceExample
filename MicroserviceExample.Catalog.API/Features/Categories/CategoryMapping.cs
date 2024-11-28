using MicroserviceExample.Catalog.API.Features.Categories.Dtos;

namespace MicroserviceExample.Catalog.API.Features.Categories;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Categories.Category, CategoryDto>().ReverseMap();
    }
}