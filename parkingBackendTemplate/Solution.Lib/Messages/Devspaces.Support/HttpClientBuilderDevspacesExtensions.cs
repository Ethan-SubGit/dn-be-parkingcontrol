using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Devspaces.Support
{
    public static class HttpClientBuilderDevspacesExtensions
    {
        public static IHttpClientBuilder AddDevspacesSupport(this IHttpClientBuilder builder)
        {
            builder.AddHttpMessageHandler<DevspacesMessageHandler>();
            return builder;
        }
    }
}
