using System;
using System.Collections.Generic;

namespace Assets.GU_21_02_2018.Scripts.Helpers
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