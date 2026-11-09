using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic.Code.Utility
{
	/// <summary>
	/// A ghetto assertion class
	/// </summary>
	class LocalNullException : NullReferenceException
	{
		#region Static

		/// <summary>
		/// Asserts the bool value (or expression evaluating to bool).
		/// </summary>
		/// <param name="val"></param>
		public static void Assert(bool val)
		{
			if (!val) throw new LocalNullException();
		}

		/// <summary>
		/// Asserts an object is not null
		/// </summary>
		/// <param name="o"></param>
		public static void Assert(object o)
		{
			if (o == null) throw new LocalNullException("Null object found!");
		}

		/// <summary>
		/// Returns whether or not the object is NOT equal to null
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static bool ObjectExists(object o)
		{
			return (o != null);
		}

		#endregion

		#region Construction

		public LocalNullException() : base() { }

		public LocalNullException(string message) : base(message) {	}

		#endregion
	}
}
