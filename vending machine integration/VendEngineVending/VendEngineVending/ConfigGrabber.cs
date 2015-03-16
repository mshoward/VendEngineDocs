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
			INIT, //set everything up
			FIND_CONFIG, //verify
			READING_CONFIG, //read the file
			FINISHED_READING, //EOF
			POPULATING,  //set values
			FINAL, //complete, accept
			FAILURE
		}
		
		
		/*
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
		*/
		
		public static string configFileName = "VendEngineVendingMachine.conf";
		//Configurable settings
		public static string[] addr = ConnectionHeartbeat.addresses;
		
		
		//private param_val_pair curr_pair;
		private ConfigState curr_state;
		private Tuple<ConfigState, bool> curr_state_and_result;
		private System.IO.StreamReader conf_reader;
		private System.Collections.Generic.List<param_val_pair> param_vals;
		private System.Collections.Generic.Dictionary
			<System.Tuple<ConfigState, bool>, ConfigState> state_trans;
		
		public ConfigGrabber ()
		{
			curr_pair = new param_val_pair();
			curr_state = ConfigState.INIT;
			param_vals = new System.Collections.Generic.List<param_val_pair>();
			
			state_trans = new System.Collections.Generic.Dictionary<System.Tuple<ConfigState, bool>, ConfigState>();
			
			state_trans.Add (new Tuple(ConfigState.INIT, true), ConfigState.FIND_CONFIG);
			state_trans.Add(new Tuple(ConfigState.INIT, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.FIND_CONFIG, true), ConfigState.READING_CONFIG);
			state_trans.Add(new Tuple(ConfigState.FIND_CONFIG, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.READING_CONFIG, true), ConfigState.FINISHED_READING);
			state_trans.Add(new Tuple(ConfigState.READING_CONFIG, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.FINISHED_READING, true), ConfigState.POPULATING);
			state_trans.Add(new Tuple(ConfigState.FINISHED_READING, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.POPULATING, true), ConfigState.FINAL);
			state_trans.Add(new Tuple(ConfigState.POPULATING, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.FINAL, true), ConfigState.FINAL);
			state_trans.Add(new Tuple(ConfigState.FINAL, false), ConfigState.INIT);
			
			
		}
		public void NextState()
		{
			switch(curr_state)
			{
			case ConfigState.INIT:
				//
				break;
			case ConfigState.FIND_CONFIG:
				curr_state =
					state_trans[new Tuple<ConfigState, bool>(curr_state, Find_Config())];
				break;
			case ConfigState.READING_CONFIG:
				break;
				
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
		
		protected bool Read_Config()
		{
			string line;
			string par, val;
			while(!conf_reader.EndOfStream)
			{
				line = conf_reader.ReadLine().Trim();
				if(line[0] != '#')
				{
					line = Utils.Nuke_First_Semi_Colon(line);
				}
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}

