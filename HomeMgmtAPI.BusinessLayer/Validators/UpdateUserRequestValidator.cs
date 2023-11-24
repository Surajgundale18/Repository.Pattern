using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequsetDTO>
    {
        public UpdateUserRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("UserName Is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(x=> x.Id).NotNull().WithMessage("Id is required");
        }
    }
}
