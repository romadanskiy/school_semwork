namespace SchoolProj.Models
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public Lesson(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}