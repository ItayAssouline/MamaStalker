using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MamaStalkerServer
{
	class Program
	{
		static void Main(string[] args)
		{
			int timeInterval;
			if(args.Length != 0)
			{
				timeInterval = int.Parse(args[0]);
			}
			else
			{
				timeInterval = 6000;
			}
			var system = new MamaStalkerSystem(new ScreenCapture(), timeInterval);
			system.Start();
		}
	}
}
