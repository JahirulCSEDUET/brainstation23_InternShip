using FluentValidation;

namespace PracticeProject.UnderstandingFluentValidation
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            RuleFor(student => student.Id)
                .NotEmpty().WithMessage("Student ID is required.")
                .InclusiveBetween(21400, 214120).WithMessage("Student ID must be between 214000 and 214120.");
            RuleFor(student => student.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please provide a valid email address.");
            RuleFor(student => student.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
                .WithMessage("Please provide a valid phone number format.");
        }
    }
}
