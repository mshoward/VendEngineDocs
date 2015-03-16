using System;

namespace VendEngineVending
{
	public class ConnectionHeartbeat
	{
		/**
		 * Class will run its thing in a separate thread and
		 * communicate with the VendingStateMachine.
		 * 
		 * runs a timer to test / keep alive connection
		 * connection failure results in another timer starting
		 * after second timer's elapsed time passes, event is triggered which
		 * results in the waiting mode trigger
		 */
		
		public static System.Collections.Generic.List<string> addresses;
		public static System.Timers.Timer timeout_timer;
		public static System.Timers.Timer timeout_tester;
		
		
		public static int max_sec_timeout;
		public static int min_sec_timeout_test;
		
		public static bool is_connected;
		
		public bool timeout_started;
		
		public ConnectionHeartbeat ()
		{
			timeout_started = false;
			max_sec_timeout = 15;
			min_sec_timeout_test = 3;
			
			timeout_tester = new System.Timers.Timer();
			timeout_tester.Interval = min_sec_timeout_test * 1000;
			timeout_tester.Elapsed += new System.Timers.ElapsedEventHandler(test_timeout);
			timeout_tester.Enabled = false;
			
			timeout_timer = new System.Timers.Timer();
			timeout_timer.Interval = max_sec_timeout * 1000;
			timeout_timer.Elapsed += new System.Timers.ElapsedEventHandler(test_loss_time);
			timeout_timer.Enabled = false;
			
		}
		
		private static bool test_connection()
		{
			//TODO
		}
		
		public static void monitor_connection_CALL_ONCE()
		{
			timeout_tester.Stop();
			timeout_tester.Start();
		}
		
		private static void test_timeout(object source, System.Timers.ElapsedEventArgs e)
		{
			if(!test_connection())
			{
				is_connected = false;
				if (!timeout_started)
				{
					timeout_timer.Start();
					timeout_started = true;
				}
			}
			else
			{
				is_connected = true;
				if(timeout_started)
				{
					timeout_timer.Stop();
					timeout_started = false;
				}
			}
		}
		private static void test_loss_time(object source, System.Timers.ElapsedEventArgs e)
		{
			//TODO
			//close up shop, wait for connection
		}
		
		
		
		
		
		
	}//end ConnectionHeartbeat
}

