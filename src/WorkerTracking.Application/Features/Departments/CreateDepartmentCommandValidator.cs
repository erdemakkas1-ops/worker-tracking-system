using FluentValidation;

namespace WorkerTracking.Application.Features.Departments.Create;

public sealed class CreateDepartmentCommandValidator
    : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(x => x.Name)
             .NotEmpty()
             .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);     
             
    }
}    