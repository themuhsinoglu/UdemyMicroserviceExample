using MicroserviceExample.Catalog.API.Features.Courses.Create;

namespace MicroserviceExample.Catalog.API.Features.Courses;

public class CourseMapping : Profile
{
    public CourseMapping()
    {
        CreateMap<CreateCourseCommand, Course>();
    }
}