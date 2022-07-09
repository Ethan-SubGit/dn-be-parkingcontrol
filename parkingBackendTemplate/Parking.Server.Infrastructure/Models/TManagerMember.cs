using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TManagerMember
    {
        public TManagerMember()
        {
            TUserInfo = new HashSet<TUserInfo>();
        }

        public string EmpId { get; set; }
        public string EmpPwd { get; set; }
        public string EncKey { get; set; }
        public string EmpName { get; set; }
        public string EmpNo { get; set; }
        public string EmpStatus { get; set; }
        public string EmpRole { get; set; }
        public string RegEmpId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual ICollection<TUserInfo> TUserInfo { get; set; }
    }
}
