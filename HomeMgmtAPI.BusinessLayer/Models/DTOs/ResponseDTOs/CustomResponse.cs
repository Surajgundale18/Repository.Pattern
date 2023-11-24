namespace HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs
{
    public class CustomResponse
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public List<ErrorDetail> Errors { get; set; }

    }
}
