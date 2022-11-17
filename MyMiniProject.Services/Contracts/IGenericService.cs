using MyMiniProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniProject.Services.Contracts
{
    public interface IGenericService<TEntity> where TEntity : BaseEntities
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(int id);

        TEntity FindById(int id);

        Task<TEntity> FindByIdAsync(int id);

        List<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();
    }
}
