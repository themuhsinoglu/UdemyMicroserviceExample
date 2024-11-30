using MicroserviceExample.Catalog.API.Features.Courses.Create;
using MicroserviceExample.Catalog.API.Features.Courses.Dtos;

namespace MicroserviceExample.Catalog.API.Features.Courses;

public class CourseMapping : Profile
{
    public CourseMapping()
    {
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();
    }
}