using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Server.Infrastructure.Models.DtoModels
{
    public class AuditLoginModelDto
    {
        public string UserId { get; set; }
        public string UserIpAddr { get; set; }
        public string UserRoles { get; set; }
        public DateTime LoginDate { get; set; }


    }
}
