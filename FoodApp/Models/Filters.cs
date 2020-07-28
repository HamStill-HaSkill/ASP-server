using System.Collections.Generic;
using Newtonsoft.Json;

class Filters
{
    [JsonProperty("Filters")]
    public List<RequestInfo> RequestInfos { get; set; }
}