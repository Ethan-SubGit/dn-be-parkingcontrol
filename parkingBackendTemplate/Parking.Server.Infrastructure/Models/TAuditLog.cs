using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TAuditLog
    {
        public int AIdx { get; set; }
        public string EmpId { get; set; }
        public string UserIpAddr { get; set; }
        public string EventSorce { get; set; }
        public string ContextSource { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModifyDate { get; set; }
    }
}
