namespace RequestsApi.Entities
{
    public record CompletedRequestProductModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int requestId { get; set; }
    
    }
}
