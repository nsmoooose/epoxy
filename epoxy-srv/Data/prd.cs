using System;

namespace epoxysrv.Data
{
	[Serializable]
	class dimensions
	{
		public int width;
		public int height;
		public int depth;
	}
	
	[Serializable]
	class prd
	{
		public string id;
		public string description;
		public dimensions dimensions;
	}
}
