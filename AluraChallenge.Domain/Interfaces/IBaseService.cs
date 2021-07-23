using AluraChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluraChallenge.Domain.Interfaces
{
    public interface IBaseService<Entity> where Entity : class
    {
        Entity Add(Entity obj);

        void Delete(int id);

        IList<Entity> Get();

        Entity GetById(int id);

        Entity Update(Entity obj);
    }
}
