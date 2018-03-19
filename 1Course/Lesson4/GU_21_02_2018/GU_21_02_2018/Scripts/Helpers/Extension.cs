using System;
using System.Collections.Generic;

namespace my3DProject
{
	public static class Extension
	{
		public static string Format(this string format, params object[] args)
		{
			return  String.Format(format, args);
		}

		public static T Add<T>(this T self, ICollection<T> collection)
		{
			collection.Add(self);
			return self;
		}
	}
}