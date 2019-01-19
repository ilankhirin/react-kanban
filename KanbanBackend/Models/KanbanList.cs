using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

public class KanbanList
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    public string Title { get; set; }

    public IEnumerable<Card> Cards { get; set; }
}