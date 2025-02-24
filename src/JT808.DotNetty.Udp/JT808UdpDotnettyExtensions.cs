﻿using JT808.DotNetty.Core;
using JT808.DotNetty.Core.Codecs;
using JT808.DotNetty.Core.Handlers;
using JT808.DotNetty.Core.Impls;
using JT808.DotNetty.Core.Interfaces;
using JT808.DotNetty.Core.Jobs;
using JT808.DotNetty.Core.Services;
using JT808.DotNetty.Udp.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Internal;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("JT808.DotNetty.Udp.Test")]

namespace JT808.DotNetty.Udp
{
    public static class JT808UdpDotnettyExtensions
    {
        public static IServiceCollection AddJT808UdpHost(this IServiceCollection  serviceDescriptors)
        {
            serviceDescriptors.TryAddSingleton<IJT808DatagramPacket, JT808DatagramPacketImpl>();
            serviceDescriptors.TryAddSingleton<JT808UdpSessionManager>();
            serviceDescriptors.TryAddSingleton<JT808MsgIdUdpHandlerBase, JT808MsgIdDefaultUdpHandler>();
            serviceDescriptors.TryAddScoped<JT808UdpDecoder>();
            serviceDescriptors.TryAddScoped<JT808UdpServerHandler>();
            serviceDescriptors.AddHostedService<JT808UdpAtomicCouterResetDailyJob>();
            serviceDescriptors.AddHostedService<JT808UdpTrafficResetDailyJob>();
            serviceDescriptors.AddHostedService<JT808UdpServerHost>();
            return serviceDescriptors;
        }
    }
}