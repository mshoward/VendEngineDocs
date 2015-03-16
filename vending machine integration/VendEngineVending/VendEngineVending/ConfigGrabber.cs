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
		private bool in_final;
		public bool In_Final
		{
			get
			{
				return in_final;
			}
			protected set
			{
				in_final = false;
			}
		}
		
		enum ConfigState
		{
			INIT, //set everything up
			FIND_CONFIG, //verify
			READING_CONFIG, //read the file
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
		public static System.Collections.Generic.List<string> addr = ConnectionHeartbeat.addresses;
		
		
		//private param_val_pair curr_pair;
		private ConfigState curr_state;
		private Tuple<ConfigState, bool> curr_state_and_result;
		private string err_msg;
		private System.IO.StreamReader conf_reader;
		
		private System.Collections.Generic.List
			<Tuple<string,string>> param_vals;
		
		private System.Collections.Generic.Dictionary
			<System.Tuple<ConfigState, bool>, ConfigState> state_trans;
		
		/* CONSTRUCTOR */
		public ConfigGrabber ()
		{
			err_msg = "";
			In_Final = false;
			curr_pair = new param_val_pair();
			curr_state = ConfigState.INIT;
			
			
			param_vals = new System.Collections.Generic.List<Tuple<string, string>>();
			
			state_trans = new System.Collections.Generic.Dictionary<System.Tuple<ConfigState, bool>, ConfigState>();
			
			state_trans.Add (new Tuple(ConfigState.INIT, true), ConfigState.FIND_CONFIG);
			state_trans.Add(new Tuple(ConfigState.INIT, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.FIND_CONFIG, true), ConfigState.READING_CONFIG);
			state_trans.Add(new Tuple(ConfigState.FIND_CONFIG, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.READING_CONFIG, true), ConfigState.POPULATING);
			state_trans.Add(new Tuple(ConfigState.READING_CONFIG, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.POPULATING, true), ConfigState.FINAL);
			state_trans.Add(new Tuple(ConfigState.POPULATING, false), ConfigState.FAILURE);
			
			state_trans.Add (new Tuple(ConfigState.FINAL, true), ConfigState.FINAL);
			state_trans.Add(new Tuple(ConfigState.FINAL, false), ConfigState.INIT);
			
			
		}
		
		public void NextState()
		{
			//evaluate current state and proceed to the next state
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
				curr_state =
					state_trans[new Tuple<ConfigState, bool>(curr_state, Read_Config())];
				break;
				
			case ConfigState.POPULATING:
				curr_state = 
					state_trans[new Tuple<ConfigState, bool>(curr_state, Populate_Fields())];
				break;
				
			case ConfigState.FINAL:
				curr_state = 
					state_trans[new Tuple<ConfigState, bool>(curr_state, Final_State())];
			}// end switch/case
		}//end NextState()
		
		protected bool Find_Config()
		{
			// fail if file doesn't exist
			try
			{
				conf_reader = System.IO.File.OpenText(configFileName);
			}
			catch(SystemException e)
			{
				conf_reader.Close();
				err_msg = "Failure to open file. Probable cause : Access issues or it does not exist";
				return false;
			}
			return true;
		}//end Find_Config()
		
		protected bool Read_Config()
		{
			/**
			 * reads the file line by line until end of stream,
			 * nuke starting / trailing whitespace
			 * ignore empty lines and lines that start with '#'
			 * split on '='
			 * nuke more whitespace
			 * check length, fail if something unexpected happens
			 * add to dictionary
			 */
			string line;
			string[] par_vals;
			while(!conf_reader.EndOfStream)
			{
				line = conf_reader.ReadLine().Trim();
				if (line.Length > 0)
				{
					if(line[0] != '#')
					{
						line = Utils.Nuke_First_Semi_Colon(line);
						par_vals = line.Split(new char[]{'='});
						
						for(int i = 0; i < par_vals.Length();i++)
							par_vals[i] = par_vals[i].Trim();
						
						if(par_vals.Length != 2) return false; // fail if oddity happens
						
						param_vals.Add(new Tuple<string, string>(par_vals[0], par_vals[1]));
					}
				}
			}//end file loop
			return true;
		}//end Read_Config()
		
		
		/* This is where the magic happens. */
		protected bool Populate_Fields()
		{
			//fail on exception
			try
			{
				foreach(Tuple<string, string> entry in param_vals)
				{
					if (entry.Item1.ToLower().Contains("address"))
					{
						addr.Add(entry.Item2);
					}
				}
			}
			
			catch (SystemException e)
			{
				err_msg = "Error Populating Fields with config settings.";
				return false;
			}
			
			return true;
		}//end Populate_Fields()
		
		
		protected bool Final_State()
		{
			if (in_final)
				in_final = false;
			else
				in_final = true;
			return in_final;
		}//end Final_State()
		
		
		
		
		
		
		
		
		
		
		
		
	}
}

