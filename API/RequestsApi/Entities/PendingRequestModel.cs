using System;

namespace RequestsApi.Entities
{
    public record PendingRequestModel
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public DateTime Date { get; set; }
    }
}
