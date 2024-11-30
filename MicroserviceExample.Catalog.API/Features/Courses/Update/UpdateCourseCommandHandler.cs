namespace MicroserviceExample.Catalog.API.Features.Courses.Update;

public class UpdateCourseCommandHandler(AppDbContext context, IMapper mapper)
    : IRequestHandler<UpdateCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var hasCourse = await context.Courses.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);

        if (hasCourse is null)
        {
            return ServiceResult.ErrorAsNoFound();
        }
        
        var updatedCourse = mapper.Map<Course>(request);
        
        context.Update(updatedCourse);
        
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}

