using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

public class Board
{
    [JsonProperty("_id")]
    public string BoardId { get; set; }

    public string Title { get; set; }

    public string Color { get; set; }

    public IEnumerable<KanbanList> Lists { get; set; }
}