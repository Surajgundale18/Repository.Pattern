namespace HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs
{
    public class AddressResponseDTO
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int HomeId { get; set; }
    }
}
