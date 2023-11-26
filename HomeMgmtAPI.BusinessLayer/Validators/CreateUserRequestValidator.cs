using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<UserRequestDTO>
    {
        public CreateUserRequestValidator() 
        {
           RuleFor(x=> x.Name).NotEmpty().WithMessage("UserName is required");

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Password is required");
                 //.MinimumLength(4).WithMessage("Password must be at least 8 characters long")
                 //.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                 //.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                 //.Matches("[0-9]").WithMessage("Password must contain at least one digit")
                 //.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
        }
    }
}
