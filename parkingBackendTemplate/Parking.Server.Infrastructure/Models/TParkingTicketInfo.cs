using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingTicketInfo
    {
        public TParkingTicketInfo()
        {
            //TParkingTicketUseDiscount = new HashSet<TParkingTicketUseDiscount>();
        }

        public int Pidx { get; set; }
        public string TicketNo { get; set; }
        public string Plcode { get; set; }
        public string CarDisplayNo { get; set; }
        public string ImgPath { get; set; }
        public DateTime TicketOpenDate { get; set; }
        public DateTime? TicketCloseDate { get; set; }
        public int? UseTime { get; set; }
        public bool IsValidData { get; set; }
        public int? ChargePrice { get; set; }
        public int? DiscountPrice { get; set; }
        public int? RealPayPrice { get; set; }
        public int? RefundPrice { get; set; }
        public string PayTypeCd { get; set; }
        public bool IsPaid { get; set; }
        public string PayStatus { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool IsCancel { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
        public string Etc { get; set; }

        //public virtual TParkingLotBasicInfo PlcodeNavigation { get; set; }
        //public virtual ICollection<TParkingTicketUseDiscount> TParkingTicketUseDiscount { get; set; }
    }
}
