using FluentValidation;

namespace WorkerTracking.Application.Features.Departments.Update;

public sealed class UpdateDepartmentCommandValidator
    : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .MaximumLength(100);
        RuleFor(x => x.Description)
            .MaximumLength(500);   
    }
}    