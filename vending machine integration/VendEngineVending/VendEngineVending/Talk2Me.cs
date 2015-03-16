using System;

namespace VendEngineVending
{
	public class Talk2Me
	{
		/**
		 * Logging class
		 * 
		 * writes to error log, will possibly publish failures? Not sure.
		 * Logging, for sure, though.
		 */
		
		public static string logname = "Vending_Log.txt";
		public static int LogLevel = 0;
		
		//
		private System.IO.StreamWriter logger;
		
		public Talk2Me ()
		{
			try
			{
				if(System.IO.File.Exists(logname))
					logger = System.IO.File.AppendText(logname);
				else
					logger = System.IO.File.CreateText(logname);
			}
			catch (SystemException e)
			{
				//something broke, and I can't log it.
				//check for log file.
				logger.Close();
			}
		}//end constructor
		
		public static void log_this(string str)
		{
			try
			{
				logger.WriteLine(str);
			}
			catch (SystemException e)
			{
				//something broke, and I can't log it
				//something nuked the Talk2Me or an io error happened
			}
		}//end log_this(string str)
		
		public static void log_this(string str, int log_lvl)
		{
			if (LogLevel <= log_lvl)
			{
				try
				{
					logger.WriteLine(str);
				}
				catch (SystemException e)
				{
					//something broke, and I can't log it
					//something nuked the Talk2Me or an io error happened
				}
			}
		}
		
		
	}
}

