using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class FileDao : IDao<File>
    {
        public override string ToString()
        {
            return "file";
        }

        public File GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<File> GetAll()
        {
            var allFiles = new List<File>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectAll(), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var file = GetFile(record);
                        allFiles.Add(file);
                    }
                }
            }
            return allFiles;
        }

        public void Save(File file)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    this.Insert(
                        new[] {"users_id", "file_name", "file_extension"},
                        new object[] {file.UserId, file.FileName, file.FileExtension}),
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(File t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public File GetFile(IDataRecord record)
        {
            return new File(
                int.Parse(record["id"].ToString()),
                int.Parse(record["users_id"].ToString()),
                record["file_name"].ToString(),
                record["file_extension"].ToString());
        }
    }
}