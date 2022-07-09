using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TSiteConfig
    {
        public string ServiceKey { get; set; }
        public string ServiceValue { get; set; }
        public string ServiceExtValue { get; set; }
        public bool? IsUse { get; set; }
        public string ServiceDomain { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
        public string RegEmpId { get; set; }
    }
}
