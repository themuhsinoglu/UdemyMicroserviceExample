namespace MicroserviceExample.Catalog.API.Features.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} cannot br empty")
            .Length(4, 25).WithMessage("{PropertyName} must be between 4 and 25 characters");
    }
}