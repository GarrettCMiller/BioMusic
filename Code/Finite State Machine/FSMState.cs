using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace BioMusic.Code.FSM
{
	////////////////////////////////////////////////////////////////////
	#region StateMachineState event helper code

	public class SMSEventArgs : EventArgs
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

		public SMSEventArgs(string s) : base()
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

	public delegate FSMResult SMSEventHandler(object sender, SMSEventArgs e);

	#endregion
	////////////////////////////////////////////////////////////////////

	////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////

	////////////////////////////////////////////////////////////////////
	#region IStateMachineState definition

	public interface IStateMachineState
	{
		/////////////////////////////////////////////////////
		#region Methods

		//////////////////////////////////////////////
		#region Main functions

		//////////////////////////////////////
		#region Major functions

		//Initialize the state machine state for use
		//(must be called before any other functions)
		FSMResult SMS_Initialize();

		//The main update function of the state
		FSMResult SMS_Update(object[] arrArgs);

		#region Transition functions

		//Called once before the state is actually entered
		FSMResult SMS_EnterState(object[] arrArgs);
		
		//Called once upon exiting the current state
		FSMResult SMS_ExitState(object[] arrArgs);

		#endregion

		#endregion
		//////////////////////////////////////

		//////////////////////////////////////
		#region Messaging

		//Sends a message to the state
		FSMResult SMS_SendMessage(object sender, FSMMessage msg);

		#endregion
		//////////////////////////////////////

		#endregion
		//////////////////////////////////////////////

		//////////////////////////////////////////////
		#region Adding transitions

		//Adds a valid transition state to this one
		void SMS_AddValidTransition(IStateMachineState validState);

		#endregion
		//////////////////////////////////////////////

		//////////////////////////////////////////////
		#region Clean up

		//Resets the state data
		FSMResult SMS_Reset();

		//Calls SMS_Reset() and clears all transitions
		FSMResult SMS_Destroy();

		#endregion
		//////////////////////////////////////////////

		//////////////////////////////////////////////
		#region Transition helpers

		//Returns true if the state passed in is contained
		//in the transitions list
		bool SMS_IsValidTransition(IStateMachineState nextState);

		//Sets the state machine that this state belongs to
		void SMS_SetParentStateMachine(IStateMachine parentFSM);

		#endregion
		//////////////////////////////////////////////

		#endregion
		/////////////////////////////////////////////////////

		/////////////////////////////////////////////////////
		#region Properties

		bool			SMSValid				{ get; }
		string			SMSName					{ get; }
		ArrayList		SMSTransitions			{ get; }
		IStateMachine	SMSParentStateMachine	{ get; }

		#endregion
		/////////////////////////////////////////////////////

		/////////////////////////////////////////////////////
		#region Indexers

		//Get transition by name
		IStateMachineState this[string name] { get; }

		//Get transition by index
		IStateMachineState this[int index] { get; }

		#endregion
		/////////////////////////////////////////////////////

		/////////////////////////////////////////////////////
		#region Events
		
		#region Individual event declarations

		#region Low frequency events

		//Sent after state has been fully initialized
		//(at end of Initialize())
		event SMSEventHandler SMSOnInitialize;
		
		//Sent after a valid transition has been added
		event SMSEventHandler SMSOnTransitionAdded;

		//Sent at the end of Reset(), after all data is reset
		event SMSEventHandler SMSOnReset;
		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		event SMSEventHandler SMSOnDestroy;

		//Sent after the parent StateMachine has been changed
		event SMSEventHandler SMSOnParentChanged;

		//Sent at the end of SMS_EnterState(), after the new state
		//has been set
		event SMSEventHandler SMSOnEnterState;

		//Sent at the end of SMS_ExitState(), after the state has
		//been fully let go
		event SMSEventHandler SMSOnExitState;

		#endregion

		#region High to medium frequency events

		//Sent every frame while the state is active
		event SMSEventHandler SMSOnUpdate;

		//Sent at the beginning of SMS_SendMessage(), before being
		//passed down to states
		event SMSEventHandler SMSOnSendMessage;

		#endregion

		#endregion

		#region Triggers (event firing wrappers)

		#region Low frequency event triggers

		#endregion

		#region High to medium frequency event triggers

		#endregion

		#endregion

		#endregion
		/////////////////////////////////////////////////////
	}

	#endregion
	////////////////////////////////////////////////////////////////////

	////////////////////////////////////////////////////////////////////
	#region Base implementation of IStateMachineState

	[Serializable()]
	public abstract class FSMStateBase : IStateMachineState
	{
		#region FSMStateBase

		#region Fields

		protected IStateMachine SMS_parentStateMachine;
		protected bool SMS_bValid = false;
		protected string SMS_strName;
		protected ArrayList SMS_arrTransitions;

		#endregion

		#region Construction

		public FSMStateBase(IStateMachine parentFSM, string name)
		{
			if (parentFSM == null)
				throw new FSMException("Cannot have a null parent StateMachine!");

			this.SMSParentStateMachine = parentFSM;
			this.SMSName = name;
			this.SMSValid = true;
			this.SMSTransitions = new ArrayList();

			this.SMSParentStateMachine.FSM_AddState(this);
			
			SMS_Initialize();
		}

		public FSMStateBase(IStateMachine parentFSM)
		{
			if (parentFSM == null)
				throw new FSMException("Cannot have a null parent StateMachine!");

			this.SMSParentStateMachine = parentFSM;
			this.SMSName = "Unknown";
			this.SMSValid = true;
			this.SMSTransitions = new ArrayList();

			this.SMSParentStateMachine.FSM_AddState(this);

			SMS_Initialize();
		}

		#endregion

		#endregion

		#region Inheritance/Interface implementation

		#region IStateMachineState implementation

		#region Properties

		public virtual bool SMSValid
		{
			get { return SMS_bValid; }
			protected set { SMS_bValid = value; }
		}

		public virtual string SMSName
		{
			get { return SMS_strName; }
			protected set { SMS_strName = value; }
		}

		public virtual ArrayList SMSTransitions
		{
			get { return SMS_arrTransitions; }
			protected set { SMS_arrTransitions = value; }
		}

		public virtual IStateMachine SMSParentStateMachine
		{
			get { return SMS_parentStateMachine; }
			protected set { SMS_SetParentStateMachine(value); }
		}

		#endregion

		#region Methods

		#region Main functions

		#region Major functions

		//Initialize the state machine state for use
		//(must be called before any other functions)
		public virtual FSMResult SMS_Initialize()
		{
			SMS_Reset();

			//Fire OnInitialize event
			SMS_OnInitialize();

			return FSMResult.Success;
		}

		//The main update function of the state
		public virtual FSMResult SMS_Update(object[] arrArgs)
		{
			//Fire OnUpdate event
			SMS_OnUpdate();

			return FSMResult.Success;
		}

		#region Transition methods

		//Called once before the state is actually entered
		public virtual FSMResult SMS_EnterState(object[] arrArgs)
		{
			//Fire OnEnterState event
			SMS_OnEnterState();

			return FSMResult.Success;
		}

		//Called once upon exiting the current state
		public virtual FSMResult SMS_ExitState(object[] arrArgs)
		{
			//Fire OnExitState event
			SMS_OnExitState();

			return FSMResult.Success;
		}

		#endregion

		#endregion

		#region Messaging

		//Sends a message to the state
		public virtual FSMResult SMS_SendMessage(object sender, FSMMessage msg)
		{
			//Fire OnSendMessage event
			SMS_OnSendMessage();

			return FSMResult.Success;
		}

		#endregion

		#endregion

		#region Adding transitions

		//Adds a valid transition state to this one
		public virtual void SMS_AddValidTransition(IStateMachineState validState)
		{
			this.SMSTransitions.Add(validState);

			//Fire OnTransitionAdded event
			SMS_OnTransitionAdded();
		}

		#endregion

		#region Clean up

		//Resets the state data
		public virtual FSMResult SMS_Reset()
		{
			//Fire OnReset event
			SMS_OnReset();

			//nothing to reset right now

			return FSMResult.Success;
		}

		//Calls SMS_Reset() and clears all transitions
		public virtual FSMResult SMS_Destroy()
		{
			//Fire OnDestroy event
			SMS_OnDestroy();

			this.SMS_Reset();

			this.SMSTransitions.Clear();

			return FSMResult.Success;
		}

		#endregion

		#region Transition helpers

		//Returns true if the state passed in is contained
		//in the transitions list
		public virtual bool SMS_IsValidTransition(IStateMachineState nextState)
		{
			foreach (IStateMachineState state in this.SMSTransitions)
				if (state == nextState) return true;

			return false;
		}

		//Sets the state machine that this state belongs to
		public virtual void SMS_SetParentStateMachine(IStateMachine parentFSM)
		{
			SMS_parentStateMachine = parentFSM;

			//Fire OnParentChanged event
			SMS_OnParentChanged();
		}

		#endregion

		#endregion

		#region Indexers

		//Get transition by name
		public virtual IStateMachineState this[string name]
		{
			get
			{
				foreach (IStateMachineState state in this.SMSTransitions)
					if (state.SMSName == name) return state;

				throw new FSMException("State with name '" + name + "' not found as transition!");
			}
		}

		//Get transition by index
		public virtual IStateMachineState this[int index]
		{
			get { return (IStateMachineState)this.SMSTransitions[index]; }
		}

		#endregion

		#region Events

		#region Individual event declarations

		#region Low frequency events

		//Sent after state has been fully initialized
		//(at end of Initialize())
		public event SMSEventHandler SMSOnInitialize;

		//Sent after a valid transition has been added
		public event SMSEventHandler SMSOnTransitionAdded;

		//Sent at the end of Reset(), after all data is reset
		public event SMSEventHandler SMSOnReset;
		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		public event SMSEventHandler SMSOnDestroy;

		//Sent after the parent StateMachine has been changed
		public event SMSEventHandler SMSOnParentChanged;

		//Sent at the end of SMS_EnterState(), after the new state
		//has been set
		public event SMSEventHandler SMSOnEnterState;

		//Sent at the end of SMS_ExitState(), after the state has
		//been fully let go
		public event SMSEventHandler SMSOnExitState;

		#endregion

		#region High to medium frequency events

		//Sent every frame while the state is active
		public event SMSEventHandler SMSOnUpdate;

		//Sent at the beginning of SMS_SendMessage(), before being
		//passed down to states
		public event SMSEventHandler SMSOnSendMessage;

		#endregion

		#endregion

		#region Triggers (event firing wrappers)

		#region Low frequency event triggers

		//Sent after the state has been fully initialized
		//(at end of Initialize())
		protected virtual void SMS_OnInitialize()
		{
			SMS_OnInitialize(null);
		}

		protected virtual void SMS_OnInitialize(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnInitialize;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnInitialize");

				eh(this, e);
			}
		}

		//Sent after a new transition is added to the state
		protected virtual void SMS_OnTransitionAdded()
		{
			SMS_OnTransitionAdded(null);
		}

		protected virtual void SMS_OnTransitionAdded(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnTransitionAdded;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnStateAdded");

				eh(this, e);
			}
		}

		//Sent at the end of Reset(), after all data is reset
		protected virtual void SMS_OnReset()
		{
			SMS_OnReset(null);
		}

		protected virtual void SMS_OnReset(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnReset;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnReset");

				eh(this, e);
			}
		}

		//Sent at the beginning of Destroy(), before any
		//cleanup is performed
		protected virtual void SMS_OnDestroy()
		{
			SMS_OnDestroy(null);
		}

		protected virtual void SMS_OnDestroy(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnDestroy;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnDestroy");

				eh(this, e);
			}
		}

		//Sent after the parent StateMachine has been changed
		protected virtual void SMS_OnParentChanged()
		{
			SMS_OnParentChanged(null);
		}

		protected virtual void SMS_OnParentChanged(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnParentChanged;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnParentChanged");

				eh(this, e);
			}
		}

		//Sent at the end of FSM_EnterState(), after the new state
		//has been set
		protected virtual void SMS_OnEnterState()
		{
			SMS_OnEnterState(null);
		}

		protected virtual void SMS_OnEnterState(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnEnterState;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnEnterState");

				eh(this, e);
			}
		}

		//Sent at the end of FSM_LeaveState(), after the state has
		//been fully let go
		protected virtual void SMS_OnExitState()
		{
			SMS_OnExitState(null);
		}

		protected virtual void SMS_OnExitState(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnExitState;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnExitState");

				eh(this, e);
			}
		}

		#endregion

		#region High to medium frequency event triggers

		//Sent every frame while the state is active
		protected virtual void SMS_OnUpdate()
		{
			SMS_OnUpdate(null);
		}

		protected virtual void SMS_OnUpdate(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnUpdate;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnUpdate");

				eh(this, e);
			}
		}

		//Sent at the beginning of SMS_SendMessage()
		protected virtual void SMS_OnSendMessage()
		{
			SMS_OnSendMessage(null);
		}

		protected virtual void SMS_OnSendMessage(SMSEventArgs e)
		{
			SMSEventHandler eh = SMSOnSendMessage;

			if (eh != null)
			{
				if (e == null) e = new SMSEventArgs("OnSendMessage");

				eh(this, e);
			}
		}

		#endregion

		#endregion
		
		#endregion

		#endregion

		#endregion
	}

	#endregion
	////////////////////////////////////////////////////////////////////

	////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////
	
	////////////////////////////////////////////////////////////////////
	#region Abstract generic StateMachineState implementation (not needed?)

#if false

	public abstract class FSMState<FSM> : FSMStateBase where FSM : StateMachine
	{
		#region FSMState<>

		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Construction

		public FSMState(FSM parentFSM, string name) : base(parentFSM, name)
		{
		}

		#endregion

		#region Methods

		#endregion

		#endregion

		#region StateMachine overrides

		#endregion
	}

#endif

	#endregion
	////////////////////////////////////////////////////////////////////
}
