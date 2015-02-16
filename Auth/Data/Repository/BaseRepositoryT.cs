using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Auth.Model;

namespace Auth.Data.Repository
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected AuthContext context;

        protected DbSet<T> Set
        {
            get { return context.Set<T>(); }
        }
        public BaseRepository()
        {
            context = new AuthContext();
        }
        public T Get(long id)
        {
            return Set.SingleOrDefault(x => x.Id == id);
        }
        public void Add(T item)
        {
            Set.Add(item);
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            var item = Activator.CreateInstance<T>();
            item.Id = id;
            Set.Attach(item);
            Set.Remove(item);

            context.SaveChanges();
        }
        public IEnumerable<T> Get(Func<T,bool> clause)
        {
            return Set.Where(clause);
        }
    }
}