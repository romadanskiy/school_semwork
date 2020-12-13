namespace SchoolProj.Models
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}