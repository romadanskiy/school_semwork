using System.Collections.Generic;

namespace SchoolProj.Models
{
    public class Unit : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }
        public int NumberOfLessons { get; set; }

        public Unit(int id, int courseId, string name, int numberOfLessons)
        {
            Id = id;
            CourseId = courseId;
            Name = name;
            NumberOfLessons = numberOfLessons;
        }
    }
}