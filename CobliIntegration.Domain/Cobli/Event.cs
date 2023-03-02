namespace CobliIntegration.Domain.Cobli
{
    public class ResponseEvent
    {
        public IList<Event> Data { get; set; }
    }

    public class GetEventsFilter
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Timezone { get; set; }
        public int Limit { get; set; }
        public int PageNumber { get; set; }

    }

    public class Event
    {
        public object driver { get; set; }
        public Vehicle vehicle { get; set; }
        public Device device { get; set; }
        public string event_type { get; set; }
        public DateTime event_time { get; set; }
        public Location location { get; set; }
    }

    public class Device
    {
        public string id { get; set; }
        public string cobli_id { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Vehicle
    {
        public string id { get; set; }
        public string license_plate { get; set; }
        public object group { get; set; }
    }

}
