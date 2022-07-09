using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TUserCarInfo
    {
        public int CIdx { get; set; }
        public string UserId { get; set; }
        public string CarDisplayNo { get; set; }
        public string CarIdentificationNo { get; set; }
        public string DocumentFilePath { get; set; }
        public string DocumentName { get; set; }
        public string RegEmpId { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual TUserInfo User { get; set; }
    }
}
