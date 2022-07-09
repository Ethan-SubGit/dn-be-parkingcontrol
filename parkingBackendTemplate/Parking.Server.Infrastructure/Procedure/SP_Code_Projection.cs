using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.DtoModels;
using Parking.Server.Infrastructure.Procedure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Procedure
{
    public class SP_Code_Projection : ISP_Code_Projection
    {
        private readonly ParkingIntegratedControlCenterContext context;
        public SP_Code_Projection(ParkingIntegratedControlCenterContext _ParkingIntegratedControlCenterContext)
        {
            context = _ParkingIntegratedControlCenterContext;
        }
        public async Task<List<SPCodeList>> GetCodeList(string CM_CD = "")
        {
            List<SPCodeList> lst = new List<SPCodeList>();

            SqlParameter USE_YN_ = new SqlParameter("@P_USE_YN", "");
            SqlParameter CM_CD_ = new SqlParameter("@P_CM_CD", CM_CD);
            SqlParameter CD_NM_ = new SqlParameter("@P_CD_NM", "");

            string sqlQuery = "EXEC SP_Code_List @P_USE_YN, @P_CM_CD, @P_CD_NM ";

            //lst = await ParkingIntegratedControlCenterContext.Query<SPCodeList>().FromSqlRaw(sqlQuery, USE_YN_, CM_CD_, CD_NM_).ToListAsync();
            lst = await context.Set<SPCodeList>().FromSqlRaw(sqlQuery, USE_YN_, CM_CD_, CD_NM_).ToListAsync().ConfigureAwait(false);

            return lst;
        }

        /// <summary>
        /// 코드 마스터 입력
        /// </summary>
        /// <param name="CM_CD"></param>
        /// <param name="CD_NM"></param>
        /// <param name="CM_USE_YN"></param>
        /// <param name="T_NM"></param>
        /// <param name="F_NM"></param>
        /// <returns></returns>
        public async Task<List<ProcedureDefaultDto>> InsertCodeMaster(string CM_CD, string CM_NM, string CM_USE_YN = "Y", string T_NM = "", string F_NM = "")
        {
            //ProcedureDefaultDto row = new ProcedureDefaultDto();

            SqlParameter CM_CD_ = new SqlParameter("@P_CM_CD", CM_CD);
            SqlParameter CM_NM_ = new SqlParameter("@P_CM_NM", CM_NM);
            SqlParameter CM_USE_YN_ = new SqlParameter("@P_CM_USE_YN", CM_USE_YN);
            SqlParameter T_NM_ = new SqlParameter("@P_T_NM", T_NM);
            SqlParameter F_NM_ = new SqlParameter("@P_F_NM", F_NM);

            string sqlQuery = "EXEC SP_CodeMaster_Insert @P_CM_CD, @P_CM_NM, @P_CM_USE_YN, @P_T_NM, @P_F_NM";

            //string sqlQuery = $"EXEC SP_CodeMaster_Insert @P_CM_CD='{CM_CD}', @P_CM_NM='{CM_NM}', @P_CM_USE_YN='{CM_USE_YN}', @P_T_NM= '{T_NM}', @P_F_NM='{F_NM}'";

            //row = await context.Set<ProcedureDefaultDto>().FromSqlRaw(sqlQuery, CM_CD, CM_NM, CM_USE_YN, T_NM, F_NM).FirstOrDefaultAsync().ConfigureAwait(false);

            var row = await context.Set<ProcedureDefaultDto>().FromSqlRaw(sqlQuery, CM_CD_, CM_NM_, CM_USE_YN_, T_NM_, F_NM_)
                .ToListAsync().ConfigureAwait(false);
            // var row = context.Set<ProcedureDefaultDto>().FromSql(sqlQuery, CM_CD_).FirstOrDefaultAsync().ConfigureAwait(false);


            return row;

        }
        
        public async Task<ProcedureDefaultDto> InsertCode(string CD_CD, string USE_YN, string CM_CD, string CD_NM)
        {
            ProcedureDefaultDto row = new ProcedureDefaultDto();

            SqlParameter CD_CD_ = new SqlParameter("@P_CD_CD", CD_CD);
            SqlParameter USE_YN_ = new SqlParameter("@P_USE_YN", USE_YN);
            SqlParameter CM_CD_ = new SqlParameter("@P_CM_CD", CM_CD);
            SqlParameter CD_NM_ = new SqlParameter("@P_CD_NM", CD_NM);

            string sqlQuery = "EXEC SP_CodeInsert @P_CD_CD, @P_USE_YN, @P_CM_CD, @P_CD_NM";

            row = await context.Set<ProcedureDefaultDto>().FromSqlRaw(sqlQuery, CD_CD_, USE_YN_, CM_CD_, CD_NM_).FirstOrDefaultAsync().ConfigureAwait(false);

            return row;

        }

        public async Task<List<ProcedureDefaultDto>> DeleteCodeMaster(string CM_CD)
        {
            SqlParameter CM_CD_ = new SqlParameter("@P_CM_CD", CM_CD);
            

            string sqlQuery = "EXEC SP_CodeMaster_Delete @P_CM_CD";
            var row = await context.Set<ProcedureDefaultDto>().FromSqlRaw(sqlQuery, CM_CD_)
                .ToListAsync().ConfigureAwait(false);

            return row;
        }
    }
}
