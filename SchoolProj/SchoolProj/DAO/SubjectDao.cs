using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class SubjectDao : IDao<Subject>
    {
        public override string ToString()
        {
            return "subject";
        }

        public Subject GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            var allSubject = new List<Subject>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectAll(), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var subject = GetSubject(record);
                        allSubject.Add(subject);
                    }
                }
            }
            return allSubject;
        }

        public void Save(Subject t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Subject t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public Subject GetSubject(IDataRecord record)
        {
            return new Subject(
                int.Parse(record["id"].ToString()),
                record["name"].ToString());
        }
    }
}