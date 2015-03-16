using System;

namespace VendEngineVending
{
	public static class Utils
	{
		public Utils ()
		{
		}
		
		string Nuke_First_Semi_Colon(string str)
		{
			return str.Substring(0, str.IndexOf(';'));
			//[012;456] --> [012]
		}
	}
}

