namespace Logic.Entities
{
    public record TeamMemberModel
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Organization { get; init; }
    }
}