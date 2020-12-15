using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace SchoolProj.Models
{
    public class PurchaseDao : IDao<Purchase>
    {
        public override string ToString()
        {
            return "purchase";
        }

        public Purchase GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Purchase> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Purchase purchase)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    this.Insert(
                        new[] {"users_id", "course_id", "purchase_date", "price"},
                        new object[] {purchase.UsersId, purchase.CourseId, purchase.PurchaseDate, purchase.Price}),
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Purchase t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public List<Purchase> GetByUsersId(int usersId)
        {
            var purchases = new List<Purchase>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
            {
                connection.Open();
                var command = new NpgsqlCommand(this.SelectByFKey("users_id", usersId), connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord record in reader)
                    {
                        var purchase = GetPurchase(record);
                        purchases.Add(purchase);
                    }
                }
            }
            return purchases;
        }
        
        private static Purchase GetPurchase(IDataRecord record)
        {
            return new Purchase(
                int.Parse(record["id"].ToString()),
                int.Parse(record["users_id"].ToString()),
                int.Parse(record["course_id"].ToString()),
                DateTime.Parse(record["purchase_date"].ToString()),
                int.Parse(record["price"].ToString()));
        }
    }
}