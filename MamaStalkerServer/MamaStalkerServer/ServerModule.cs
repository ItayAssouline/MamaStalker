using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MamaStalkerServer.Common;
namespace MamaStalkerServer
{
	class ServerModule
    {
        private IList<TcpClient> _clients;
		public ServerModule(IList<TcpClient> listOfClients)
		{
            _clients = listOfClients;
        }
		public ServerModule()
		{
            _clients = new List<TcpClient>();
        }
        public void InitiateServer()
        {
            string serverIP = "127.0.0.1";
            int port = 11111;
            try
            {
                Console.WriteLine("Initializing.....");
                TcpListener server = new TcpListener(IPAddress.Parse(serverIP), port);
                server.Start();
                Console.WriteLine($"Server is ready and waiting for connections on IP: {serverIP} & Port {port}");

                
                while (true)
                {
					Console.WriteLine("Registering Client");
                    //register client to clients
                    var client = server.AcceptTcpClient();
                    _clients.Add(client);
					Console.WriteLine("Registered Client");
                }
                
                server.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void DistributeImageToClient(TcpClient client, MemoryStream image)
        {
			Console.WriteLine("Distributing to client");
            NetworkStream stream = client.GetStream();
            //Send image to client
            stream.Write(image.ToArray());
        }

        public void DistributeToClients(MemoryStream image)
		{
			Console.WriteLine("Distributing to all clients");
			Parallel.ForEach(_clients, client =>
			{
                DistributeImageToClient(client, image);
			});
		}
    }
}
