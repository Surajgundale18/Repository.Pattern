using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class UpdateHomeRequestValidator : AbstractValidator<UpdateHomeRequestDTO>
    {

        public UpdateHomeRequestValidator()
        {

            RuleFor(x => x.HomeId)
            .NotNull().WithMessage("HomeId is required.")
            .GreaterThan(0).WithMessage("HomeId must be greater than zero.");

            RuleFor(x => x.HomeName).NotEmpty().WithMessage("HomeName is required");

        }
       
    }
}
