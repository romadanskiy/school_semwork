using System;

namespace SchoolProj.Models
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate  { get; set; }
        public int NumberOfCourses { get; set; }

        public Users(string name, string password, DateTime registrationDate)
        {
            Name = name;
            Password = password;
            RegistrationDate = registrationDate;
        }
        
        public Users(int id, string name, string password, DateTime registrationDate, int numberOfCourses)
        {
            Id = id;
            Name = name;
            Password = password;
            RegistrationDate = registrationDate;
            NumberOfCourses = numberOfCourses;
        }
    }
}