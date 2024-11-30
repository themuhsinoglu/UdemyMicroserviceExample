namespace MicroserviceExample.Catalog.API.Features.Courses.Delete;

public record DeleteCourseCommand(Guid Id) : IRequestByServiceResult;

public class DeleteCourseCommandHadnler(AppDbContext context) : IRequestHandler<DeleteCourseCommand,ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var hasCourse = await context.Courses.FindAsync([request.Id],cancellationToken : cancellationToken);
         
        if (hasCourse == null)
            return ServiceResult.ErrorAsNoFound();
        
        context.Courses.Remove(hasCourse);
        
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}

public static class DeleteCourseEndpoint
{
    public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", async (IMediator mediator,Guid id) =>
                (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult())
            .WithName("DeleteCourse");

        return group;
    }
    
}