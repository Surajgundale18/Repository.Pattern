namespace HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs
{
    public class HomeResponseDTO
    {
        public int HomeId { get; set; }

        public string HomeName { get; set; }

        public AddressResponseDTO Address { get; set; }
        public List<RoomResponseDTO> Rooms { get; set; }
    }
}
