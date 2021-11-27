namespace RequestsApi.Entities
{
    public record PendingRequestProductModel
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public int pendingRequestId { get; set; }
    }
}
