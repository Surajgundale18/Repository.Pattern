using System.Text.Json.Serialization;

namespace HomeMgmtAPI.DataLayer.DataEntities
{
    public class Home
    {
        public int HomeId { get; set; }
        public string HomeName { get; set; }
        public Address Address { get; set; }

       
        public List<Room> Rooms { get; set; }
    }
}
