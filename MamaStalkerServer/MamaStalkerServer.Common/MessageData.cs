using System;
using System.Collections.Generic;
using System.Drawing;

namespace MamaStalkerServer.Common
{
	[Serializable]
	public class MessageData
	{
		
		public Bitmap image { get; set; }
		public MessageData(Bitmap image)
		{
			this.image = image;
		}
	}
}
