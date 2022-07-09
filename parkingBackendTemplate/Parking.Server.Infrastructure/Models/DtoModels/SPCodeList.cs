using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Server.Infrastructure.Models.DtoModels
{
    public class SPCodeList
    {
        public Nullable<long> rowNo { get; set; }
        public int CD_IDX { get; set; }
        public string CM_CD { get; set; }
        public string CD_CD { get; set; }
        public string CD_NM { get; set; }
        public string CD_USE_YN { get; set; }

        

    }
}
