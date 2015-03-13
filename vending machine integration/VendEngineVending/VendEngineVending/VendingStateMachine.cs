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
		READY_TO_BEGIN,
		WAIT_FOR_CONNECTION,
		SELECTION_MADE,
		AUTH_PROVIDED,
		VALID_AUTH,
		INVALID_AUTH,
		VERIFY_FUNDS,
		SUFFICIENT_FUNDS,
		INSUFFICIENT_FUNDS,
		VENDING_ITEM,
		VEND_COMPLETE,
		
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
		
		public VendingStateMachine ()
		{
		}
	}
}

