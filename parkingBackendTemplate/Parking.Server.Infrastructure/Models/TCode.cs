using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TCode
    {
        public int CdIdx { get; set; }
        public string CmCd { get; set; }
        public string CdCd { get; set; }
        public string CdNm { get; set; }
        public bool? CdUseYn { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual TCodeMaster CmCdNavigation { get; set; }
    }
}
