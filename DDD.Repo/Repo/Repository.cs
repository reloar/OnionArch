using DDD.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Repo
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApplicationDbContext db;

        //public DbSet<T> item;
        public Repository()
        {
            db = new ApplicationDbContext();
        }
       
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            db.Set<T>().Remove(entity);
            savechanges();
        }

        public T Get(long id)
        {
           return db.Set<T>().Find(id);
            

        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            db.Set<T>().Add(entity);
            savechanges();
        }

        

        public void savechanges()
        {
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            if(entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            savechanges();
        }
    }
}
