namespace To_do_list.Data.Entities.Enums
{
    using System.Text.Json.Serialization;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Statuses
    {
        Done,
        NotDone
    }
}
