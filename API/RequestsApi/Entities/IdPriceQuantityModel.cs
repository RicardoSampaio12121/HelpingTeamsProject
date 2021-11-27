namespace RequestsApi.Entities
{
    public record IdPriceQuantityModel
    {
        public int id { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
    }
}
