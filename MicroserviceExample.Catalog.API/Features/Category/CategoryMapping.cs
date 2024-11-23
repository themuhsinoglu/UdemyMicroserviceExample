using AutoMapper;
using MicroserviceExample.Catalog.API.Features.Category.Dtos;

namespace MicroserviceExample.Catalog.API.Features.Category;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}