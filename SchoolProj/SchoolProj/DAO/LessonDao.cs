using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class LessonDao : IDao<Lesson>
    {
        public override string ToString()
        {
            return "lesson";
        }

        public Lesson GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Lesson> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Lesson t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Lesson t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public List<Lesson> GetByUnitId(int unitId)
        {
            var comments = new List<Lesson>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectByFKey("unit_id", unitId), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var lesson = GetLesson(record);
                        comments.Add(lesson);
                    }
                }
            }
            return comments;
        }

        private static Lesson GetLesson(IDataRecord record)
        {
            return new Lesson(
                record["name"].ToString(),
                record["content"].ToString());
        }
    }
}