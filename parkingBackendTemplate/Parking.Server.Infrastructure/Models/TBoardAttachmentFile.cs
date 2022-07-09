using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TBoardAttachmentFile
    {
        public int AIdx { get; set; }
        public int BoardNo { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public int? DownloadCount { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual TBoard BoardNoNavigation { get; set; }
    }
}
