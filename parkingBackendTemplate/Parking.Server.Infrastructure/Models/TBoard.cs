using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TBoard
    {
        public TBoard()
        {
            TBoardAttachmentFile = new HashSet<TBoardAttachmentFile>();
        }

        public int BoardNo { get; set; }
        public int? BoardSeq { get; set; }
        public int? BoardDepth { get; set; }
        public string BoardGroupCode { get; set; }
        public string BoardCategory { get; set; }
        public bool? IsNotice { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string RegEmpId { get; set; }
        public string RegUserIp { get; set; }
        public int? HitCnt { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual ICollection<TBoardAttachmentFile> TBoardAttachmentFile { get; set; }
    }
}
