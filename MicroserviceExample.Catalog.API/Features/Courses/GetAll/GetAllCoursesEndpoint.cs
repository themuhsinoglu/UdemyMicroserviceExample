using MicroserviceExample.Catalog.API.Features.Courses.Dtos;

namespace MicroserviceExample.Catalog.API.Features.Courses.GetAll;

public record GetAllCoursesQuery() : IRequestByServiceResult<List<CourseDto>>;

public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses.AsNoTracking().ToListAsync(cancellationToken);
        // mongo db don't use include or join. So we can import relationship tables separately.
        //when we use db for mongo db, we don't use eager loading.
        var categories = await context.Categories.AsNoTracking().ToListAsync(cancellationToken:cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(c => c.Id == course.CategoryId);
        }
        
        var coursesAsDto = mapper.Map<List<CourseDto>>(courses);
        
        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
    }
}
public static class GetAllCoursesEndpoint
{
    public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
            (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
            .WithName("GetAllCourses")
            .MapToApiVersion(1,0);

        return group;
    }
}