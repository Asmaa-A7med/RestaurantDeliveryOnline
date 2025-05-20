using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;

namespace ResturantDelivery.Reposetories
{
     


     public class GenericRepo<TEntity, TKey> where TEntity : class
    {
        public readonly ResturantDbContext db;

        public GenericRepo(ResturantDbContext _db)
        {
            db = _db;
        }
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<TEntity?> GetById(TKey id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Add(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public virtual async Task DeleteById(TKey id)
        {
            var entity = await GetById(id);
            if (entity != null) Delete(entity);
        }
    }
}
