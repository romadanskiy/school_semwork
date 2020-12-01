﻿using System;

namespace SchoolProj.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int UsersId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}