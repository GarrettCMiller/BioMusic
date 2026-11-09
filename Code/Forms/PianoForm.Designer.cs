namespace GeneticMusicMaker.Code.Forms
{
	partial class PianoForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pianoControl1 = new Sanford.Multimedia.Midi.UI.PianoControl();
			this.sequencer1 = new Sanford.Multimedia.Midi.Sequencer();
			this.sequence1 = new Sanford.Multimedia.Midi.Sequence();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pianoControl1
			// 
			this.pianoControl1.HighNoteID = 109;
			this.pianoControl1.Location = new System.Drawing.Point(1, 1);
			this.pianoControl1.LowNoteID = 21;
			this.pianoControl1.Name = "pianoControl1";
			this.pianoControl1.NoteOnColor = System.Drawing.Color.SkyBlue;
			this.pianoControl1.Size = new System.Drawing.Size(424, 48);
			this.pianoControl1.TabIndex = 6;
			this.pianoControl1.Text = "pianoControl1";
			this.pianoControl1.PianoKeyDown += new System.EventHandler<Sanford.Multimedia.Midi.UI.PianoKeyEventArgs>(this.pianoControl1_PianoKeyDown);
			this.pianoControl1.PianoKeyUp += new System.EventHandler<Sanford.Multimedia.Midi.UI.PianoKeyEventArgs>(this.pianoControl1_PianoKeyUp);
			// 
			// sequencer1
			// 
			this.sequencer1.Position = 0;
			this.sequencer1.Sequence = this.sequence1;
			this.sequencer1.PlayingCompleted += new System.EventHandler(this.HandlePlayingCompleted);
			this.sequencer1.ChannelMessagePlayed += new System.EventHandler<Sanford.Multimedia.Midi.ChannelMessageEventArgs>(this.HandleChannelMessagePlayed);
			this.sequencer1.Stopped += new System.EventHandler<Sanford.Multimedia.Midi.StoppedEventArgs>(this.HandleStopped);
			this.sequencer1.SysExMessagePlayed += new System.EventHandler<Sanford.Multimedia.Midi.SysExMessageEventArgs>(this.HandleSysExMessagePlayed);
			this.sequencer1.Chased += new System.EventHandler<Sanford.Multimedia.Midi.ChasedEventArgs>(this.HandleChased);
			// 
			// sequence1
			// 
			this.sequence1.Format = 1;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// PianoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 50);
			this.Controls.Add(this.pianoControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "PianoForm";
			this.ShowInTaskbar = false;
			this.Text = "Piano";
			this.ResumeLayout(false);

		}

		#endregion

		private Sanford.Multimedia.Midi.UI.PianoControl pianoControl1;
		private Sanford.Multimedia.Midi.Sequencer sequencer1;
		private Sanford.Multimedia.Midi.Sequence sequence1;
		private System.Windows.Forms.Timer timer1;
	}
}