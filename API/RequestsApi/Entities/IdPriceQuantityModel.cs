namespace RequestsApi.Entities
{
    /// <summary>
    /// Model os something
    /// </summary>
    public record IdPriceQuantityModel
    {
        public int id { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
    }
}
