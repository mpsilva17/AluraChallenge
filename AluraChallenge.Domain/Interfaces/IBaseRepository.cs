using AluraChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluraChallenge.Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        void Insert(Entity obj);

        void Update(Entity obj);

        void Delete(int id);

        IList<Entity> Get();

        Entity Get(int id);
    }
}
