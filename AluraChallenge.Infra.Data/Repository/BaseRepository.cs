using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces;
using AluraChallenge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluraChallenge.Infra.Data.Repository
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        protected readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext SqlContext)
        {
            _sqlContext = SqlContext;
        }

        public void Insert(Entity obj)
        {
            _sqlContext.Set<Entity>().Add(obj);
            _sqlContext.SaveChanges();
        }

        public void Update(Entity obj)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqlContext.Set<Entity>().Remove(Get(id));
            _sqlContext.SaveChanges();
        }

        public IList<Entity> Get() {
            return _sqlContext.Set<Entity>().ToList();
        }

        public Entity Get(int id) =>
            _sqlContext.Set<Entity>().Find(id);

    }
}
