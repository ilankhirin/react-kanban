using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

public class Card
{
    [JsonProperty("_id")]
    public string CardId { get; set; }

    public string Text { get; set; }

    public string Color { get; set; }

    public DateTime? Date { get; set; }
}