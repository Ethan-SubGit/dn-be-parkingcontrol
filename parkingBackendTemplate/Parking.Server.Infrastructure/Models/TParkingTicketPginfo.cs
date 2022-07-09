using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingTicketPginfo
    {
        public int PIdx { get; set; }
        public string TicketNo { get; set; }
        public string Plcode { get; set; }
        public int? PayPrice { get; set; }
        public string TransactionNo { get; set; }
        public string BankName { get; set; }
        public string ResultCode { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
    }
}
