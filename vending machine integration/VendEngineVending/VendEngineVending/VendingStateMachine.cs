using System;

namespace VendEngineVending
{
	/**
	 * States in the transaction process.
	 * The Vending machine will determine what its
	 * next step will be by the state currently selected
	 * in parallel with it's connection state.
	 */
	
	enum VendingStates //States in a transaction process
	{
		INIT,
		READY,
		WAIT,
		SELECTION,
		AUTH,
		FUNDS,
		VENDING,
		
		DUMP,
		FAILURE
	}
	
	/**
	 * Connections states will be determined in a parallel separate thread
	 * from the VendingStateMachine.
	 * 
	 * VendingStateMachine will poll the connection throughout the transaction,
	 * trying to detect a loss of connection.  In the event of a loss of connection,
	 * VendingStateMachine will dump the transaction and go to a waiting state.
	 * 
	 * Connection determination will be non-blocking and a timeout "guesser."
	 * After the timeout limit is reached, VendingStateMachine will either
	 * complete the transaction if sufficient funds were verified and store
	 * it for server processing when connection is re-established, or dump
	 * the transaction and the inmate will be up the proverbial fecal creek
	 * until reconnection.
	 */
	enum ConnectionStates
	{
		CONNECTED,
		NOTCONNECTED
	}
	
	public class VendingStateMachine
	{
		private static VendingStates curr_state;
		public static VendingStates Current_State
		{
			get{
				return curr_state;
			}
			protected set{
			}
		}
		public static System.Collections.Generic.Dictionary
			<Tuple<VendingStates, bool>, VendingStates> State_Transition;
		
		
		public VendingStateMachine ()
		{
			State_Transition = new System.Collections.Generic.Dictionary
			<Tuple<VendingStates, bool>, VendingStates>();
			
			//set up transition matrix
			//INIT
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.INIT, true),
			                     VendingStates.READY);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.INIT, false),
			                     VendingStates.READY);
			//READY
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.READY, true),
			                     VendingStates.SELECTION);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.READY, false),
			                     VendingStates.WAIT);
			//WAIT
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.WAIT, true),
			                     VendingStates.READY);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.WAIT, false),
			                     VendingStates.WAIT);
			//SELECTION
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.SELECTION, true),
			                     VendingStates.AUTH);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.SELECTION, false),
			                     VendingStates.DUMP);
			//AUTH
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.AUTH, true),
			                     VendingStates.FUNDS);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.AUTH, false),
			                     VendingStates.DUMP);
			//FUNDS
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.FUNDS, true),
			                     VendingStates.VENDING);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.FUNDS, false),
			                     VendingStates.DUMP);
			//VENDING
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.VENDING, true),
			                     VendingStates.READY);
			State_Transition.Add(new Tuple<VendingStates, bool>(VendingStates.VENDING, false),
			                     VendingStates.FAILURE);
			
		}// end CONSTRUCTOR
		
		public static void Next_State()
		{
			switch(curr_state)
			{
			case VendingStates.INIT:
				break;
			case VendingStates.READY:
				break;
			case VendingStates.WAIT:
				break;
			case VendingStates.SELECTION:
				break;
			case VendingStates.AUTH:
				break;
			case VendingStates.FUNDS:
				break;
			case VendingStates.VENDING:
				break;
			case VendingStates.DUMP:
				break;
			case VendingStates.FAILURE:
				break;
				
			}//end switch / case
		}
		
		public static bool init()
		{
		}
		
		public static bool ready()
		{
		}
		
		public static bool wait()
		{
		}
		
		public static bool selection()
		{
		}
		
		public static bool auth()
		{
		}
		public static bool funds()
		{
		}
		
		public static bool vending()
		{
		}
		
		public static bool dump()
		{
		}
		
		public static bool failure()
		{
		}
	}
}

