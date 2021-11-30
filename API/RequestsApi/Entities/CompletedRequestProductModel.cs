namespace RequestsApi.Entities
{
    /// <summary>
    /// Model of a completed request product
    /// </summary>
    public record CompletedRequestProductModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int requestId { get; set; }
    
    }
}
