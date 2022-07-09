using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TCodeMaster
    {
        public TCodeMaster()
        {
            TCode = new HashSet<TCode>();
        }

        public string CmCd { get; set; }
        public string CmNm { get; set; }
        public string CmUseYn { get; set; }
        public string TNm { get; set; }
        public string FNm { get; set; }

        public virtual ICollection<TCode> TCode { get; set; }
    }
}
