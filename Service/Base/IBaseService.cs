using Domain.Base.Entity;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Base
{
    public interface IBaseAuditService<T, TContext>
     where T : AuditBaseEntity
     where TContext : DbContext
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task<T> AddAndSaveAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        public int SaveChanges();

        Task<int> SaveChangesAsync();
    }

    public interface IBaseIdentityService<T, TContext>
    where T : IdentityBaseEntity
    where TContext : DbContext
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task<T> AddAndSaveAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        public int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}