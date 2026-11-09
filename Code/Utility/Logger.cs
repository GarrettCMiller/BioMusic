using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BioMusic.Code.Utility
{
	public class LoggerMessage
	{
		#region Static

		#region Fields

		private static int currentID = -1;
		private static Stack<LoggerMessage> msgStack = new Stack<LoggerMessage>();

		#endregion

		#region Construction

		static LoggerMessage()
		{
			//tempErrorID = 0;
		}

		#endregion

		#region Properties

		public static LoggerMessage CurrentRoot
		{
			get { return MsgStack.Count == 0 ? null : MsgStack.Last(); }
		}

		public static LoggerMessage CurrentLeaf
		{
			get { return MsgStack.Count == 0 ? null : MsgStack.Peek(); }
			private set { MsgStack.Push(value); }
		}

		protected static Stack<LoggerMessage> MsgStack
		{
			get { return LoggerMessage.msgStack; }
			set { LoggerMessage.msgStack = value; }
		}

		public static int CurrentID
		{
			get { return currentID; }
		}

		public static int GetNextID
		{
			get { return ++currentID; }
		}

		#endregion

		#region Methods

		public static void Push(LoggerMessage msg)
		{
			LoggerMessage.CurrentLeaf = msg;
		}

		public static void Pop()
		{
			LoggerMessage.MsgStack.Pop();
		}

		#endregion

		#endregion

		#region Enums

		public enum MsgType
		{
			Information,
			Warning,
			Error,
			Success,
			Fail
		}

		#endregion

		#region Fields

		private MsgType msgType;
		private DateTime msgTimeStamp;
		private string msgText;
		private long eventID;
		private int category;

		private LoggerMessage parentMsg;
		private List<LoggerMessage> children;

		#endregion

		#region Properties

		public MsgType Type
		{
			get { return msgType; }
			set { msgType = value; }
		}

		public DateTime TimeStamp
		{
			get { return msgTimeStamp; }
			set { msgTimeStamp = value; }
		}

		public string Text
		{
			get { return msgText; }
			set { msgText = value; }
		}

		public long EventID
		{
			get { return eventID; }
			set { eventID = value; }
		}

		public int Category
		{
			get { return category; }
			set { category = value; }
		}

		public string CategoryName
		{
			get
			{
				string[] names = Enum.GetNames(typeof(Logger.CategoryName));
				return names[this.Category];
			}
		}

		public LoggerMessage ParentMsg
		{
			get { return parentMsg; }
			set
			{
				parentMsg = value;

				if (parentMsg != null)
					parentMsg.Children.Add(this);
			}
		}

		public List<LoggerMessage> Children
		{
			get { return children; }
			private set { children = value; }
		}

		#endregion

		#region Construction

		public LoggerMessage(string msg)
		{
			CreateChildList();

			this.Text = msg;
			this.TimeStamp = DateTime.Now;
			this.Type = MsgType.Information;

			SetParent();
		}

		public LoggerMessage(LoggerMessage parent, string msg)
		{
			CreateChildList();

			this.Text = msg;
			this.TimeStamp = DateTime.Now;
			this.Type = MsgType.Information;

			SetParent();
		}

		public LoggerMessage(EventInstance e, string msg)
		{
			CreateChildList();

			this.Text = msg;
			this.TimeStamp = DateTime.Now;
			this.Category = e.CategoryId;
			this.EventID = e.InstanceId;

			SetType(e.EntryType);

			SetParent();
		}

		public LoggerMessage(LoggerMessage parent, EventInstance e, string msg)
		{
			CreateChildList();

			this.Text = msg;
			this.TimeStamp = DateTime.Now;
			this.Category = e.CategoryId;
			this.EventID = e.InstanceId;
			this.ParentMsg = parent;

			SetType(e.EntryType);
		}

		public LoggerMessage(EventLogEntry entry)
		{
			CreateChildList();

			this.Text = entry.Message;
			this.TimeStamp = entry.TimeGenerated;
			this.Category = entry.CategoryNumber;
			this.EventID = entry.EventID;

			SetType(entry.EntryType);

			SetParent();
		}

		public LoggerMessage(LoggerMessage parent, EventLogEntry entry)
		{
			CreateChildList();

			this.Text = entry.Message;
			this.TimeStamp = entry.TimeGenerated;
			this.ParentMsg = parent;
			this.Category = entry.CategoryNumber;
			this.EventID = entry.EventID;

			SetType(entry.EntryType);
		}

		#endregion

		#region Methods

		private void SetParent()
		{
			if (LoggerMessage.CurrentLeaf != null)
			    this.ParentMsg = LoggerMessage.CurrentLeaf;
		}

		private void SetType(EventLogEntryType t)
		{
			switch (t)
			{
				case EventLogEntryType.Error: this.Type = MsgType.Error; break;
				case EventLogEntryType.Warning: this.Type = MsgType.Warning; break;
				case EventLogEntryType.Information: this.Type = MsgType.Information; break;
				case EventLogEntryType.SuccessAudit: this.Type = MsgType.Success; break;
				case EventLogEntryType.FailureAudit: this.Type = MsgType.Fail; break;
				default: throw new ApplicationException("Shouldn't be here!");
			}
		}

		private void CreateChildList()
		{
			this.Children = new List<LoggerMessage>();
		}

		#endregion
	}

	public class Logger
	{
		#region Static

		private static Logger singletonInstance;

		public static Logger THIS
		{
			get
			{
				if (singletonInstance == null)
					singletonInstance = new Logger();
				return singletonInstance;
			}
		}

		public static List<LoggerMessage> LoggerMessages
		{
			get { return THIS._LoggerMessages; }
		}

		#endregion

		#region Enums

		public enum CategoryName
		{
			None,
			ApplicationInitialization,
			FormControl,
			MusicFormCreation,
			Playback,
			FileIO,
			MIDI,
			External,
			Cleanup,
			Misc
		}

		#endregion

		#region Delegates

		#endregion

		#region Fields

		private System.Diagnostics.EventLog eventLogMain;

		private List<LoggerMessage> loggerMessages = new List<LoggerMessage>();

		object lockObject = new object();

		#endregion

		#region Properties

		public List<LoggerMessage> _LoggerMessages
		{
			get { return loggerMessages; }
			protected set { loggerMessages = value; }
		}

		public EventLog EventLog
		{
			get { return this.eventLogMain; }
			set { this.eventLogMain = value; }
		}

		#endregion

		#region Construction

		public Logger()
		{
			CreateEventLog();
		}

		#endregion

		#region Methods

		#region Message Logging

		private static LoggerMessage CreateMsgAndWrite(string message, EventInstance newEntry)
		{
			LoggerMessage loggerMsg = new LoggerMessage(newEntry, message);
			THIS.eventLogMain.WriteEvent(newEntry, new string[] { message });
			if (LoggerMessage.CurrentLeaf == null)
				THIS.loggerMessages.Add(loggerMsg);
			return loggerMsg;
		}

		#region Process

		public static void LogProcess(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)CategoryName.None, EventLogEntryType.Information);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			LoggerMessage.Push(loggerMsg);
		}

		public static void LogProcess(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.Information);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			LoggerMessage.Push(loggerMsg);
		}

		#endregion

		#region Errors

		public static LoggerMessage LogError(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)CategoryName.None, EventLogEntryType.Error);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogError(string message, int eventID)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.Error, eventID);
		//}

		public static LoggerMessage LogError(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.Error);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogError(string message, int eventID, short category)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.Error, eventID, category);
		//}

		#endregion

		#region Warnings

		public static LoggerMessage LogWarning(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID, 
				(int)CategoryName.None, EventLogEntryType.Warning);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogWarning(string message, int eventID)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.Warning, eventID);
		//}

		public static LoggerMessage LogWarning(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.Warning);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogWarning(string message, int eventID, int category)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.Warning, eventID, category);
		//}

		#endregion

		#region Messages

		public static LoggerMessage LogMessage(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID, 
				(int)CategoryName.None, EventLogEntryType.Information);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogMessage(string message, int eventID)
		//{
		//    EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
		//        (int)CategoryName.None, EventLogEntryType.Information);
		//    LoggerMessage loggerMsg = new LoggerMessage(newEntry, message);
		//    THIS.eventLogMain.WriteEvent(newEntry, new string[] { message });
		//    return loggerMsg;
		//}

		public static LoggerMessage LogMessage(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.Information);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogMessage(string message, int eventID, CategoryName category)
		//{
		//    EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
		//        (int)category, EventLogEntryType.Information);
		//    LoggerMessage loggerMsg = new LoggerMessage(newEntry, message);
		//    THIS.eventLogMain.WriteEvent(newEntry, new string[] { message });
		//    return loggerMsg;
		//}

		#endregion

		#region Success

		public static LoggerMessage LogSuccess(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)CategoryName.None, EventLogEntryType.SuccessAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogSuccess(string message, int eventID)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.SuccessAudit, eventID);
		//}

		public static LoggerMessage LogSuccess(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.SuccessAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogSuccess(string message, int eventID, short category)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.SuccessAudit, eventID, category);
		//}

		public static LoggerMessage LogProcessSuccess(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)CategoryName.None, EventLogEntryType.SuccessAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			LoggerMessage.Pop();
			return loggerMsg;
		}

		public static LoggerMessage LogProcessSuccess(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.SuccessAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			LoggerMessage.Pop();
			return loggerMsg;
		}

		#endregion

		#region Failure

		public static LoggerMessage LogFailure(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)CategoryName.None, EventLogEntryType.FailureAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogFailure(string message, int eventID)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.FailureAudit, eventID);
		//}

		public static LoggerMessage LogFailure(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.FailureAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			return loggerMsg;
		}

		//public static LoggerMessage LogFailure(string message, int eventID, short category)
		//{
		//    eventLogMain.WriteEntry(message, EventLogEntryType.FailureAudit, eventID, category);
		//}

		public static LoggerMessage LogProcessFail(string message)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)CategoryName.None, EventLogEntryType.FailureAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			LoggerMessage.Pop();
			return loggerMsg;
		}

		public static LoggerMessage LogProcessFail(string message, CategoryName category)
		{
			EventInstance newEntry = new EventInstance(LoggerMessage.GetNextID,
				(int)category, EventLogEntryType.FailureAudit);
			LoggerMessage loggerMsg = CreateMsgAndWrite(message, newEntry);
			LoggerMessage.Pop();
			return loggerMsg;
		}

		#endregion

		#endregion

		#region Initialization

		private void CreateEventLog()
		{
			this.eventLogMain = new System.Diagnostics.EventLog();

			((System.ComponentModel.ISupportInitialize)(this.eventLogMain)).BeginInit();

			this.eventLogMain.EnableRaisingEvents = true;
			this.eventLogMain.Log = "Log";
			this.eventLogMain.Source = "BioMusic";
			//this.eventLogMain.SynchronizingObject = lockObject;
			this.eventLogMain.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLogMain_EntryWritten);

			((System.ComponentModel.ISupportInitialize)(this.eventLogMain)).EndInit();
		}

		#endregion

		#region Logger events

		private void eventLogMain_EntryWritten(object sender, EntryWrittenEventArgs e)
		{
			EntryWrittenEventHandler eh = OnEntryWritten;

			if (eh != null)
				eh(sender, e);
		}

		#endregion	

		#endregion

		#region Indexers

		#endregion

		#region Events

		#region Event declarations

		public event EntryWrittenEventHandler OnEntryWritten;

		#endregion

		#region Triggers

		#endregion

		#endregion
	}
}
