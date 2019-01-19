using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nest;
using Newtonsoft.Json;

public class Board
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    public string Title { get; set; }

    public string Color { get; set; }

    public IEnumerable<KanbanList> Lists { get; set; }
}