using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MamaStalkerServer.Abstractions
{
	interface IScreenCapturer
	{
		public MemoryStream Capture();
	}
}
