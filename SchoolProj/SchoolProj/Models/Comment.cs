using System;

namespace SchoolProj.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string CommentText { get; set; }
        public DateTime CreationDate { get; set; }

        public Comment(int usersId, string commentText, DateTime creationDate)
        {
            UsersId = usersId;
            CommentText = commentText;
            CreationDate = creationDate;
        }

        public Comment(int courseId, int usersId, string commentText, DateTime creationDate)
        {
            CourseId = courseId;
            UsersId = usersId;
            CommentText = commentText;
            CreationDate = creationDate;
        }
    }
}