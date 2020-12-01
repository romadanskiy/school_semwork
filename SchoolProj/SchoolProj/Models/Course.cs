using System.Collections.Generic;

namespace SchoolProj.Models
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Subjects { get; set; }
        public List<Unit> Units { get; set; }
        public int Price { get; set; }
        public int NumberOfStudents { get; set; }

        public Course(int id, string name, string description, int price, int numberOfStudents)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            NumberOfStudents = numberOfStudents;
        }
    }
}