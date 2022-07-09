using System;
using System.Collections.Generic;
using System.Text;

namespace Message.EventBus.EventBus.IntegrationEventLogEF
{
    public enum EventStateEnum
    {
        NotPublished = 0,
        InProgress = 1,
        Published = 2,
        PublishedFailed = 3
    }
}
