namespace RequestsApi.Entities
{
    /// <summary>
    /// Model of a team member
    /// </summary>
    public record TeamMemberModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public int Team { get; init; }
        public string Organization { get; init; }
    }
}