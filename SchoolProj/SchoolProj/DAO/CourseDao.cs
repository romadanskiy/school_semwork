using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class CourseDao : IDao<Course>
    {
        public override string ToString()
        {
            return "course";
        }

        public Course GetById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectById(id), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    var course = GetCourse(reader);
                    course.Subjects = GetSubjects(course.Id);
                    course.Units = new UnitDao().GetByCourseId(course.Id);
                    return course;
                }
                else { return null; }
            }
        }

        public List<Course> GetAll()
        {
            var allCourses = new List<Course>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectAll(), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var course = GetCourse(record);
                        course.Subjects = GetSubjects(course.Id);
                        course.Units = new UnitDao().GetByCourseId(course.Id);
                        allCourses.Add(course);
                    }
                }
            }
            return allCourses;
        }

        public void Save(Course t)
        {
            // не используется
            throw new System.Exception();
        }

        public void Delete(Course t)
        {
            // не используется
            throw new System.Exception();
        }

        public void DeleteById(int id)
        {
            // не используется
            throw new System.Exception();
        }

        public List<string> GetSubjects(int courseId)
        {
            var subjects = new List<string>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var cmdText = $"SELECT name FROM subject " +
                              $"JOIN course_to_subject ON subject.id = course_to_subject.subject_id " +
                              $"WHERE course_to_subject.course_id = {courseId};";
                var command = new NpgsqlCommand(cmdText, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var subject = record["name"].ToString();
                        subjects.Add(subject);
                    }
                }
            }
            return subjects;
        }

        private static Course GetCourse(IDataRecord record)
        {
            return new Course(
                int.Parse(record["id"].ToString()),
                record["name"].ToString(),
                record["description"].ToString(),
                int.Parse(record["price"].ToString()),
                int.Parse(record["number_of_students"].ToString()));
        }
    }
}