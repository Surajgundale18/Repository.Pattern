using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class CreateHomeRequestValidator : AbstractValidator<CreateHomeRequestDTO>
    {

        public CreateHomeRequestValidator()
        {

            RuleFor(x => x.HomeName)
                .NotEmpty().WithMessage("Home Name is required")
                .Must(name => !name.Trim().ToLower().Equals("string")).WithMessage("Invalid Name")
                .MaximumLength(50);

        }


    }
}
