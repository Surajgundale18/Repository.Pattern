using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class CreateAddressValidator : AbstractValidator<CreateAddresssRequestDTO>
    {
        public CreateAddressValidator() 
        {
            RuleFor(x=>x.HomeId).NotEmpty().WithMessage("HomeId is required");      
        }
    }
}
