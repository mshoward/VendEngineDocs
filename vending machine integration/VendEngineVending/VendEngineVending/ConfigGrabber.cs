using System;
using System.IO;
namespace VendEngineVending
{
	public class ConfigGrabber
	{
		/**
		 * Configuration reader upon load.
		 * Syntax for configuration is planned to be
		 * someVar = value;
		 * for simplicity.
		 */
		protected bool good;//useless, I'm not sure if I need this.
		public bool Good
		{
			get{
				return (curr_state != ConfigState.FAILURE);
			}
			protected set{
				good = value;
			}
		}
		
		enum ConfigState
		{
			INIT,
			GET_CONFIG,
			FOUND_CONFIG,
			READING_CONFIG,
			FINISHED_READING,
			POPULATING,
			FINISHED_POPULATING,
			FAILURE
		}
		
		
		
		public class param_val_pair
		{
			public string param;
			public string val;
			public param_val_pair()
			{
				param = "";
				val = "";
			}
			public param_val_pair(string arg1, string arg2)
			{
				arg1.CopyTo(0, param, 0, arg1.Length);
				arg2.CopyTo(0, val, 0, arg2.Length);
			}
		}
		
		
		public static string configFileName = "VendEngineVendingMachine.conf";
		//Configurable settings
		public static string[] addr = ConnectionHeartbeat.addresses;
		
		
		private param_val_pair curr_pair;
		private ConfigState curr_state;
		private System.IO.StreamReader conf_reader;
		public ConfigGrabber ()
		{
			curr_pair = new param_val_pair();
			curr_state = ConfigState.INIT;
		}
		public void NextState()
		{
			switch(curr_state)
			{
			}
		}
		
		protected bool Find_Config()
		{
			try
			{
				conf_reader = System.IO.File.OpenText(configFileName);
			}
			catch(SystemException e)
			{
				conf_reader.Close();
				return false;
			}
			return true;
		}
		
		
	}
}

