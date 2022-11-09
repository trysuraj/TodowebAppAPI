namespace TodoWebAppAPI.models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public int Date{ get; set; }
    }
}
