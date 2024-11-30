using Asp.Versioning.Builder;
using MicroserviceExample.Catalog.API.Features.Courses.Create;
using MicroserviceExample.Catalog.API.Features.Courses.Delete;
using MicroserviceExample.Catalog.API.Features.Courses.GetAll;
using MicroserviceExample.Catalog.API.Features.Courses.GetAllByUserId;
using MicroserviceExample.Catalog.API.Features.Courses.GetById;
using MicroserviceExample.Catalog.API.Features.Courses.Update;

namespace MicroserviceExample.Catalog.API.Features.Courses;

public static class CourseEndpointExt
{
    public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses")
            .WithApiVersionSet(apiVersionSet)
            .CreateCourseGroupItemEndpoint()
            .GetAllCourseGroupItemEndpoint()
            .GetByIdCourseGroupItemEndpoint()
            .UpdateCourseGroupItemEndpoint()
            .DeleteCourseGroupItemEndpoint()
            .GetByUserIdCourseGroupItemEndpoint();
    }
}