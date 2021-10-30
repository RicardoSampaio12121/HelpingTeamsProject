namespace RequestsApi.Entities
{
    public record Product
    {
        public string Name { get; init; }
        public int Quantity { get; init; }
    }
}