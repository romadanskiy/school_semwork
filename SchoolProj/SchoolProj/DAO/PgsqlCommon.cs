using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace SchoolProj.Models
{
    public static class PgsqlFormat
    {
        public static string SelectAll<T>(this IDao<T> table)
        {
            return SelectAll(table.ToString());
        }
        
        public static string SelectAll(string table)
        {
            return $"SELECT * FROM {table}";
        }

        public static string SelectByFKey<T>(this IDao<T> table, string fKey, int fKeyId)
        {
            return SelectByFKey(table.ToString(), fKey, fKeyId);
        }
        
        public static string SelectByFKey(string table, string fKey, int fKeyId)
        {
            return $"SELECT * FROM {table} WHERE {fKey} = {fKeyId}";
        }

        public static string SelectById<T>(this IDao<T> table, int id)
        {
            return SelectById(table.ToString(), id);
        }
        
        public static string SelectById(string table, int id)
        {
            return $"SELECT * FROM {table} WHERE id = {id}";
        }

        public static string SelectByField<T>(this IDao<T> table, string field, string value)
        {
            return SelectByField(table.ToString(), field, value);
        }
        
        public static string SelectByField(string table, string field, string value)
        {
            return $"SELECT * FROM {table} WHERE {field} = '{value}'";
        }

        public static string Delete<T>(this IDao<T> table, int id)
        {
            return Delete(table.ToString(), id);
        }
        
        public static string Delete(string table, int id)
        {
            return $"DELETE FROM {table} WHERE id = {id};";
        }

        public static string Insert<T>(this IDao<T> table, string[] columns, object[] values)
        {
            return Insert(table.ToString(), columns, values);
        }
        
        public static string Insert(string table, string[] columns, object[] values)
        {
            var sB = new StringBuilder($"INSERT INTO {table} (");
            var c1 = 0;
            foreach (var column in columns)
            {
                sB.Append($"{column}");
                if (c1 < columns.Length - 1)
                    sB.Append(", ");
                c1++;
            }
            sB.Append(") VALUES (");
            var c2 = 0;
            foreach (var value in values)
            {
                switch (value)
                {
                    case string s:
                        sB.Append($"'{s}'");
                        break;
                    case int n:
                        sB.Append($"{n}");
                        break;
                    case DateTime d:
                        sB.Append($"'{d}'");
                        break;
                }
                if (c2 < values.Length - 1)
                    sB.Append(", ");
                c2++;
            }
            sB.Append(");");
            return sB.ToString();
        }
        
    }
}