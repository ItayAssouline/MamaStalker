using MamaStalkerServer.Common;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MamaStalkerClient
{
    class MamaStalkerClient
    {
        public void ExecuteClient()
        {
            try
            {
                Int32 port = 11111;
                TcpClient server = new TcpClient("127.0.0.1", port);
				Console.WriteLine("Connected to server, waiting for data");
                string message = string.Empty;
                NetworkStream stream = server.GetStream();
                Byte[] bytes = new Byte[256];

                IFormatter formatter = new BinaryFormatter();
                int i;
                while (true) //find a way for understanding when stream is ending
				{
                    
                    MessageData data = (MessageData)formatter.Deserialize(stream);
                    data.image.Save($"C:/Users/fushi/Desktop/lottie/{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.jpg");
                }
                //send message to server to close connection
                stream.Close();
                server.Close();

            }
            catch (Exception e)
            {
                //log
                Console.WriteLine(e.ToString());
            }
        }



    }
}
