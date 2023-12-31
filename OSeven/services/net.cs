﻿using System;
using System.Net;
using System.Net.NetworkInformation;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.TCP;
using Cosmos.System.Network.Config;

namespace OSeven.net
{
    public static class Net
    {
        public static void Main(string target)
        {
            try
            {
                Ping pingtarget = new Ping();
                Console.WriteLine("Pinging " + target + " ...");
                PingReply reply = pingtarget.Send(target);
                Console.WriteLine("Reply from " + target + " Status: " + reply.Status + " time=" + reply.RoundtripTime + "ms");
                Console.WriteLine("Pinging " + target + " ...");
                reply = pingtarget.Send(target);
                Console.WriteLine("Reply from " + target + " Status: " + reply.Status + " time=" + reply.RoundtripTime + "ms");
                Console.WriteLine("Pinging " + target + " ...");
                reply = pingtarget.Send(target);
                Console.WriteLine("Reply from " + target + " Status: " + reply.Status + " time=" + reply.RoundtripTime + "ms");
            }
            catch
            {
                Console.WriteLine("Couldn't find host " + target);
            }
        }
        public static void Check()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("| .. |");
            Console.ResetColor();
            Console.Write(" Oseven Network");
            try
            {
                IPConfig.Enable(Cosmos.HAL.NetworkDevice.GetDeviceByName("eth0"), Address.Zero, Address.Broadcast, Address.Parse("192.168.1.1"));
                new DHCPClient().SendDiscoverPacket();
                Console.CursorLeft = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("| OK |");
            }
            catch (Exception e)
            {
                Console.CursorLeft = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("| ERR |");
                Console.WriteLine(e.ToString());
            }
        }
    }
}