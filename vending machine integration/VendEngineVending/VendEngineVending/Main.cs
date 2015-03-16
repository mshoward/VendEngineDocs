using System;

namespace VendEngineVending
{
	class MainClass
	{
		public Auth auth; //todo
		public ConfigGrabber conf;
		public ConnectionHeartbeat connection;
		public HumanInterface gui; //todo
		public Mdb2pcConverter mdb; //todo
		public Talk2Me logging;
		public Utils utils;
		public VendingMachine vendor;
		public VendingStateMachine control;
		
		public static void Main (string[] args)
		{
			
			Console.WriteLine ("Hello World!");
		}
	}
}
