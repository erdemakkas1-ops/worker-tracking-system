using FluentValidation;

namespace WorkerTracking.Application.Features.Employees.Create;

public sealed class CreateEmployeeCommandValidator
    : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeNumber)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20);

        RuleFor(x => x.DepartmentId)
            .NotNull()
            .WithMessage("Department seçilmelidir.");
    }
}