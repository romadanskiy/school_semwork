using System;
using System.Collections.Generic;
using Npgsql;

namespace SchoolProj.Models
{
    public interface IDao<T>
    {
        public T GetById(int id);
        public List<T> GetAll();
        public void Save(T t);
        public void Delete(T t);
        public void DeleteById(int id);
    }
}