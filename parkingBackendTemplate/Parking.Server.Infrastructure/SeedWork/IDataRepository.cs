using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.SeedWork
{
    public interface IDataRepository<T> where T : IAggregateRoot
    {
        //IEnumerable<T> GetAll();
        Task<T> Retrieve(string param);
        //TDto GetDto(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
    }
}
