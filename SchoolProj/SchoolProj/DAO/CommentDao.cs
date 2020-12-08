using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class CommentDao : IDao<Comment>
    {
        public override string ToString()
        {
            return "comment";
        }

        public Comment GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Comment comment)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    this.Insert(
                        new[] {"course_id", "user_id", "text", "date"},
                        new object[] {comment.CourseId, comment.UsersId, comment.CommentText, comment.CreationDate.ToString("d")}),
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Comment t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Comment> GetByCourseId(int courseId)
        {
            var comments = new List<Comment>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectByFKey("course_id", courseId), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var comment = GetComment(record);
                        comment.UsersName = new UsersDao().GetById(comment.UsersId).Name;
                        comments.Add(comment);
                    }
                }
            }
            return comments;
        }

        private static Comment GetComment(IDataRecord record)
        {
            return new Comment(
                int.Parse(record["users_id"].ToString()),
                record["comment_text"].ToString(),
                DateTime.Parse(record["creation_date"].ToString()));
        }
    }
}