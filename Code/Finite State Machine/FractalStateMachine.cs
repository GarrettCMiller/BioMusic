using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace BioMusic.Code.FSM
{
	[Serializable()]
	public class FractalStateMachine : QueuedStateMachine, IStateMachineState
	{
		#region FractalStateMachine
		
		#region Construction

		public FractalStateMachine(string name) : base(name)
		{
		}

		public FractalStateMachine(FractalStateMachine parentFSM, string name) : base(name)
		{
			if (parentFSM == null)
				throw new FSMException("Cannot have a null parent StateMachine!");

			this.SMSParentStateMachine = parentFSM;
			this.SMSTransitions = new ArrayList();

			this.SMSValid = true;

			//this.SMSParentStateMachine.FSM_AddState(this);

			this.SMSName = name;
		}

		public FractalStateMachine(FractalStateMachine parentFSM) : base("unknown")
		{
			throw new FSMException("Shouldn't be here");
		}

		#endregion

		#region Methods

		public virtual void Destroy()
		{
			this.SMS_Destroy();
			this.FSM_Destroy();
		}

		#endregion

		#region Properties

		public string Name
		{
			get { return this.FSMName; }
			protected set { this.FSMName = value; }
		}

		#endregion

		#endregion

		#region QueuedStateMachine overrides



		#endregion

		#region FSMStateBase (copy and paste) implementation

		#region FSMStateBase

		#region Fields

		protected IStateMachine SMS_parentStateMachine;
		protected bool SMS_bValid = false;
		protected string SMS_strName;
		protected ArrayList SMS_arrTransitions;

		#endregion		

		#endregion

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

		public virtual FSMResult SMS_Initialize()
		{
			SMS_Reset();

			//Fire OnInitialize event
			SMS_OnInitialize();

			return FSMResult.Success;
		}

		public virtual FSMResult SMS_Update(object[] arrArgs)
		{
			//Fire OnUpdate event
			SMS_OnUpdate();

			if (FSM_Update(arrArgs) == FSMResult.Fail)
			{
				if (FSM_ChangeStates() == FSMResult.Fail)
					return FSMResult.Fail;
			}

			return FSMResult.Success;
		}

		#region Transition methods

		public virtual FSMResult SMS_EnterState(object[] arrArgs)
		{
			//Fire OnEnterState event
			SMS_OnEnterState();

			return FSMResult.Success;
		}

		public virtual FSMResult SMS_ExitState(object[] arrArgs)
		{
			//Fire OnExitState event
			SMS_OnExitState();

			return FSMResult.Success;
		}

		#endregion

		#endregion

		#region Messaging

		public virtual FSMResult SMS_SendMessage(object sender, FSMMessage msg)
		{
			//Fire OnSendMessage event
			SMS_OnSendMessage();

			//TODO: Send message to all QueuedStateMachine states

			return FSMResult.Success;
		}

		#endregion

		#endregion

		#region Adding transitions

		public virtual void SMS_AddValidTransition(IStateMachineState validState)
		{
			this.SMSTransitions.Add(validState);

			//Fire OnTransitionAdded event
			SMS_OnTransitionAdded();
		}

		#endregion

		#region Clean up

		public virtual FSMResult SMS_Reset()
		{
			//Fire OnReset event
			SMS_OnReset();

			//nothing to reset right now

			return FSMResult.Success;
		}

		public virtual FSMResult SMS_Destroy()
		{
			//Fire OnDestroy event
			SMS_OnDestroy();

			this.SMS_Reset();

			if (this.SMSTransitions != null)
				this.SMSTransitions.Clear();

			return FSMResult.Success;
		}

		#endregion

		#region Transition helpers

		public virtual bool SMS_IsValidTransition(IStateMachineState nextState)
		{
			foreach (IStateMachineState state in this.SMSTransitions)
				if (state == nextState) return true;

			return false;
		}

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
		IStateMachineState IStateMachineState.this[string name]
		{
			get
			{
				foreach (IStateMachineState state in this.SMSTransitions)
					if (state.SMSName == name) return state;

				throw new FSMException("State with name '" + name + "' not found as transition!");
			}
		}

		//Get transition by index
		IStateMachineState IStateMachineState.this[int index]
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
}
