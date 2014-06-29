using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using MessageHub.DAL;
using System.Reflection;
using System.IO;

[assembly: OwinStartup(typeof(MessageHub.Startup))]

namespace MessageHub
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.

            if (File.Exists(@"c:\tmp\reset.txt") || File.Exists(@"c:\tmp\reset.txt.txt"))
            {
                MessageHub.Properties.Settings.Default.DefaultPort = "null";
                try
                {
                    File.Delete(@"c:\tmp\reset.txt");
                }
                catch (Exception ex)
                {
                }
                try
                {
                    File.Delete(@"c:\tmp\reset.txt.txt");
                }
                catch (Exception ex)
                {
                }
                MessageHub.Properties.Settings.Default.Save();
            }

            if (MessageHub.Properties.Settings.Default.DefaultPort == "null")
            {
                Console.WriteLine(DateTime.Now.ToShortTimeString() + "  " + "Please specify the service port to use (ie 8089)");
                string p = Console.ReadLine();
                MessageHub.Properties.Settings.Default.DefaultPort = p;
                MessageHub.Properties.Settings.Default.Save();
            }

            //For display purposes
            Console.Title = "iTactix Message Hub - Core Service";
            Assembly assem = Assembly.GetEntryAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;
            //CALCULATE THE DATE OF THE BUILD
            DateTime dt = new DateTime(2000, 1, 1, 00, 00, 00);
            dt = dt.AddDays(ver.Build);
            //ANOTHER (SHORTER) WAY OF COLLECTING THE DATA
            string versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            versionString = ver.ToString() + " " + dt.ToShortDateString();
            //Console.WriteLine(DateTime.Now.ToShortTimeString() + "  " + "Core Services Version: " + versionString);

            string url = "http://*:" + MessageHub.Properties.Settings.Default.DefaultPort;
            //string url = "http://localhost:"+MessageHub.Properties.Settings.Default.DefaultPort;
            using (WebApp.Start(url))
            {
                Console.WriteLine("iTactix Message Hub running on {0}", url);
                while (true)
                {
                    string key = Console.ReadLine();
                    if (key.ToUpper() == "W")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                        hubContext.Clients.All.addMessage("server", "ServerMessage");
                        Console.WriteLine("Server Sending addMessage\n");
                    }
                    if (key.ToUpper() == "E")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                        hubContext.Clients.All.heartbeat();
                        Console.WriteLine("Server Sending heartbeat\n");
                    }
                    if (key.ToUpper() == "R")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                        var vv = new HelloModel {Age = 37, Molly = "pushed direct from Server "};

                        hubContext.Clients.All.sendHelloObject(vv);
                        Console.WriteLine("Server Sending sendHelloObject\n");
                    }
                    if (key.ToUpper() == "C")
                    {
                        break;
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
