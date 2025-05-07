namespace EventREST.Model
{
    public class VisitorInputDTO
    {
        public VisitorInputDTO(string name, DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }

        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
