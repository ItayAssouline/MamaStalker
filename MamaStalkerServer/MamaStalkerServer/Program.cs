using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MamaStalkerServer
{
	class Program
	{
		static void Main(string[] args)
		{
			var system = new MamaStalkerSystem(new ScreenCapture(), 3000);
			system.Start();
		}
	}
}
