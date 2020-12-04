using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class UnitDao : IDao<Unit>
    {
        public override string ToString()
        {
            return "unit";
        }

        public Unit GetById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectById(id), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    var unit = GetUnit(reader);
                    return unit;
                }
                else { return null; }
            }
        }

        public List<Unit> GetAll()
        {
            var allUnits = new List<Unit>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectAll(), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var unit = GetUnit(record);
                        allUnits.Add(unit);
                    }
                }
            }
            return allUnits;
        }

        public void Save(Unit t)
        {
            // не используется
            throw new System.NotImplementedException();
        }

        public void Delete(Unit t)
        {
            // не используется
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            // не используется
            throw new System.NotImplementedException();
        }

        public List<Unit> GetByCourseId(int courseId)
        {
            var units = new List<Unit>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectByFKey("course_id", courseId), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var unit = GetUnit(record);
                        unit.Lessons = new LessonDao().GetByUnitId(unit.Id);
                        units.Add(unit);
                    }
                }
            }
            return units;
        }

        private static Unit GetUnit(IDataRecord record)
        {
            return new Unit(
                int.Parse(record["id"].ToString()),
                int.Parse(record["course_id"].ToString()),
                record["name"].ToString(),
                int.Parse(record["number_of_lessons"].ToString()));
        }
    }
}