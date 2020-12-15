using System;

namespace SchoolProj.Models
{
    public class Purchase : IEntity
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }

        public Purchase(int usersId, int courseId, DateTime purchaseDate, int price)
        {
            UsersId = usersId;
            CourseId = courseId;
            PurchaseDate = purchaseDate;
            Price = price;
        }
        
        public Purchase(int id, int usersId, int courseId, DateTime purchaseDate, int price)
        {
            Id = id;
            UsersId = usersId;
            CourseId = courseId;
            PurchaseDate = purchaseDate;
            Price = price;
        }
    }
}