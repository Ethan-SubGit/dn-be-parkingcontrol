using Parking.Server.Infrastructure.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Procedure
{
    public interface ISP_TCode
    {
        Task<List<SPCodeList>> GetCodeList(string CM_CD);
    }
}
