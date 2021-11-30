using System;

namespace RequestsApi.Entities
{
    /// <summary>
    /// Model of a pending request
    /// </summary>
    public record PendingRequestModel
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public DateTime Date { get; set; }
    }
}
