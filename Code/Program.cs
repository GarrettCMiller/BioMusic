using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

using BioMusic.Code.Forms;

namespace BioMusic
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!EventLog.SourceExists("BioMusic"))
			{
				EventLog.CreateEventSource("BioMusic", "Log");

				MessageBox.Show("Had to create logger first time which requires a program restart!\n" +
								"Please run this program a second time!\n\nYou won't have to do this again, I promise!");

				return;
			}

			//Call the this Property to initialize the singleton
			BioMusic.Code.Utility.Logger.THIS.ToString();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}
}
