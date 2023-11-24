namespace HomeMgmtAPI.DataLayer.DataEntities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int HomeId { get; set; }
        public Home Home { get; set; }
    }

}
