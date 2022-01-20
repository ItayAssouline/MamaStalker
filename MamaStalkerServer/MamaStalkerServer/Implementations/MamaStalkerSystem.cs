using MamaStalkerServer.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MamaStalkerServer.Implementations
{
	class MamaStalkerSystem
	{

		private IScreenCapturer _screenCaptureModule = new ScreenCapture();
		private int _millisecondsRefreshInterval;
		public MamaStalkerSystem(IScreenCapturer screenCaptureModule, int millisecondsRefreshInterval)
		{
			_screenCaptureModule = screenCaptureModule;
			_millisecondsRefreshInterval = millisecondsRefreshInterval;
		}

		public void Start()
		{
			var server = new ServerModule();
			Task.Run(() => server.InitiateServer());
			while (true)
			{
				var streamToSend = _screenCaptureModule.Capture();
				server.DistributeToClients(streamToSend);
				Thread.Sleep(_millisecondsRefreshInterval);
			}
			
		}

	}
}
