using System;
using Newtonsoft.Json;

public class Card
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    public string Text { get; set; }

    public string Color { get; set; }

    public DateTime? Date { get; set; }
}