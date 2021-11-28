using System;

namespace RequestsApi.Entities
{
    public record CompletedRequestModel
    {
        public int id { get; set; }
        public int teamId { get; set; }
        public float price { get; set; }
        public DateTime date { get; set; }
        public string decision { get; set; }
    }
}
