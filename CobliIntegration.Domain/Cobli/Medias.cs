using System.Text.Json.Serialization;

namespace CobliIntegration.Domain.Cobli
{
    public class MediaResponse
    {
        public IList<Media> data { get; set; }
    }

    public class GetMediaFilter
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Timezone { get; set; }
        public int Limit { get; set; }
        public int PageNumber { get; set; }
        public IList<Guid> DriverIds { get; set; }
        public IList<string> DeviceIds { get; set; }
    }

    public class Media
    {
        public Guid id { get; set; }
        public string device_id { get; set; }
        public string driver_id { get; set; }       
        public MediaDetails details { get; set; }
        public string type { get; set; }
        public string datetime { get; set; }

    }

    public class MediaDetails
    {
        //[JsonPropertyName("media_url")]
        public string media_url { get; set; }
        public string event_trigger { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Speed { get; set; }
    }

    public class MediaLinkResponse
    {
        public MediaLink data { get; set; }
    }

    public class MediaLink
    {
        public string media_url { get; set; }
        public string expiration_date { get; set; }
    }
}
