using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace BioMusic.Code.FSM
{
	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////
	#region FSM Utility classes
	///////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	public class FSMResult
	{
		///////////////////////////////////////////
		#region Fields
		///////////////////////////////////////////

		private int intVal;
		private float floatVal;
		private bool bVal;
		private string strVal;

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Properties
		///////////////////////////////////////////

		#region Bools

		public bool Succeeded
		{
			get { return bVal; }
			set { bVal = value; }
		}

		public bool Failed
		{
			get { return !bVal; }
			set { bVal = !value; }
		}

		public bool True
		{
			get { return bVal; }
			set { bVal = value; }
		}

		public bool False
		{
			get { return !bVal; }
			set { bVal = !value; }
		}

		public bool BoolVal
		{
			get { return bVal; }
			set { bVal = value; }
		}

		#endregion

		public int IntVal
		{
			get { return intVal; }
			protected set { intVal = value; }
		}

		public float FloatVal
		{
			get { return floatVal; }
			protected set { floatVal = value; }
		}

		public string StringVal
		{
			get { return strVal; }
			protected set { strVal = value; }
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Construction
		///////////////////////////////////////////

		public FSMResult(bool val)
		{
			this.Succeeded = val;
		}

		public FSMResult(int val)
		{
			this.IntVal = val;
		}

		public FSMResult(float val)
		{
			this.FloatVal = val;
		}

		public FSMResult(string val)
		{
			this.StringVal = val;
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Static funcs
		///////////////////////////////////////////

		protected static readonly FSMResult success;
		protected static readonly FSMResult fail;

		static FSMResult()
		{
			FSMResult.success = new FSMResult(true);
			FSMResult.fail = new FSMResult(false);
		}

		public static FSMResult Success
		{
			get { return success; }
		}

		public static FSMResult Fail
		{
			get { return fail; }
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////
	}
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	public class FSMException : Exception
	{
		///////////////////////////////////////////
		#region Construction
		///////////////////////////////////////////
		
		public FSMException()
			: base()
		{
		}

		public FSMException(string message)
			: base(message)
		{
		}

		public FSMException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////
	}
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	public class FSMEventArgs : EventArgs
	{
		///////////////////////////////////////////
		#region Fields
		///////////////////////////////////////////

		protected string msg;

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Properties
		///////////////////////////////////////////

		public string Message
		{
			get { return msg; }
			protected set { msg = value; }
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Construction
		///////////////////////////////////////////

		public FSMEventArgs(string s) : base()
		{
			this.Message = s;
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Methods
		///////////////////////////////////////////

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////
	}
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////
	#endregion
	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////
	#region Finite State Machine base interface
	
	///////////////////////////////////////////////////////
	#region Event delegates
	
	public delegate FSMResult FSMEventHandler(object sender, FSMEventArgs e);

	#endregion
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	#region State machine messages

	public enum FSMMessageID
	{
		Stop
	}

	public class FSMMessage
	{
		#region Fields

		private ArrayList parameters;
		private FSMMessageID msgID;

		#endregion

		#region Construction

		public FSMMessage(FSMMessageID messageID)
		{
			this.ID = messageID;
		}

		public FSMMessage(FSMMessageID messageID, object arg)
		{
			this.ID = messageID;

			InitParameterList();

			this.Parameter = arg;
		}

		public FSMMessage(FSMMessageID messageID, ref ArrayList args)
		{
			this.ID = messageID;

			InitParameterList();

			this.Parameters.AddRange(args);
		}

		#endregion

		#region Properties

		public FSMMessageID ID
		{
			get { return msgID; }
			set { msgID = value; }
		}

		public virtual object Parameter
		{
			get { return this.Parameters[0]; }
			set { this.Parameters[0] = value; }
		}

		public virtual ArrayList Parameters
		{
			get { return parameters; }
			protected set { parameters = value; }
		}

		#endregion

		#region Indexers

		public object this[int i]
		{
			get { return this.Parameters[i]; }
			set { this.Parameters[i] = value; }
		}

		#endregion

		#region Methods

		#region Initialization

		private void InitParameterList()
		{
			parameters = new ArrayList();
		}

		#endregion

		#endregion
	}

	#endregion
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	public interface IStateMachine
	{
		///////////////////////////////////////////
		#region Methods

		////////////////////////////////
		#region Main functions

		//////////////////////////
		#region Major functions

		//Initialize the state machine and (usually) enter the first state
		FSMResult FSM_Initialize(IStateMachineState startState);
		
		//Called every frame that the state machine is active
		FSMResult FSM_Update(object[] arrArgs);
		
		//Called at the very end of the state machine's existence to clean up
		FSMResult FSM_Shutdown();

		#endregion
		//////////////////////////

		//////////////////////////
		#region Messaging

		//Send a message to the state machine and (potentially) to its current state
		FSMResult FSM_SendMessage(object sender, FSMMessage msg);
		
		#endregion
		//////////////////////////

		#endregion
		////////////////////////////////

		////////////////////////////////
		#region Clean up

		//Resets all values back to defaults without deleting states
		FSMResult FSM_Reset();

		//Clear all memory
		FSMResult FSM_Destroy();

		#endregion
		////////////////////////////////

		////////////////////////////////
		#region State transitions

		///////////////////////////
		#region Changing state

		//Handles exiting the current state (if there is one) and entering the next
		FSMResult FSM_ChangeStates();

		#endregion
		///////////////////////////

		///////////////////////////
		#region Entering state

		//Sets current state, nullifies next state and calls
		//IStateMachineState.OnEnter()
		FSMResult FSM_EnterState(IStateMachineState nextState);

		//Chooses the next state to enter and calls FSM_EnterState()
		FSMResult FSM_EnterNextState();

		#endregion
		///////////////////////////

		///////////////////////////
		#region Leaving state

		//Performs final cleanup and calls FSM_OnLeaveState()
		//before calling IStateMachineState.OnExit()
		FSMResult FSM_LeaveState();

		//Called before final cleanup during FSM_LeaveState()
		FSMResult FSM_PreLeaveState();

		#endregion
		///////////////////////////

		///////////////////////////
		#region Actual setting/queueing

		//Sets the FSMNextState property to the specified state
		//provided the next state is a valid transition for the current
		FSMResult FSM_SetNextState(IStateMachineState state);

		#region Queueing

		//Validates the specified state and enqueues the state
		//(meant to be protected/private)
		FSMResult FSM_QueueState(IStateMachineState state);

		//Same as FSM_QueueState(IStateMachineState), just looks
		//the state up by name. (Meant to be public)
		FSMResult FSM_QueueState(string stateName);

		#endregion

		#endregion
		///////////////////////////

		#endregion
		////////////////////////////////

		////////////////////////////////
		#region Adding states

		//Add state to possible states
		FSMResult FSM_AddState(IStateMachineState fsmState);

		//Add multiple states at once to possible states
		FSMResult FSM_AddStates(IStateMachineState[] fsmStateArray);
		
		#endregion
		////////////////////////////////

		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Properties
		
		//Gets/sets an ArrayList of the states
		ArrayList FSMStates { get; }

		//Gets/sets the name of the state machine
		string FSMName { get; }

		//Gets/sets current state
		IStateMachineState FSMCurrentState { get; }

		//Gets/sets next state
		IStateMachineState FSMNextState { get; }

		//Gets/sets whether or not the state machine
		//needs to change states
		bool FSMStateChanging { get; }

		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Indexers
		
		//Gets a state by name
		IStateMachineState this[string name] { get; }

		//Gets a state by numerical index
		IStateMachineState this[int index] { get; }

		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Events

		////////////////////////////////
		#region Individual event declarations

		///////////////////////////
		#region Low frequency events

		//Sent after state machine has been fully initialized
		//(at end of Initialize())
		event FSMEventHandler FSMOnInitialize;
		//Sent at very beginning of FSMShutdown(), before any
		//cleanup is performed
		event FSMEventHandler FSMOnShutdown;

		//Sent at the end of Reset(), after all data is reset
		event FSMEventHandler FSMOnReset;
		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		event FSMEventHandler FSMOnDestroy;

		//Sent after a new state is added to the FSM
		event FSMEventHandler FSMOnStateAdded;
		//Send after multiple new states have been added to the FSM
		event FSMEventHandler FSMOnStatesAdded;

		#endregion
		///////////////////////////

		///////////////////////////
		#region High to medium frequency events

		//Sent every frame while the FSM is active
		event FSMEventHandler FSMOnUpdate;

		//Sent at the beginning of FSM_SendMessage(), before being
		//passed down to states
		event FSMEventHandler FSMOnSendMessage;

		//Sent during state transition (FSM_ChangeStates()),
		//in-between FSM_LeaveState() and FSM_EnterNextState()
		event FSMEventHandler FSMOnChangeStates;

		//Sent at the end of FSM_EnterState(), after the new state
		//has been set
		event FSMEventHandler FSMOnEnterState;
		//Sent at the end of FSM_LeaveState(), after the state has
		//been fully let go
		event FSMEventHandler FSMOnLeaveState;

		//Sent once a new state has been queued
		event FSMEventHandler FSMOnStateQueued;

		#endregion
		///////////////////////////

		#endregion
		////////////////////////////////

		////////////////////////////////
		#region Triggers (event firing wrappers)

		///////////////////////////
		#region Low frequency event triggers

		//Sent after state machine has been fully initialized
		//(at end of Initialize())
		//void FSM_OnInitialize();
		//void FSM_OnInitialize(FSMEventArgs e);

		//Sent at very beginning of FSMShutdown(), before any
		//cleanup is performed
		//void FSM_OnShutdown();
		//void FSM_OnShutdown(FSMEventArgs e);

		//Sent at the end of Reset(), after all data is reset
		//void FSM_OnReset();
		//void FSM_OnReset(FSMEventArgs e);

		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		//void FSM_OnDestroy();
		//void FSM_OnDestroy(FSMEventArgs e);

		//Sent after a new state is added to the FSM
		//void FSM_OnStateAdded();
		//void FSM_OnStateAdded(FSMEventArgs e);

		//Send after multiple new states have been added to the FSM
		//void FSM_OnStatesAdded();
		//void FSM_OnStatesAdded(FSMEventArgs e);

		#endregion
		///////////////////////////

		///////////////////////////
		#region High to medium frequency event triggers

		//Sent every frame while the FSM is active
		//void FSM_OnUpdate();
		//void FSM_OnUpdate(FSMEventArgs e);

		//Sent at the beginning of FSM_SendMessage(), before being
		//passed down to states
		//void FSM_OnSendMessage();
		//void FSM_OnSendMessage(FSMEventArgs e);

		//Sent during state transition (FSM_ChangeStates()),
		//in-between FSM_LeaveState() and FSM_EnterNextState()
		//void FSM_OnChangeStates();
		//void FSM_OnChangeStates(FSMEventArgs e);

		//Sent at the end of FSM_EnterState(), after the new state
		//has been set
		//void FSM_OnEnterState();
		//void FSM_OnEnterState(FSMEventArgs e);

		//Sent at the end of FSM_LeaveState(), after the state has
		//been fully let go
		//void FSM_OnLeaveState();
		//void FSM_OnLeaveState(FSMEventArgs e);

		//Sent once a new state has been queued
		//void FSM_OnStateQueued();
		//void FSM_OnStateQueued(FSMEventArgs e);

		#endregion
		///////////////////////////

		#endregion
		////////////////////////////////

		#endregion
		///////////////////////////////////////////
	}
	///////////////////////////////////////////////////////

	#endregion
	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////
	#region Base StateMachine
	
	///////////////////////////////////////////////////////
	[Serializable()]
	public class StateMachine : IStateMachine
	{
		///////////////////////////////////////////
		#region StateMachine

		#region Fields

		protected ArrayList FSM_States;

		protected bool FSM_bInternalQueueState = false;

		protected string FSM_strName;

		protected IStateMachineState FSM_currentState;
		protected IStateMachineState FSM_nextState;

		#endregion

		#region Properties

		#endregion

		#region Construction

		public StateMachine(string name)
		{
			this.FSMName = name;
			this.FSM_States = new ArrayList();
			
			FSM_Reset();
		}

		#endregion

		#region Methods

		#endregion

		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Inheritance/Interface implementation
		
		#region IStateMachine implementation

		#region Methods

		#region Main functions

		#region Major functions

		public virtual FSMResult FSM_Initialize(IStateMachineState startState)
		{
			FSM_Reset();

			if (startState != null)
				this.FSM_SetNextState(startState);	//((StateMachine)this).FSM_SetNextState(startState);

			FSMResult result = FSM_ChangeStates();

			if (result == FSMResult.Success)
			{
				//Fire OnInitialize event
				FSM_OnInitialize();
			}

			return result;
		}

		public virtual FSMResult FSM_Update(object[] arrArgs)
		{
			//crit section lock
			{
				if (this.FSMStateChanging)
					if (FSM_ChangeStates() == FSMResult.Fail)
						return FSMResult.Fail;

				FSM_bInternalQueueState = true;

				if (this.FSMCurrentState.SMS_Update(null) == FSMResult.Fail)
				{
					FSM_bInternalQueueState = false;
					
					if (FSM_ChangeStates() == FSMResult.Fail)
						return FSMResult.Fail;
				}

				FSM_bInternalQueueState = false;

				//Fire OnUpdate event
				FSM_OnUpdate();
			}

			return FSMResult.Success;
		}

		public virtual FSMResult FSM_Shutdown()
		{
			//Fire OnShutdown event
			FSM_OnShutdown();

			return FSMResult.Success;
		}

		#endregion

		#region Messaging

		public virtual FSMResult FSM_SendMessage(object sender, FSMMessage msg)
		{
			//Fire OnSendMessage event
			FSM_OnSendMessage();

			return this.FSMCurrentState.SMS_SendMessage(sender, msg);
		}

		#endregion

		#endregion

		#region Clean up

		public virtual FSMResult FSM_Reset()
		{
			FSM_currentState = null;
			FSM_nextState = null;
			FSM_bInternalQueueState = false;

			//Fire OnReset event
			FSM_OnReset();

			return FSMResult.Success;
		}

		public virtual FSMResult FSM_Destroy()
		{
			//Fire OnDestroy event
			FSM_OnDestroy();

			this.FSM_Reset();

			this.FSM_States.Clear();

			return FSMResult.Success;
		}

		#endregion

		#region State transition

		#region Changing state

		/*protected*/public virtual FSMResult FSM_ChangeStates()
		{
			if (this.FSMCurrentState != null)
				if (FSM_LeaveState() == FSMResult.Fail)
					return FSMResult.Fail;

			//Fire OnChangeStates event
			FSM_OnChangeStates();

			return FSM_EnterNextState();
		}

		#endregion

		#region Entering state

		/*protected*/public virtual FSMResult FSM_EnterNextState()
		{
			return FSM_EnterState(this.FSMNextState);
		}

		/*protected*/public virtual FSMResult FSM_EnterState(IStateMachineState nextState)
		{
			if (!nextState.SMSValid)
				throw new FSMException("State is not valid!");

			this.FSMCurrentState = nextState;
			this.FSMNextState = null;

			if (this.FSMCurrentState.SMS_EnterState(null) == FSMResult.Fail)
				return FSMResult.Fail;

			//Fire OnEnterState event
			FSM_OnEnterState();

			return FSMResult.Success;
		}

		#endregion

		#region Leaving state

		/*protected*/public virtual FSMResult FSM_PreLeaveState()
		{
			return FSMResult.Success;
		}

		/*protected*/public virtual FSMResult FSM_LeaveState()
		{
			if (FSM_PreLeaveState() == FSMResult.Fail)
				return FSMResult.Fail;

			FSMResult result = this.FSMCurrentState.SMS_ExitState(null);

			//Fire OnLeaveState event
			FSM_OnLeaveState();

			return result;
		}

		#endregion

		#region Actual setting/queueing

		/*protected*/public virtual FSMResult FSM_SetNextState(IStateMachineState state)
		{
			if (!this.FSMCurrentState.SMS_IsValidTransition(state))
				throw new FSMException("Not a valid transition!");

			this.FSMNextState = state;

			return FSMResult.Success;
		}

		#region Queueing

		public virtual FSMResult FSM_QueueState(IStateMachineState state)
		{
			#region Safety

			//If we don't have a state at all
			if (state == null)
				throw new FSMException("No valid state!");

			//If the current state has the same name as the state to queue
			if (this.FSMCurrentState.SMSName == state.SMSName)
				throw new FSMException("Tried to queue same state!");

			//If we have a next state already queued and it has the same name as this one
			if (this.FSMNextState != null && this.FSMNextState.SMSName == state.SMSName)
				return new FSMResult("State already queued.");

			//If we have a next state period
			//TODO: Need to rethink this part a bit
			if (this.FSMNextState != null)
				throw new FSMException("A different state is already queued!");

			#endregion

			//if (!FSM_bInternalQueueState)
			//crit section lock

			FSMResult result = FSM_SetNextState(state);

			if (result == FSMResult.Success)
			{
				//Fire OnStateQueued event
				FSM_OnStateQueued();
			}
				
			//if (!FSM_bInternalQueueState)
			//unlock crit

			return result;
		}

		public virtual FSMResult FSM_QueueState(string stateName)
		{
			IStateMachineState state = (this)[stateName];

			return FSM_QueueState(state);
		}

		#endregion

		#endregion

		#endregion

		#region Adding states

		public virtual FSMResult FSM_AddState(IStateMachineState fsmState)
		{
			#region Safety

			if (!fsmState.SMSValid)
				throw new FSMException(fsmState.SMSName + " is not a valid state!");

			if (this.FSMStates.Contains(fsmState))
				throw new FSMException("State already in state machine!");

			#endregion

			FSMResult result = new FSMResult(this.FSMStates.Add(fsmState));

			//Fire OnStateAdded event
			FSM_OnStateAdded();

			return result;
		}

		public virtual FSMResult FSM_AddStates(IStateMachineState[] fsmStateArray)
		{
			#region Safety

			foreach (FSMStateBase fsmState in fsmStateArray)
			{
				if (!fsmState.SMSValid)
					throw new FSMException(fsmState.SMSName + " is not a valid state!");

				if (this.FSMStates.Contains(fsmState))
					throw new FSMException("State already in state machine!");
			}

			#endregion

			this.FSMStates.AddRange(fsmStateArray);

			//Fire OnStatesAdded event
			FSM_OnStatesAdded();

			return FSMResult.Success;
		}

		#endregion

		#endregion

		#region Indexers

		//Get state by name
		public virtual IStateMachineState this[string name]
		{
			get
			{
				foreach (IStateMachineState state in this.FSMStates)
					if (state.SMSName == name) return state;

				throw new FSMException("State with name '" + name + "' not found");
			}
		}

		//Get state by numeric index
		public virtual IStateMachineState this[int index]
		{
			get { return (IStateMachineState)this.FSMStates[index]; }
		}

		#endregion

		#region Properties

		public ArrayList FSMStates
		{
			get { return FSM_States; }
			protected set { FSM_States = value; }
		}

		public string FSMName
		{
			get { return FSM_strName; }
			protected set { FSM_strName = value; }
		}

		public IStateMachineState FSMCurrentState
		{
			get { return FSM_currentState; }
			protected set { FSM_currentState = (IStateMachineState)value; }
		}

		public IStateMachineState FSMNextState
		{
			get { return FSM_nextState; }
			protected set { FSM_nextState = (FSMStateBase)value; }
		}

		public virtual bool FSMStateChanging
		{
			get { return this.FSMNextState != null; }
			protected set { this.FSMNextState = null; }
		}

		#endregion

		#region Events

		#region Individual event declarations

		#region Low frequency events

		//Sent after state machine has been fully initialized
		//(at end of Initialize())
		public event FSMEventHandler FSMOnInitialize;
		//Sent at very beginning of FSMShutdown(), before any
		//cleanup is performed
		public event FSMEventHandler FSMOnShutdown;

		//Sent at the end of Reset(), after all data is reset
		public event FSMEventHandler FSMOnReset;
		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		public event FSMEventHandler FSMOnDestroy;

		//Sent after a new state is added to the FSM
		public event FSMEventHandler FSMOnStateAdded;
		//Send after multiple new states have been added to the FSM
		public event FSMEventHandler FSMOnStatesAdded;
		
		#endregion

		#region High to medium frequency events

		//Sent every frame while the FSM is active
		public event FSMEventHandler FSMOnUpdate;

		//Sent at the beginning of FSM_SendMessage(), before being
		//passed down to states
		public event FSMEventHandler FSMOnSendMessage;

		//Sent during state transition (FSM_ChangeStates()),
		//in-between FSM_LeaveState() and FSM_EnterNextState()
		public event FSMEventHandler FSMOnChangeStates;

		//Sent at the end of FSM_EnterState(), after the new state
		//has been set
		public event FSMEventHandler FSMOnEnterState;
		//Sent at the end of FSM_LeaveState(), after the state has
		//been fully let go
		public event FSMEventHandler FSMOnLeaveState;

		//Sent once a new state has been queued
		public event FSMEventHandler FSMOnStateQueued;
		
		#endregion

		#endregion

		#region Triggers (event firing wrappers)

		#region Low frequency event triggers

		//Sent after state machine has been fully initialized
		//(at end of Initialize())
		protected virtual void FSM_OnInitialize()
		{
			FSM_OnInitialize(null);
		}

		protected virtual void FSM_OnInitialize(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnInitialize;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnInitialize");

				eh(this, e);
			}
		}

		//Sent at very beginning of FSMShutdown(), before any
		//cleanup is performed
		protected virtual void FSM_OnShutdown()
		{
			FSM_OnShutdown(null);
		}

		protected virtual void FSM_OnShutdown(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnShutdown;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnShutdown");

				eh(this, e);
			}
		}

		//Sent at the end of Reset(), after all data is reset
		protected virtual void FSM_OnReset()
		{
			FSM_OnReset(null);
		}

		protected virtual void FSM_OnReset(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnReset;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnReset");

				eh(this, e);
			}
		}

		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		protected virtual void FSM_OnDestroy()
		{
			FSM_OnDestroy(null);
		}

		protected virtual void FSM_OnDestroy(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnDestroy;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnDestroy");

				eh(this, e);
			}
		}

		//Sent after a new state is added to the FSM
		protected virtual void FSM_OnStateAdded()
		{
			FSM_OnStateAdded(null);
		}

		protected virtual void FSM_OnStateAdded(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnStateAdded;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnStateAdded");

				eh(this, e);
			}
		}

		//Send after multiple new states have been added to the FSM
		protected virtual void FSM_OnStatesAdded()
		{
			FSM_OnStatesAdded(null);
		}

		protected virtual void FSM_OnStatesAdded(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnStatesAdded;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnStatesAdded");

				eh(this, e);
			}
		}

		#endregion

		#region High to medium frequency event triggers

		//Sent every frame while the FSM is active
		protected virtual void FSM_OnUpdate()
		{
			FSM_OnUpdate(null);
		}

		protected virtual void FSM_OnUpdate(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnUpdate;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnUpdate");

				eh(this, e);
			}
		}

		//Sent at the beginning of FSM_SendMessage(), before being
		//passed down to states
		protected virtual void FSM_OnSendMessage()
		{
			FSM_OnSendMessage(null);
		}

		protected virtual void FSM_OnSendMessage(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnSendMessage;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnSendMessage");

				eh(this, e);
			}
		}

		//Sent during state transition (FSM_ChangeStates()),
		//in-between FSM_LeaveState() and FSM_EnterNextState()
		protected virtual void FSM_OnChangeStates()
		{
			FSM_OnChangeStates(null);
		}

		protected virtual void FSM_OnChangeStates(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnChangeStates;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnChangeStates");

				eh(this, e);
			}
		}

		//Sent at the end of FSM_EnterState(), after the new state
		//has been set
		protected virtual void FSM_OnEnterState()
		{
			FSM_OnEnterState(null);
		}

		protected virtual void FSM_OnEnterState(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnEnterState;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnEnterState");

				eh(this, e);
			}
		}

		//Sent at the end of FSM_LeaveState(), after the state has
		//been fully let go
		protected virtual void FSM_OnLeaveState()
		{
			FSM_OnLeaveState(null);
		}

		protected virtual void FSM_OnLeaveState(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnLeaveState;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnLeaveState");

				eh(this, e);
			}
		}

		//Sent once a new state has been queued
		protected virtual void FSM_OnStateQueued()
		{
			FSM_OnStateQueued(null);
		}

		protected virtual void FSM_OnStateQueued(FSMEventArgs e)
		{
			FSMEventHandler eh = FSMOnStateQueued;

			if (eh != null)
			{
				if (e == null) e = new FSMEventArgs("OnStateQueued");

				eh(this, e);
			}
		}

		#endregion

		#endregion

		#endregion

		#endregion

		#endregion
		///////////////////////////////////////////
	}
	///////////////////////////////////////////////////////

	#endregion
	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////
	#region Queued Finite State Machine
	///////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	#region Utility classes/interfaces
	///////////////////////////////////////////////////////

	[Serializable()]
	public class StateQueue<FSMStateType> : Queue
	{
		#region Construction

		public StateQueue()
			: base()
		{
		}

		#endregion

		#region Methods

		#region Queue overrides

		public void Enqueue(FSMStateType state)
		{
			base.Enqueue(state);
		}

		public new FSMStateType Dequeue()
		{
			return (FSMStateType)base.Dequeue();
		}

		public new FSMStateType Peek()
		{
			return (FSMStateType)base.Peek();
		}

		#endregion

		#endregion
	}

	///////////////////////////////////////////////////////
	#endregion
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	#region Queued FSM
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	[Serializable()]
	public class QueuedStateMachine : StateMachine
	{
		///////////////////////////////////////////
		#region Fields
		///////////////////////////////////////////

		protected bool FSM_bStateChanging = false;

		protected StateQueue<IStateMachineState> FSM_queuedStates;

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Properties
		///////////////////////////////////////////

		public IStateMachineState FSMNextQueuedState
		{
			get { return FSM_queuedStates.Peek(); }
		}

		public override bool FSMStateChanging
		{
			get { return FSM_bStateChanging; }
			protected set { FSM_bStateChanging = value; }
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Construction
		///////////////////////////////////////////

		public QueuedStateMachine(string name)
			: base(name)
		{
			FSM_queuedStates = new StateQueue<IStateMachineState>();
		}

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Methods
		///////////////////////////////////////////

		protected virtual IStateMachineState FSM_GetNextQueuedState()
		{
			return this.FSM_queuedStates.Dequeue();
		}

		#region StateMachine overrides

		#region Main functions

		#region Major functions

		public virtual FSMResult FSM_Initialize()
		{
			return this.FSM_Initialize(null);
		}

		public override FSMResult FSM_Initialize(IStateMachineState startState)
		{
			return base.FSM_Initialize(startState);
		}

		#endregion

		#region Messaging

		#endregion

		#endregion

		#region Clean up

		public override FSMResult FSM_Reset()
		{
			this.FSM_bStateChanging = false;

			return base.FSM_Reset();
		}

		public override FSMResult FSM_Destroy()
		{
			this.FSM_queuedStates.Clear();

			return base.FSM_Destroy();
		}

		#endregion

		#region State transition

		#region Changing state

		#endregion

		#region Entering state

		public override FSMResult FSM_EnterNextState()
		{
			if (this.FSM_queuedStates.Count == 0)
				return FSMResult.Fail;

			return FSM_EnterState(FSM_GetNextQueuedState());
		}

		#endregion

		#region Leaving state

		#endregion

		#region Actual setting/queueing

		public override FSMResult FSM_SetNextState(IStateMachineState state)
		{
			//if (this.FSMCurrentState != null)
			//    if (!this.FSMCurrentState.SMS_IsValidTransition(state))
			//        throw new FSMException("Not a valid transition!");

			FSM_queuedStates.Enqueue(state);

			return FSMResult.Success;
		}

		#region Queueing

		public override FSMResult FSM_QueueState(IStateMachineState state)
		{
			FSMResult result = FSM_SetNextState(state);

			if (result == FSMResult.Success)
			{
				//Fire OnStateQueued event
				FSM_OnStateQueued();
			}

			//if (!FSM_bInternalQueueState)
			//unlock crit

			return result;
		}

		public override FSMResult FSM_QueueState(string stateName)
		{
			IStateMachineState state = (this)[stateName];

			if (state == null)
				throw new FSMException("No valid state!");

			return FSM_QueueState(state);
		}

		#endregion

		#endregion

		#endregion

		#region Adding states

		#endregion

		#endregion

		///////////////////////////////////////////
		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Events



		#endregion
		///////////////////////////////////////////

		///////////////////////////////////////////
		#region Indexers

#if false
		//Get state by name
		public override IStateMachineState this[string name]
		{
			get
			{
				foreach (IStateMachineState state in this.FSMStates)
					if (state.SMSName == name) return state;

				throw new FSMException("State with name '" + name + "' not found");
			}
		}

		//Get state by numeric index
		public override IStateMachineState this[int index]
		{
			get { return (IStateMachineState)this.FSMStates[index]; }
		}
#endif

		#endregion
		///////////////////////////////////////////
	}
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////
	#endregion
	///////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////
	#endregion
	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////
}
