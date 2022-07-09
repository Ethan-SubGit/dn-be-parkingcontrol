using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Server.Infrastructure.Models.ParameterModels
{
    public class CreateParkingLotBasicInfoModel
    {
        /// <summary>
        /// code
        /// </summary>
        public string Plcode { get; set; }
        /// <summary>
        /// 주차장명
        /// </summary>
        public string PlcodeName { get; set; }

        /// <summary>
        /// 주차장 주소
        /// </summary>
        public string Pladdress { get; set; }

        /// <summary>
        /// 암호화키
        /// </summary>
        public string PlencKey { get; set; }

        /// <summary>
        /// 주차장 타입
        /// </summary>
        public string Pltype { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime PlregDate { get; set; }

        /// <summary>
        /// 수정일
        /// </summary>
        public DateTime? PlmodDate { get; set; }

        /// <summary>
        /// 등록Emp
        /// </summary>
        public string RegEmpId { get; set; }
        public bool PlisActive { get; set; }
    }
}
