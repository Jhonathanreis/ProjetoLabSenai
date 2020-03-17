using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDB.Domain;

namespace WebApiDB.Data
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        Task<T> ResearchId(Guid id);
        Task<IEnumerable<T>> ResearchAll();
        Task<T> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Exists(Guid id);
    }
}