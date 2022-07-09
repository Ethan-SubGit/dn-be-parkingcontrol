using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TMessageSendLog
    {
        public int SIdx { get; set; }
        public int? RefKey { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public string ReceiveNo { get; set; }
        public string CallbackNo { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? DataRegDate { get; set; }
    }
}
