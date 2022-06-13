using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.GenericRepository
{
    //منصرف شدم از ادامه توسعه با این روش 
    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {

        private MyEShopEntities _context;
        private DbSet<TEntity> _dbSet;


        public GenericRepository(MyEShopEntities context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity GetByID(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }


        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }


        public IEnumerable<TEntity> GetAllByInclude(params Expression<Func<TEntity, object>>[] includeEntities)
        {
            return GetAllIncluding(includeEntities).ToList();
        }


        public IEnumerable<TEntity> GetByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            var query = GetAllIncluding(includeEntities);
            return query.Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> GetByInclude_OrderBy(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }



        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet;

            return includeProperties.
                   Aggregate(queryable,
                                      (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
