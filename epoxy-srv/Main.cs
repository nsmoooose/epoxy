using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Fleck;

namespace epoxysrv
{
	[Serializable]
	class Request
	{
		public string id;
		public string cmd;
		public Dictionary<string, string> parameters;
	}
	
	[Serializable]
	class Response
	{
		public string id;
		public object result;
		
		public Response (string id)
		{
			this.id = id;
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
							Request msg = serializer.Deserialize<Request>(message);					
                            Console.WriteLine(msg.cmd);
					
							if(msg.cmd == "prd_search") {
								Response r = new Response(msg.id);
								r.result = Product.SearchProducts(msg.parameters);
								socket.Send(serializer.Serialize(r));
							}
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
