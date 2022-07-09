using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TUserCarDocumentInfo
    {
        public int DIdx { get; set; }
        public string FilePath { get; set; }
        public string CarDisplayNo { get; set; }
        public string FileName { get; set; }
        public string DocType { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
    }
}
