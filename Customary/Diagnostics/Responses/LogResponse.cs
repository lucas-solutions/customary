using Newtonsoft.Json;

namespace Custom.Diagnostics.Responses
{
    public class LogResponse
    {
        [JsonProperty("eventstamp")]
        public int TimeStamp { get; set; }
        public bool Success { get; set; }
    }
}