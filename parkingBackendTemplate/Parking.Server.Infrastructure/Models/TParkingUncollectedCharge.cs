using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingUncollectedCharge
    {
        public int MIdx { get; set; }
        public string TicketNo { get; set; }
        public string Plcode { get; set; }
        public string BankAccount { get; set; }
        public string BankCode { get; set; }
        public string ReceiveTelno { get; set; }
        public DateTime? ReceiveEndDate { get; set; }
        public DateTime? NoticeDatae { get; set; }
        public bool? IsDeposit { get; set; }
        public int? OverDueNo { get; set; }
        public string TransactionNo { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
    }
}
