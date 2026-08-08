using FluentValidation;

namespace WorkerTracking.Application.Features.Employees.Update;

public sealed class UpdateEmployeeCommandValidator
    : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeNumber)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20);
    }
}