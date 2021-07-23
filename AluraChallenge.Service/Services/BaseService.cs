using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluraChallenge.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add(TEntity obj)
        {
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> Get() => _baseRepository.Get();

        public TEntity GetById(int id) => _baseRepository.Get(id);

        public TEntity Update(TEntity obj)
        {
            _baseRepository.Update(obj);
            return obj;
        }

    }
}
