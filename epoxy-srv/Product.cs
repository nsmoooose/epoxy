using System;
using System.Collections.Generic;
using epoxysrv.Data;

namespace epoxysrv
{	
	class Product
	{
		public static List<prd> SearchProducts (Dictionary<string, string> parameters) {
			var lst = new List<prd>();
			
			for(int i=0;i<10;i++) {
				prd p = new prd();
				p.id = string.Format("123123%d", i);
				p.description = "A nice product.";
				p.dimensions = new dimensions();
				p.dimensions.width = 15;
				p.dimensions.height = 12;
				p.dimensions.depth = 10;
				lst.Add(p);
			}
			return lst;
		}
	}
}

