using Parking.Server.Infrastructure.Models.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Procedure
{
    public interface ISP_Code_Projection
    {
        Task<List<SPCodeList>> GetCodeList(string CM_CD = "");

        /// <summary>
        /// master Code 입력
        /// </summary>
        /// <param name="CM_CD"></param>
        /// <param name="CM_NM"></param>
        /// <param name="CM_USE_YN"></param>
        /// <param name="T_NM"></param>
        /// <param name="F_NM"></param>
        /// <returns></returns>
        Task<List<ProcedureDefaultDto>> InsertCodeMaster(string CM_CD, string CM_NM, string CM_USE_YN, string T_NM, string F_NM);
        Task<List<ProcedureDefaultDto>> DeleteCodeMaster(string CM_CD);
    }
}