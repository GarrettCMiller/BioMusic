using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BioMusic.Code.MusicForms;
using BioMusic.Code.Utility;

namespace BioMusic.Code.Forms.Controls
{
	public partial class MusicStructureViewer : UserControl
	{
		#region Enums

		/// <summary>
		/// The different display modes for the musical structures.
		/// </summary>
		public enum ViewMode
		{
			WebMap,
			Outline,
			Staff,
			FlowChart
		}

		#endregion

		#region Delegates

		/// <summary>
		/// Describes a function that handles rendering
		/// different view modes.
		/// </summary>
		/// <param name="e"></param>
		public delegate void ViewModeRenderMethod(PaintEventArgs e);
		
		/// <summary>
		/// Sortof typedef or wrapper to shorten the name
		/// EnumeratedDelegate&lt;ViewMode, ViewModeRenderMethod&gt;.
		/// </summary>
		protected sealed class ViewModeDelegate : EnumeratedDelegate<ViewMode, ViewModeRenderMethod>
		{
			public ViewModeDelegate(ViewModeRenderMethod[] arrFuncs) : base(arrFuncs) { }
		}

		#endregion

		#region Fields

		/// <summary>
		/// The current view mode to render.
		/// </summary>
		private ViewMode viewMode;

		/// <summary>
		/// The main project object containing all the songs.
		/// </summary>
		protected Project.Project mainProject;

		/// <summary>
		/// The EnumeratedDelegate that handles the
		/// different render states.
		/// </summary>
		private ViewModeDelegate viewModeHandler;

		/// <summary>
		/// Web map controls.
		/// </summary>
		private SortedList<string, Control> webMapControls;

		#endregion

		#region Properties

		/// <summary>
		/// Gets/Sets the current view mode.
		/// </summary>
		public ViewMode CurrentViewMode
		{
			get { return viewMode; }
			set
			{
				viewMode = value;
				viewModeHandler.CurrentMode = viewMode;
				UpdateWebMapWindows();
				this.Invalidate();
			}
		}

		/// <summary>
		/// Gets/Sets the EnumeratedDelegate object.
		/// </summary>
		protected ViewModeDelegate ViewModeHandler
		{
			get { return viewModeHandler; }
			set { viewModeHandler = value; }
		}

		#endregion

		#region Construction

		/// <summary>
		/// Sets the parent window and creates the render handler
		/// </summary>
		/// <param name="parent"></param>
		public MusicStructureViewer(Control parent)
		{
			InitializeComponent();

			OneTimeInit(parent);
		}

		#region One-time init

		protected virtual void OneTimeInit(Control parent)
		{
			this.Parent = parent;
			this.Dock = DockStyle.Fill;

			this.mainProject = ((MainWindow)parent.TopLevelControl).Project;

			CreateViewModeHandler();
		}

		#endregion

		#endregion

		#region Methods

		#region EnumeratedDelegate setup

		private void CreateViewModeHandler()
		{
			this.ViewModeHandler = new ViewModeDelegate
			(
				new ViewModeRenderMethod[]
				{
					RenderViewWebMap,
					RenderViewOutline,
					RenderViewStaff,
					RenderViewFlowChart
				}
			);
		}

		#endregion

		#region Painting

		#region View Mode Render Methods

		#region Utility

		/// <summary>
		/// Calls DrawBackground() with e.Graphics and the specified brush.
		/// </summary>
		/// <param name="e"></param>
		/// <param name="bgFill"></param>
		protected virtual void DrawBackground(PaintEventArgs e, Brush bgFill)
		{
			DrawBackground(e.Graphics, bgFill);
		}

		/// <summary>
		/// Calls DrawBackground() assuming this.Bounds for the rectangle
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="bgFill"></param>
		protected virtual void DrawBackground(Graphics graphics, Brush bgFill)
		{
			DrawBackground(graphics, bgFill, this.Bounds);
		}

		/// <summary>
		/// Draws a filled rectangle specified by bounds with the specified brush.
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="bgFill"></param>
		/// <param name="bounds"></param>
		protected virtual void DrawBackground(Graphics graphics, Brush bgFill, Rectangle bounds)
		{
			graphics.FillRectangle(bgFill, bounds);
		}

		#endregion

		#region Flow Chart View

		/// <summary>
		/// Base delegate for handling flow chart rendering.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void RenderViewFlowChart(PaintEventArgs e)
		{
			DrawBackground(e, Brushes.DarkGray);
		}
		
		#endregion

		#region Outline View

		/// <summary>
		/// Base delegate for handling outline rendering.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void RenderViewOutline(PaintEventArgs e)
		{
			DrawBackground(e, Brushes.DarkSeaGreen);

			//foreach (
		}
		
		#endregion

		#region Staff View

		/// <summary>
		/// Base delegate for handling staff rendering.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void RenderViewStaff(PaintEventArgs e)
		{
			DrawBackground(e, Brushes.DarkSlateBlue);
		}
		
		#endregion

		#region Web Map View

		/// <summary>
		/// Base delegate for handling web map rendering.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void RenderViewWebMap(PaintEventArgs e)
		{
			//if (webMapControls == null)
			//	CreateWebMapWindows();

			DrawBackground(e, Brushes.DarkSlateGray);
		}

		private void CreateWebMapWindows()
		{
			//webMapControls = new SortedList<string, Control>();

			foreach (MusicFormSong song in this.mainProject.Songs)
			{
				MusicWebViewForm newWindow = new MusicWebViewForm(this, song);
				
				//webMapControls.Add(song.Name, newWindow);
			}
		}

		public void UpdateWebMapWindows()
		{
			if (webMapControls != null)
			{
				this.listView.Items.Clear();
				//webMapControls.Clear();
				//webMapControls = null;
			}

			//CreateWebMapWindows();
		}
		
		#endregion

		#endregion

		/// <summary>
		/// Windows Controls Render method.
		/// </summary>
		/// <param name="e"></param>
		protected void Render(PaintEventArgs e)
		{
			this.ViewModeHandler.CurrentFunction(e);
		}

		#endregion

		#region Events

		private void MusicStructureViewer_Paint(object sender, PaintEventArgs e)
		{
			Render(e);
		}

		#endregion

		#endregion
	}
}
