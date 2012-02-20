using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Fleck;

namespace epoxysrv
{
	class Message
	{
		public string cmd;
		public Dictionary<string, string> parameters;
		
		public Message ()
		{
			this.cmd = "";
			parameters = new Dictionary<string, string>();
		}
	}
	
    class Server
    {
        static void Main()
        {
            FleckLog.Level = LogLevel.Debug;
            var server = new WebSocketServer("ws://localhost:8181");
            server.Start(socket =>
                {
                    socket.OnOpen = () =>
                        {
                            Console.WriteLine("Open!");
                        };
                    socket.OnClose = () =>
                        {
                            Console.WriteLine("Close!");
                        };
                    socket.OnMessage = message =>
                        {
							JavaScriptSerializer serializer = new JavaScriptSerializer();
							var msg = serializer.Deserialize<Message>(message);					
                            Console.WriteLine(msg.cmd);
                        };
                });


            var input = Console.ReadLine();
            while (input != "exit")
            {
                input = Console.ReadLine();
            }
        }
    }
}
