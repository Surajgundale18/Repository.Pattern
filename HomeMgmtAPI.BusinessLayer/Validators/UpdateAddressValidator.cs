using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequestDTO>
    {
        public UpdateAddressValidator() 
        {
            RuleFor(x => x.AddressId).NotEmpty().WithMessage("AddressId is Required");

            RuleFor(x => x.HomeId).NotEmpty().WithMessage("HomeId is Required");
        }
    }
}
