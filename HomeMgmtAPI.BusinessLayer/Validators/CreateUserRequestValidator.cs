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

           RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
