using API.DTOs.Roles;
using FluentValidation;

namespace API.Utilities.Validations.Role
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
    {

        //validation untuk create role
        public CreateRoleValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
