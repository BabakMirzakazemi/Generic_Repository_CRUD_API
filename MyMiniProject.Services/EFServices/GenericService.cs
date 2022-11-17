using Microsoft.EntityFrameworkCore;
using MyMiniProject.DataLayer.MyAppDbContext;
using MyMiniProject.Entities;
using MyMiniProject.Services.Contracts;
namespace MyMiniProject.Services.EFServices
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntities, new()
    {
        private readonly IUnitOfWork _db;
        private readonly DbSet<TEntity> _entity;
        public GenericService(IUnitOfWork db)
        {
            this._db = db;
            _entity = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
                _entity.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
          
        }

        public TEntity FindById(int id)
        {
            return _entity.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public List<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _entity.ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _entity?.Remove(entity);
        }

        public void Remove(int id)
        {
            var tEntity = FindById(id);
            if (tEntity is null)
                throw new Exception("The entity doesn't have Id field!");
            _entity.Remove(tEntity);
         
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
    }
}
