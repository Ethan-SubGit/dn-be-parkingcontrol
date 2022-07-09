using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Framework.Core
{
    public abstract class StartUpHost 
    {
        protected readonly IConfigurationSection AppSettings;
        /// <summary>
        /// An Microsoft.Extensions.Configuration.IConfigurationRoot with keys and values from the registered sources.
        /// </summary>
        protected readonly IConfigurationRoot Configuration;
    }
}
