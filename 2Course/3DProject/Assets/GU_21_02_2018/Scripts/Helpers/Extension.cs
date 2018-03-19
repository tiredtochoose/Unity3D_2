using System;
using System.Collections.Generic;

namespace My3DProject
{         
	public static class Extension
	{
		public static string MyFormat(this string format, params object[] args)
		{
			return  String.Format(format, args);
		}

		public static T Add<T>(this T self, ICollection<T> collection)
		{
			collection.Add(self);
			return self;
		}

        public static bool TryBool (this string self)
        {
            bool result;
            //можем ли мы спарсить данную строку
            return Boolean.TryParse(self, out result) && result;

        }
	}

}