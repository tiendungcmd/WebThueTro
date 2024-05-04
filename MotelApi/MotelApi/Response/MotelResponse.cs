using MotelApi.Common;

namespace MotelApi.Response
{
    public class MotelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public Status Status { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int NumberBedRoom { get; set; }
        public int NumberBathRoom { get; set; }
        public int Acreage { get; set; }
        public int Deposit { get; set; }
        public string Images { get; set; }
        public string Title { get; set; }
    }
}
