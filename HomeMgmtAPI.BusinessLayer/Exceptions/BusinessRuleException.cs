using FluentValidation.Results;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;

namespace HomeMgmtAPI.BusinessLayer.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException() : base("One or more validation errors occurred.") { }

        public BusinessRuleException(string errorMessage) : base(errorMessage) { }

        public BusinessRuleException(List<ValidationFailure> validationFailures)
        {
            Errors = validationFailures.Select(x=> new ErrorDetail
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }).ToList();
        }

        public BusinessRuleException(List<ErrorDetail> validationFailures)
        {
            Errors = validationFailures;
        }

        public List<ErrorDetail> Errors { get; set; }
    }
}
