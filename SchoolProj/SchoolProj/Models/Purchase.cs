using System;

namespace SchoolProj.Models
{
    public class Purchase : IEntity
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int CourseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
    }
}