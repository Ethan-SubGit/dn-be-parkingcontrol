using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    //public interface ITCodeMasterRepository : IRepository<TCodeMaster>
    public interface ITCodeMasterRepository
    {
        TCodeMaster Create(TCodeMaster tCodeMaster);
        TCodeMaster Delete(TCodeMaster tCodeMaster);
        Task<TCodeMaster> Retrieve(string code);
        Task<List<TCodeMaster>> Retrieves();
        Task<TCodeMaster> Update(TCodeMaster tCodeMaster);
        
    }
}