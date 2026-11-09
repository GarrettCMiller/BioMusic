using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BioMusic.Code.MusicForms;

namespace BioMusic.Code.Forms.Controls
{
	public partial class MusicWebViewForm : Form //ListViewItem
	{
		#region Static

		private static int currentDepth = -1;
		private static int defaultMaxDepth = 4;

		public static int DefaultMaxDepth
		{
			get { return defaultMaxDepth; }
			set
			{
				#region Safety
				if (value < -1 || value > (int)MusicForm.Note)
					throw new ArgumentOutOfRangeException();
				#endregion
				defaultMaxDepth = value;
			}
		}

		#endregion

		#region Fields

		private MusicFormBase musicForm;
		private Control tempParent;

		#endregion

		#region Construction

		/// <summary>
		/// Meant to be a song (or top-level) window.
		/// </summary>
		/// <param name="parentForm"></param>
		/// <param name="musicForm"></param>
		public MusicWebViewForm(MusicStructureViewer parentForm, MusicFormBase musicForm)
		{
			InitializeComponent();
			tempParent = parentForm;
			this.MusicFormObject = musicForm;
			Initialize(DefaultMaxDepth);
		}

		/// <summary>
		/// Meant to be children of song (or top-level) windows.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="musicForm"></param>
		public MusicWebViewForm(MusicWebViewForm parent, MusicFormBase musicForm)
		{
			InitializeComponent();
			tempParent = parent;
			this.MusicFormObject = musicForm;
			Initialize(DefaultMaxDepth);
		}

		#endregion

		#region Methods

		#region Windows Events

		private void MusicWebViewForm_Load(object sender, EventArgs e)
		{

		}

		#endregion

		protected void SetBGColorByForm()
		{
			switch (this.MusicFormObject.Type)
			{
				case MusicForm.Song: this.BackColor = Color.Khaki;	break;

				case MusicForm.Section: this.BackColor = Color.Lavender; break;

				case MusicForm.Phrase: this.BackColor = Color.LavenderBlush; break;

				case MusicForm.Measure: this.BackColor = Color.GhostWhite; break;

				case MusicForm.Motif: this.BackColor = Color.LemonChiffon; break;

				case MusicForm.Cell: this.BackColor = Color.LightCoral; break;

				case MusicForm.Note: this.BackColor = Color.LawnGreen; break;

				default: this.BackColor = Color.HotPink; break;
			}
		}

		protected void ResizeWindow()
		{
			Rectangle rect = this.Bounds;
			double scale = 1.0 / currentDepth;
			rect.Width = (int)(scale * rect.Width);
			rect.Height = (int)(scale * rect.Height);
			rect.Location = Point.Empty;
			this.Bounds = rect;
		}

		protected void Initialize(int nChildWindowDepth)
		{
			currentDepth++;

			this.Name = this.MusicFormObject.Path;
			this.Text = this.MusicFormObject.Name;			
			this.Visible = true;
			this.TopLevel = false;

			SetBGColorByForm();

			if (currentDepth > 0)
				ResizeWindow();

			this.tempParent.SuspendLayout();

			if (currentDepth < nChildWindowDepth)
				foreach (MusicFormBase mform in musicForm.Children)
					new MusicWebViewForm(this, mform);

			this.tempParent.Controls.Add(this);

			this.tempParent.ResumeLayout(false);

			currentDepth--;
		}

		#endregion

		#region Enums

		#endregion

		#region Delegates

		#endregion

		#region Properties

		public MusicFormBase MusicFormObject
		{
			get { return this.musicForm; }
			protected set { this.musicForm = value; }
		}

		#endregion

		#region Indexers

		#endregion

		#region Events

		#endregion
	}
}
