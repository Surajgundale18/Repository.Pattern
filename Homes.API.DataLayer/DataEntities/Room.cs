namespace HomeMgmtAPI.DataLayer.DataEntities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int HomeId { get; set; }
        // navigation prop
        public Home Home { get; set; }
    }

}
