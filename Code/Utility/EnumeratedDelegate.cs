using System;
using System.Collections;

//Needs to be included because conversion to an int doesn't work any other way as far as I can tell,
//and apparently it can't perform ENUM == ENUM or ENUM == int in generic functions
//If you can solve, please feel free to update the Unify page for this class
using System.Globalization;

namespace BioMusic.Code.Utility
{
	public class EnumeratedDelegate<ENUM, DelegateType>
		where ENUM : struct, IConvertible, IComparable, IFormattable
		where DelegateType : class
	{
		#region Static

		#region Construction

		/// <summary>
		/// Static class constructor asserts that the
		/// enum used in generic types is an actual enum.
		/// </summary>
		static EnumeratedDelegate()
		{
			//Assert that this class's first generic type is an enum
			if (!typeof(ENUM).IsEnum)
				throw new Exception("First argument of EnumeratedDelegate must be an enum!");
		}

		#endregion

		#endregion

		//////////////////////////////////////////////////////////////////////////////////////////////

		#region Fields

		/// <summary>
		/// The current mode represented by the
		/// corresponding enum value.
		/// </summary>
		private ENUM m_eCurrentMode;

		/// <summary>
		/// The current function corresponding to
		/// the current mode (enum value).
		/// </summary>
		private DelegateType m_fnCurrentFunction;

		/// <summary>
		/// The names of the enum values
		/// </summary>
		private string[] m_arrNames;

		/// <summary>
		/// The functions corresponding to the
		/// different enum values
		/// </summary>
		private DelegateType[] m_arrFunctions;

		#endregion

		#region Properties

		/// <summary>
		/// Get the number of names in the enum
		/// </summary>
		public int Count
		{
			get { return m_arrNames.Length; }
		}

		/// <summary>
		/// Get the current function
		/// </summary>
		public DelegateType CurrentFunction
		{
			get { return m_fnCurrentFunction; }
		}

		/// <summary>
		/// Get and set the functions safely
		/// </summary>
		public DelegateType[] Functions
		{
			get { return m_arrFunctions; }
			set
			{
				#region Safety

				if (m_arrNames == null || m_arrNames.Length == 0)
					throw new Exception("Must set enum first!");
				if (value.Length == 0)
					throw new Exception("Empty arrays not allowed!");
				if (value.Length != m_arrNames.Length)
					throw new Exception("Must have same number of functions as enum values!");

				#endregion

				m_arrFunctions = value;
			}
		}

		/// <summary>
		/// Get and set the current mode. When setting,
		/// change the function delegate appropriately
		/// </summary>
		public ENUM CurrentMode
		{
			get { return m_eCurrentMode; }
			set
			{
				#region Safety

				//Make sure that the value being passed in even corresponds to an existing enum value
				if (!Enum.IsDefined(typeof(ENUM), value))
					throw new Exception("'" + value + "' is not a valid member of the enum '" + typeof(ENUM).Name + "'!");

				#endregion

				for (int i = 0; i < this.Count; i++)
				{
					//TODO: Check to see if we should try and set the index by name instead and avoid the CultureInfo
					
					//Must convert because conversion to an int doesn't work any other way as far as I can tell,
					//and apparently it can't perform ENUM == ENUM or ENUM == int in generic functions
					int nValue = value.ToInt32(new CultureInfo("en-us"));

					if (i == nValue)
					{
						SetFunctionByIndex(i);
						m_eCurrentMode = value;
						return;
					}
				}

				throw new Exception("Couldn't find the enum somehow!");
			}
		}

		#endregion

		#region Construction

		/// <summary>
		/// Defaults CurrentMode property to the 0
		/// (zero) value of the enum.
		/// 
		/// NOTE: No functions have yet been assigned at
		/// this point and it will throw an exception if
		/// you don't assign the Functions property
		/// </summary>
		public EnumeratedDelegate()
		{
			m_arrNames = Enum.GetNames(typeof(ENUM));
			CurrentMode = (ENUM)Enum.GetValues(typeof(ENUM)).GetValue(0);
		}

		/// <summary>
		/// Sets the initial state to whichever enum value
		/// is equal to initialState.
		/// 
		/// NOTE: No functions have yet been assigned at
		/// this point and it will throw an exception if
		/// you don't assign the Functions property
		/// </summary>
		/// <param name="intialState"></param>
		public EnumeratedDelegate(int intialState)
		{
			m_arrNames = Enum.GetNames(typeof(ENUM));
			CurrentMode = (ENUM)Enum.ToObject(typeof(ENUM), intialState);
		}

		/// <summary>
		/// Assigns the Functions property to the functions
		/// in arrFuncs. CurrentMode property is set to the 
		/// 0 (zero) value of the enum.
		/// 
		/// NOTE: Functions must be in same order as the enum
		/// representing them.
		/// </summary>
		/// <param name="arrFuncs"></param>
		public EnumeratedDelegate(DelegateType[] arrFuncs)
		{
			m_arrNames = Enum.GetNames(typeof(ENUM));
			this.Functions = arrFuncs;
			CurrentMode = (ENUM)Enum.GetValues(typeof(ENUM)).GetValue(0);
		}

		/// <summary>
		/// Assigns the Functions property to the functions
		/// in arrFuncs and sets the initial state to whichever
		/// enum value is equal to initialState
		/// </summary>
		/// <param name="arrFuncs"></param>
		/// <param name="intialState"></param>
		public EnumeratedDelegate(DelegateType[] arrFuncs, int intialState)
		{
			m_arrNames = Enum.GetNames(typeof(ENUM));
			this.Functions = arrFuncs;
			CurrentMode = (ENUM)Enum.ToObject(typeof(ENUM), intialState);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sets the CurrentFunction property based on its
		/// index in the function list (or enum position).
		/// </summary>
		/// <param name="index"></param>
		public void SetFunctionByIndex(int index)
		{
			this.m_fnCurrentFunction = m_arrFunctions[index];
		}

		/// <summary>
		/// Sets the function by the name of the enum value
		/// </summary>
		/// <param name="name"></param>
		public void SetFunctionByEnumName(string name)
		{
			int i = 0;

			foreach (string _name in m_arrNames)
			{
				if (_name == name)
				{
					m_fnCurrentFunction = m_arrFunctions[i];
					return;
				}

				i++;
			}

			throw new Exception("Couldn't find an enum state representing given name: " + name);
		}

		#endregion

		//////////////////////////////////////////////////////////////////////////////////////////////
	}
}