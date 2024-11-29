using MicroserviceExample.Catalog.API.Features.Courses.Create;

namespace MicroserviceExample.Catalog.API.Features.Courses;

public static class CourseEndpointExt
{
    public static void AddCourseGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("api/courses").WithTags("Courses").CreateCourseGroupItemEndpoint();
    }
}