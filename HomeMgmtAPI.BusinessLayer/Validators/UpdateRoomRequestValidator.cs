using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;

namespace HomeMgmtAPI.BusinessLayer.Validators
{
    public class UpdateRoomRequestValidator : AbstractValidator<UpdateRoomRequestDTO>
    {
        public UpdateRoomRequestValidator()
        {
            RuleFor(x => x.RoomId)
                .NotNull().WithMessage("RoomId is required")
                .GreaterThan(0).WithMessage("Invalid RoomId");

            RuleFor(x => x.RoomName)
                .NotEmpty().WithMessage("RoomName is required.")
                .MaximumLength(50);
        }
    }
}
