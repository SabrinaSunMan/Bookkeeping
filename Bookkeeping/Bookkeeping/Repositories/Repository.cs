using Bookkeeping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using PagedList;

namespace Bookkeeping.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SkillTreeHomeworkEntities _SkillEntities;

        private DbSet<T> Dbset = null;

        public Repository()
        {
            _SkillEntities = new SkillTreeHomeworkEntities();
            Dbset = _SkillEntities.Set<T>();
        }

        public void Create(T entity)
        {
            Dbset.Add(entity);
            _SkillEntities.SaveChanges(); 
        }

        public void Delete(T entity)
        {
            Dbset.Remove(entity);
            _SkillEntities.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset.ToList();
        }

        public T GetSingle(int id)
        {
           return Dbset.Find(id); 
        }

        public void Update(T entity)
        {
            _SkillEntities.Entry(entity).State = EntityState.Modified;
            _SkillEntities.SaveChanges();
        }
         
    }
}