using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TMessageTemplate
    {
        public int MIdx { get; set; }
        public string TemplateTitle { get; set; }
        public string TemplteContent { get; set; }
        public string MessageType { get; set; }
        public int? MessageLength { get; set; }
        public bool IsActive { get; set; }
        public string RegEmpId { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
        public string Etc { get; set; }
    }
}
