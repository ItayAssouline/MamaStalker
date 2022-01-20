using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using MamaStalkerServer.Abstractions;
using MamaStalkerServer.Common;

namespace MamaStalkerServer.Implementations
{
	class ScreenCapture : IScreenCapturer
	{
		public MemoryStream Capture()
		{
			var bitmap = new Bitmap(1920, 1080);
			var g = Graphics.FromImage(bitmap);
			{
				g.CopyFromScreen(0, 0, 0, 0,
				bitmap.Size, CopyPixelOperation.SourceCopy);
			}
			//bitmap.Save("C:/Users/fushi/Desktop/lottie/filename.jpg", ImageFormat.Jpeg);
			MessageData data = new MessageData(bitmap);
			IFormatter formatter = new BinaryFormatter();
			MemoryStream stream = new MemoryStream();
			formatter.Serialize(stream, data);
			return stream;
		}
	}
}
