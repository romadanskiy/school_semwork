using System.Collections.Generic;
using Npgsql;

namespace SchoolProj.Models
{
    /*
    public class Dao<T> : IDao<T> where T : class
    {
        public virtual T GetById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectOne(id), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    var user = GetUser(reader);
                    return user;
                }
                else { return null; }
            }
        }

        public virtual List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(T t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
    */
}