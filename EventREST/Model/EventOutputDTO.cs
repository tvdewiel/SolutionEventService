namespace EventREST.Model
{
    public class EventOutputDTO
    {
        public EventOutputDTO(string name, DateTime date, string location, int maxVisitors, List<string> visitors)
        {
            Name = name;
            Date = date;
            Location = location;
            MaxVisitors = maxVisitors;
            Visitors = visitors;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxVisitors { get; set; }
        public List<string> Visitors { get; set; }

    }
}
