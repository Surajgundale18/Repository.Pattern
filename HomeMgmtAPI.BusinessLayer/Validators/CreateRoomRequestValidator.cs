using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class CreateRoomRequestValidator : AbstractValidator<CreateRoomRequestDTO>
    {
       
        public CreateRoomRequestValidator()
        {
            
            RuleFor(x => x.RoomName)
                .NotNull().WithMessage("RoomName is required.")
                .MaximumLength(50);

            RuleFor(x => x.HomeId)
                .NotEmpty().WithMessage("HomeId is Required")
                .GreaterThan(0).WithMessage("Invalid HomeId.");
        } 

        
    }
}
