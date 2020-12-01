﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Npgsql;

namespace SchoolProj.Models
{
    public class UsersDao : IDao<Users>
    {
        public override string ToString()
        {
            return "users";
        }

        public Users GetById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectById(id), connection);
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

        public List<Users> GetAll()
        {
            var allUsers = new List<Users>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectAll(), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var user = GetUser(record);
                        allUsers.Add(user);
                    }
                }
            }
            return allUsers;
        }

        public void Save(Users user)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    this.Insert(
                        new[] {"name", "password", "registration_date"},
                        new object[] {user.Name, user.Password, user.RegistrationDate.ToString("d")}),
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Users user)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.Delete(user.Id), connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.Delete(id), connection);
                command.ExecuteNonQuery();
            }
        }

        public void AddCourse(int userId, int courseId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    $"UPDATE users " +
                    $"SET number_of_courses = number_of_courses + 1 " +
                    $"WHERE id = {userId};", 
                    connection);
                command.ExecuteNonQuery();
                //TODO увелиить NumberOfStudents у Course
                //TODO создать связь в UserToCourse
            }
        }

        private static Users GetUser(IDataRecord record)
        {
            return new Users(
                int.Parse(record["id"].ToString()),
                record["name"].ToString(),
                record["password"].ToString(),
                DateTime.Parse(record["registration_date"].ToString()),
                int.Parse(record["number_of_courses"].ToString()));
        }
    }
}