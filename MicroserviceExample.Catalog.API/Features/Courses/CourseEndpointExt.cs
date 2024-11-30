using MicroserviceExample.Catalog.API.Features.Courses.Create;
using MicroserviceExample.Catalog.API.Features.Courses.GetAll;

namespace MicroserviceExample.Catalog.API.Features.Courses;

public static class CourseEndpointExt
{
    public static void AddCourseGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("api/courses").WithTags("Courses").CreateCourseGroupItemEndpoint()
            .GetAllCourseGroupItemEndpoint();
    }
}