using System.Collections.Generic;
using Newtonsoft.Json;

public class Board
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    public string Title { get; set; }

    public string Color { get; set; }

    public List<KanbanList> Lists { get; set; }

    public List<string> Users { get; set; }
}