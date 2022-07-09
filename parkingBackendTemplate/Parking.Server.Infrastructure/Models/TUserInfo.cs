using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TUserInfo
    {
        public TUserInfo()
        {
            TUserCarInfo = new HashSet<TUserCarInfo>();
        }

        public int UIdx { get; set; }
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public string UserTelno { get; set; }
        public string UserType { get; set; }
        public string RegEmpId { get; set; }
        public string UserStatus { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual TManagerMember RegEmp { get; set; }
        public virtual ICollection<TUserCarInfo> TUserCarInfo { get; set; }
    }
}
