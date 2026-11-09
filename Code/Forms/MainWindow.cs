using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using BioMusic.Code.Forms;
using BioMusic.Code.Forms.Controls;
using BioMusic.Code.MusicForms;
using BioMusic.Code.Utility;
using BioMusic.Code.Project;

namespace BioMusic.Code.Forms
{
	public partial class MainWindow : Form
	{
		#region Fields

		/// <summary>
		/// The dialog that lets users manipulate chord properties.
		/// </summary>
		ChordSetupDialog chordSetupDlg;

		/// <summary>
		/// The window containing the piano control.
		/// </summary>
		PianoForm pianoWindow;

		/// <summary>
		/// The dialog that chooses the parent music form
		/// to put a new form under.
		/// </summary>
		StructureChooser dlgFormPicker;

		/// <summary>
		/// The main MusicStructureViewer control that handles
		/// rendering the various views of the music forms and
		/// their heirarchies.
		/// </summary>
		MusicStructureViewer mainMusicWindow;

		/// <summary>
		/// The current music form that is playing.
		/// </summary>
		MusicFormBase currentPiece;

		/// <summary>
		/// The project that is currently open.
		/// </summary>
		Project.Project currentProject;

		/// <summary>
		/// The dialog that lets users assign instruments
		/// to different MIDI channels.
		/// </summary>
		InstrumentChooser instrumentDlg;

		/// <summary>
		/// The create song mini tab button.
		/// </summary>
		Button btnCreateSong;

		#endregion

		///////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////

		#region Properties

		/// <summary>
		/// Gets/sets the current project.
		/// </summary>
		public Project.Project Project
		{
			get { return this.currentProject; }
			protected set { this.currentProject = value; }
		}

		/// <summary>
		/// Gets/sets the main music structure viewer window.
		/// </summary>
		public MusicStructureViewer MainMusicWindow
		{
			get { return mainMusicWindow; }
			protected set { mainMusicWindow = value; }
		}

		/// <summary>
		/// Gets/Sets the visibility of the piano window.
		/// </summary>
		public bool PianoWindowVisible
		{
			get { return pianoWindow.Visible; }

			set { pianoWindow.Visible = value; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////

		#region Methods

		#region Construction

		public MainWindow()
		{
			InitializeComponent();

			InitializeApplication();
		}

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Initialization

		/// <summary>
		/// The main initialization function.
		/// </summary>
		private void InitializeApplication()
		{
			AttachToLogger();

			Logger.LogSuccess("Logger successfully created and primary Windows forms have been initialized!", Logger.CategoryName.ApplicationInitialization);
			Logger.LogProcess("Initializing application...", Logger.CategoryName.ApplicationInitialization);
			Cursor = Cursors.AppStarting;

			CreateProjectFile();

			CreateNewButtonsOnTabControl();

			CreateMainMusicWindow();

			CreateRepository();

			CreateAllDialogs();

			Cursor = Cursors.Default;
			Logger.LogProcessSuccess("Successfully initialized BioMusic and it's components!", Logger.CategoryName.ApplicationInitialization);
		}		

		#region Misc

		/// <summary>
		/// Attach to the EventLog of the Logger singleton
		/// </summary>
		private void AttachToLogger()
		{
			Logger.THIS.EventLog.SynchronizingObject = this;
			Logger.THIS.EventLog.EntryWritten += new EntryWrittenEventHandler(eventLogMain_EntryWritten);
		}

		/// <summary>
		/// Creates the working project file.
		/// </summary>
		private void CreateProjectFile()
		{
			Logger.LogProcess("Creating project file...", Logger.CategoryName.ApplicationInitialization);

			this.Project = new BioMusic.Code.Project.Project();

			Logger.LogProcessSuccess("Successfully created project file!", Logger.CategoryName.ApplicationInitialization);
		}

		#endregion

		#region Controls

		#region New Musical Form Tab Buttons

		void CreateNewButtonsOnTabControl()
		{
			CreateNewButtonsOnTabControl(false);
		}

		void CreateNewButtonsOnTabControl(bool bCreateAll)
		{
			Logger.LogProcess("Creating music form creation buttons on tabs...", Logger.CategoryName.ApplicationInitialization);

			int btnIndex = 0;

			btnCreateSong = CreateMiniTabButton(btnIndex++);
			btnCreateSong.Click += new EventHandler(SongTabNew_Click);

			if (bCreateAll)
			{
				Button temp = CreateMiniTabButton(btnIndex++);
				temp.Click += new EventHandler(SequenceTabNew_Click);

				temp = CreateMiniTabButton(btnIndex++);
				temp.Click += new EventHandler(PhraseTabNew_Click);

				temp = CreateMiniTabButton(btnIndex++);
				temp.Click += new EventHandler(MeasureTabNew_Click);

				temp = CreateMiniTabButton(btnIndex++);
				temp.Click += new EventHandler(MotifTabNew_Click);

				//temp = CreateMiniTabButton(btnIndex++);
				//temp.Click += new EventHandler(CellTabNew_Click);
			}
			
			Logger.LogProcessSuccess("Mini music form creation buttons successfully initialized!", Logger.CategoryName.ApplicationInitialization);
		}

		private Button CreateMiniTabButton(int btnIndex)
		{
			string tabName = tabControlMainProperties.TabPages[btnIndex].Text;

			Logger.LogProcess("Creating " + tabName + " mini tab button...", Logger.CategoryName.ApplicationInitialization);
			
			Size defTabBtnSize = new Size(22, 18);
			Point defTabBtnLocation = new Point(4, tabControlMainProperties.Bounds.Top + 3);

			int imageIndex = this.tabControlMainProperties.TabPages[btnIndex].ImageIndex;

			if (btnIndex > 0)
			{
				for (int t = 0; t < btnIndex; t++)
					defTabBtnLocation.X += tabControlMainProperties.GetTabRect(t).Width;
			}
			
			Button temp = new Button();
			temp.Image = this.tabControlMainProperties.ImageList.Images[imageIndex];
			temp.TextAlign = ContentAlignment.TopCenter;
			temp.Location = defTabBtnLocation;
			temp.Size = defTabBtnSize;
			temp.Margin = new Padding(0);
			temp.Text = " ";
			temp.ForeColor = Color.Blue;
			temp.Font = new Font(temp.Font, FontStyle.Bold);
			temp.Cursor = Cursors.Hand;
			
			splitContainerMainRight.Panel1.Controls.Add(temp);
			temp.BringToFront();

			Logger.LogProcessSuccess("Successfully created " + tabName + " mini tab button!", Logger.CategoryName.ApplicationInitialization);
			
			return temp;
		}

		#endregion

		/// <summary>
		/// Creates the TreeListView logger
		/// </summary>
		private void CreateTreeListViewMsgLog()
		{
			this.treeListViewMessageLog.CanExpandGetter = delegate(object x)
			{
				return ((LoggerMessage)(x)).Children.Count > 0;
			};

			this.treeListViewMessageLog.ChildrenGetter = delegate(object x)
			{
				return new List<LoggerMessage>(((LoggerMessage)(x)).Children);
			};

			//BrightIdeasSoftware.TreeListView.TreeRenderer renderer = this.treeListViewMessageLog.TreeColumnRenderer;

			RebuildTreeListViewLog(false);
		}

		/// <summary>
		/// Creates the repository view.
		/// </summary>
		private void CreateRepository()
		{
			this.treeListViewRepository.CanExpandGetter = delegate(object x)
			{
				if (((MusicFormBase)(((DictionaryEntry)x).Value)).Children == null)
					return false;
				return ((MusicFormBase)(((DictionaryEntry)x).Value)).Children.Count > 0;
			};

			this.treeListViewRepository.ChildrenGetter = delegate(object x)
			{
				return (IEnumerable)((MusicFormBase)(((DictionaryEntry)x).Value)).Children;//.Clone();
			};

			RebuildRepositoryTreeView(false);
		}

		#endregion

		#region Main Music Window

		/// <summary>
		/// Creates the main window for the music layout.
		/// </summary>
		protected void CreateMainMusicWindow()
		{
			Logger.LogProcess("Creating main music window...", Logger.CategoryName.ApplicationInitialization);

			this.mainMusicWindow = new MusicStructureViewer(this.panelMainViewerFrame);

			Logger.LogProcessSuccess("Successfully created main music window!", Logger.CategoryName.ApplicationInitialization);
		}

		#endregion
		
		#region Dialogs

		/// <summary>
		/// Creates the chord setup dialog.
		/// </summary>
		private void CreateChordSetupDialog()
		{
			Logger.LogProcess("Creating the chord setup dialog...", Logger.CategoryName.ApplicationInitialization);

			this.chordSetupDlg = new ChordSetupDialog();
			//ShowChordChoiceDialog();

			Logger.LogProcessSuccess("Successfully created the chord setup dialog!", Logger.CategoryName.ApplicationInitialization);
		}

		/// <summary>
		/// Shows the chord choice dialog.
		/// </summary>
		private void ShowChordChoiceDialog()
		{
			if (!this.chordSetupDlg.Visible)
			{
				Logger.LogMessage("Showing chord choice dialog...");
				this.chordSetupDlg.Show(this);
			}
			else
				Logger.LogWarning("Chord choice dialog already open.");
		}

		/// <summary>
		/// Shows the splash dialog for Release versions at startup.
		/// </summary>
		private void ShowSplashDialog()
		{
#if !DEBUG
			ShowHelpReleaseNotes();

			ShowHelpBasicInstructions();
#endif
			
		}

		private static void ShowHelpReleaseNotes()
		{
			MessageBox.Show(
									 "* Deleteing songs sometimes causes weird behavior.\n" +
									 "* Adding anything other than songs (by the buttons on the different tabs) is broken right now.\n" +
									 "* Saving doesn't work right now. Sorry.\n" +
									 "* Checkboxes on the music tree object do nothing right now.\n\n" +
									 "* I haven't yet nailed down the octave checking for chords and sometimes it will try to play " +
									 "keys \"off the end\" of the piano on one side or another. This sometimes causes notes to continuously " +
									 "ring until you close the application down.\n\n" +
									 "* YOU MUST HIT STOP ON A SONG BEFORE PLAYING SOMETHING IF SOMETHING IS CURRENTLY PLAYING!!\n"
									 , "Important Notes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private static void ShowHelpBasicInstructions()
		{
			MessageBox.Show("How to create a song:\n\n" +
									 "1) Set the properties of the song that you would like to create on the song properties tab (scale, tempo, etc).\n" +
									 "\ta) Chances (rest note, chord) are in percentages.\n" +
									 "\tb) If you click the \"Chord Chance\" label (blue hyperlink), you  \tcan change chord properties.\n\n" +
									 "2)Click the New Song button at the top of the song tab, left of the \"Song\" label.\n\n" +
									 "3)The tree list in the bottom right will show the new song and let you immediately start typing a new name if you don't like the default.\n\n" +
									 "4)You can right-click the song and click play to play it, or you can expand the song to look at it's structure and play any individual sections, measures, etc that you want.\n\n" +
									 "\n\n" +
									 "Have fun! And I promise, I'm adding new stuff every day (like saving and being able to manipulate existing songs instead of creating a new one every time you change numbers)!"
									 , "INSTRUCTIONS", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Creates the instrument choice dialog.
		/// </summary>
		private void CreateInstrumentChooser()
		{
			Logger.LogProcess("Creating instrument dialog...");

			this.instrumentDlg = new InstrumentChooser();
			ShowInstrumentChooser();

			Logger.LogProcessSuccess("Instrument dialog successfully initialized!");
		}

		/// <summary>
		/// Shows the instrument choice dialog.
		/// </summary>
		private void ShowInstrumentChooser()
		{
			if (!this.instrumentDlg.Visible)
			{
				this.instrumentDlg.Show(this);
				Logger.LogSuccess("Showing instrument window.");
			}
			else
				Logger.LogWarning("Instrument window already open.");
		}

		/// <summary>
		/// Initialize control data to initial values.
		/// </summary>
		private void InitializeControlData()
		{
			Logger.LogProcess("Initializing control data...", Logger.CategoryName.ApplicationInitialization);

			this.songScaleTonic.SelectedIndex = 3;

			this.songScalePattern.Items.AddRange(Midi.Scale.Patterns);
			this.songScalePattern.SelectedIndex = 0;

			Random rand = new Random();
			this.comboBoxRootOctave.SelectedIndex = rand.Next(7);

			this.comboBoxOctaveSpan.SelectedIndex = 0;

			this.comboBoxSongSmallestNote.SelectedIndex = 4;
			this.comboBoxSongLongestNote.SelectedIndex = 2;
			this.SongTimeSignNumerator.SelectedIndex = 2;
			this.SongTimeSignDenominator.SelectedIndex = 1;

			Logger.LogProcessSuccess("Control data successfully initialized!", Logger.CategoryName.ApplicationInitialization);
		}

		/// <summary>
		/// Creates all of the misc. dialogs needed.
		/// </summary>
		private void CreateAllDialogs()
		{
			Logger.LogProcess("Initializing misc. dialogs...", Logger.CategoryName.ApplicationInitialization);

			CreateChordSetupDialog();

			CreatePianoWindow();

			InitializeControlData();

			CreateInstrumentChooser();

			CreateTreeListViewMsgLog();

			Logger.LogProcessSuccess("Misc. dialogs successfully initialized!", Logger.CategoryName.ApplicationInitialization);
		}

		#region Piano window

		void CreatePianoWindow()
		{
			Logger.LogProcess("Creating piano...", Logger.CategoryName.ApplicationInitialization);

			pianoWindow = new PianoForm();
			pianoWindow.Show(this);

			Logger.LogProcessSuccess("Piano successfully created!", Logger.CategoryName.ApplicationInitialization);
		}

		#endregion

		#endregion

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Misc control stuff

		/// <summary>
		/// Rebuilds the TreeListView logger and optionally preserves
		/// the selection state of the list view.
		/// </summary>
		/// <param name="bPreserveState">True to preserve selection state.</param>
		private void RebuildTreeListViewLog(bool bPreserveState)
		{
			treeListViewMessageLog.Roots = Logger.LoggerMessages;
			treeListViewMessageLog.RebuildAll(bPreserveState);
		}

		/// <summary>
		/// Rebuilds the TreeListView repository and optionally preserves
		/// the selection state of the list view.
		/// </summary>
		/// <param name="bPreserveState">True to preserve selection state.</param>
		private void RebuildRepositoryTreeView(bool bPreserveState)
		{
			treeListViewRepository.Roots = this.Project.Songs;
			treeListViewRepository.RebuildAll(bPreserveState);
		}

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Utility stuff

		#region Get Structure Names

		protected string[] GetSongNames()
		{
			ArrayList songNames = new ArrayList(treeViewMain.Nodes.Count);

			foreach (TreeNode node in treeViewMain.Nodes)
				songNames.Add(node.Text);

			string[] ret = new string[songNames.Count];
			songNames.CopyTo(ret);
			return ret;
		}

		protected string[] GetSequenceNames(TreeNode songNode)
		{
			ArrayList seqNames = new ArrayList(songNode.Nodes.Count);

			foreach (TreeNode node in songNode.Nodes)
				seqNames.Add(node.Text);

			string[] ret = new string[seqNames.Count];
			seqNames.CopyTo(ret);
			return ret;
		}

		protected string[] GetSequenceNames(string songName)
		{
			try
			{
				TreeNode songNode = GetSongNodeByName(songName);
				ArrayList seqNames = new ArrayList(songNode.Nodes.Count);

				foreach (TreeNode node in songNode.Nodes)
					seqNames.Add(node.Text);

				string[] ret = new string[seqNames.Count];
				seqNames.CopyTo(ret);
				return ret;
			}
			catch (ArgumentOutOfRangeException e)
			{
				Logger.LogError(e.Message, Logger.CategoryName.FormControl);
				throw;
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.Message, Logger.CategoryName.FormControl);
				throw;
			}
		}

		protected string[] GetPhraseNames(TreeNode sequenceNode)
		{
			ArrayList phraseNames = new ArrayList(sequenceNode.Nodes.Count);

			foreach (TreeNode node in sequenceNode.Nodes)
				phraseNames.Add(node.Text);

			string[] ret = new string[phraseNames.Count];
			phraseNames.CopyTo(ret);
			return ret;
		}

		protected string[] GetPhraseNames(string songName, string sequenceName)
		{
			try
			{
				TreeNode sequenceNode = GetSequenceNodeByName(GetSongNodeByName(songName), sequenceName);
				ArrayList phraseNames = new ArrayList(sequenceNode.Nodes.Count);

				foreach (TreeNode node in sequenceNode.Nodes)
					phraseNames.Add(node.Text);

				string[] ret = new string[phraseNames.Count];
				phraseNames.CopyTo(ret);
				return ret;
			}
			catch (ArgumentOutOfRangeException e)
			{
				Logger.LogError(e.Message, Logger.CategoryName.FormControl);
				throw;
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.Message, Logger.CategoryName.FormControl);
				throw;
			}
		}

		protected string[] GetMeasuresNames(TreeNode phraseNode)
		{
			ArrayList measureNames = new ArrayList(phraseNode.Nodes.Count);

			foreach (TreeNode node in phraseNode.Nodes)
				measureNames.Add(node.Text);

			string[] ret = new string[measureNames.Count];
			measureNames.CopyTo(ret);
			return ret;
		}

		protected string[] GetMeasuresNames(string songName, string sequenceName, string phraseName)
		{
			try
			{
				TreeNode phraseNode = GetPhraseNodeByName(GetSequenceNodeByName(GetSongNodeByName(songName), sequenceName), phraseName);
				ArrayList measureNames = new ArrayList(phraseNode.Nodes.Count);

				foreach (TreeNode node in phraseNode.Nodes)
					measureNames.Add(node.Text);

				string[] ret = new string[measureNames.Count];
				measureNames.CopyTo(ret);
				return ret;
			}
			catch (ArgumentOutOfRangeException e)
			{
				Logger.LogError(e.Message, Logger.CategoryName.FormControl);
				throw;
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.Message, Logger.CategoryName.FormControl);
				throw;
			}
		}

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Get Nodes By Name

		protected TreeNode GetSongNodeByName(string name)
		{
			foreach (TreeNode n in treeViewMain.Nodes)
				if (n.Text == name)
					return n;

			throw new ArgumentOutOfRangeException("No song by the name of " + name + "!");
		}

		protected TreeNode GetSequenceNodeByName(TreeNode songNode, string name)
		{
			foreach (TreeNode n in songNode.Nodes)
				if (n.Text == name)
					return n;

			throw new ArgumentOutOfRangeException("No sequence by the name of " + name + "!");
		}

		protected TreeNode GetPhraseNodeByName(TreeNode sequenceNode, string name)
		{
			foreach (TreeNode n in sequenceNode.Nodes)
				if (n.Text == name)
					return n;

			throw new ArgumentOutOfRangeException("No phrase by the name of " + name + "!");
		}

		protected TreeNode GetMeasureNodeByName(TreeNode phraseNode, string name)
		{
			foreach (TreeNode n in phraseNode.Nodes)
				if (n.Text == name)
					return n;

			throw new ArgumentOutOfRangeException("No measure by the name of " + name + "!");
		}

		protected TreeNode GetMotifNodeByName(TreeNode measureNode, string name)
		{
			foreach (TreeNode n in measureNode.Nodes)
				if (n.Text == name)
					return n;

			throw new ArgumentOutOfRangeException("No motif by the name of " + name + "!");
		}

		protected TreeNode GetCellNodeByName(TreeNode cellNode, string name)
		{
			foreach (TreeNode n in cellNode.Nodes)
				if (n.Text == name)
					return n;

			throw new ArgumentOutOfRangeException("No cell by the name of " + name + "!");
		}

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Form picker

		protected TreeNode PickForm(MusicForm choiceType)
		{
			dlgFormPicker = new StructureChooser(choiceType, treeViewMain.Nodes);

			dlgFormPicker.Location = Cursor.Position;

			if (dlgFormPicker.ShowDialog() == DialogResult.OK)
				return dlgFormPicker.SelectedItem;

			return null;
		}

		#endregion

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Song Structure Creation

		#region General function

		protected TreeNode CreateMusicObject(MusicForm formType)
		{
			TreeNode parentNode = null;

			if (formType != MusicForm.Song)
			{
				parentNode = PickForm((MusicForm)((int)formType - 1));

				//User cancelled or otherwise closed the choice dialog without making a choice
				if (parentNode == null) return null;
			}

			return CreateMusicObject(parentNode, formType);
		}

		protected TreeNode CreateMusicObject(TreeNode parentNode, MusicForm formType)
		{
			string formTypeName = formType.ToString();

			Logger.LogProcess("Creating new " + formTypeName + "...", Logger.CategoryName.MusicFormCreation);

			TreeNode newNode = null;

			string newName = formTypeName + " " +
			 ((parentNode == null ? this.treeViewMain.Nodes.Count : parentNode.Nodes.Count) + 1).ToString();

			if (formType == MusicForm.Song)
				newName = MusicFormBase.ClassDefaults.RootScale.Name
							+ " - " +
							MusicFormBase.ClassDefaults.RootOctave.ToString()
							+ " - #" +
							(this.treeViewMain.Nodes.Count + 1).ToString();

			try
			{
				if (parentNode != null)
				{
					if (parentNode.TreeView == this.treeViewMain)
						newNode = parentNode.Nodes.Add(newName, newName, (int)(formType - 1));
					else
					{
						try
						{
							TreeNode[] arrNodes = treeViewMain.Nodes.Find(parentNode.Name, true);
							newNode = arrNodes[0].Nodes.Add(newName, newName, (int)(formType - 1));
						}
						catch (IndexOutOfRangeException ex)
						{
							MessageBox.Show("Failed to create!\n" + ex.Message);
							throw;
						}
					}
				}
				else
					newNode = treeViewMain.Nodes.Add(newName, newName, 9);

				//Create children?
				//foreach (MusicFormBase child in newNode)
				//{
				//    CreateTreeNodeSection(newNode, section);
				//    switch (formType)
				//    {
				//        case MusicForm.Song: break;
				//        case MusicForm.Section: break;
				//        case MusicForm.Phrase: break;
				//        case MusicForm.Measure: break;
				//        case MusicForm.Motif: break;
				//        case MusicForm.Cell: break;
				//        case MusicForm.Note: break;
				//        default: throw new ApplicationException("Error!");
				//    }
				//}

				newNode.Checked = true;
				treeViewMain.SelectedNode = newNode;
			}
			catch (Exception ex)
			{
				Logger.LogProcessFail("Failed to create new " + formTypeName + "!\n" + ex.Message, Logger.CategoryName.MusicFormCreation);
				throw;
			}

			if (parentNode == null)
				Logger.LogProcessSuccess("Successfully added new song (" + newName + ")!", Logger.CategoryName.MusicFormCreation);
			else
				Logger.LogProcessSuccess("Successfully added new " + formTypeName + " (" + newName + ") to " + parentNode.FullPath + "!", Logger.CategoryName.MusicFormCreation);

			return newNode;
		}

		protected TreeNode CreateMusicObject(TreeNode parentNode, MusicFormBase form)
		{
			string formTypeName = form.Type.ToString();

			Logger.LogProcess("Creating new " + formTypeName + "...", Logger.CategoryName.MusicFormCreation);

			TreeNode newNode = null;

			string newName = formTypeName + " " +
			 ((parentNode == null ? this.treeViewMain.Nodes.Count : parentNode.Nodes.Count) + 1).ToString();

			if (form.Name != "")
				newName = form.Name;

			try
			{
				if (parentNode != null)
				{
					if (parentNode.TreeView == this.treeViewMain)
						newNode = parentNode.Nodes.Add(newName, newName, (int)(form.Type - 1));
					else
					{
						try
						{
							TreeNode[] arrNodes = treeViewMain.Nodes.Find(parentNode.Name, true);
							newNode = arrNodes[0].Nodes.Add(newName, newName, (int)(form.Type - 1));
						}
						catch (IndexOutOfRangeException ex)
						{
							MessageBox.Show("Failed to create!\n" + ex.Message);
							throw;
						}
					}
				}
				else
					newNode = treeViewMain.Nodes.Add(newName, newName, 9);

				foreach (MusicFormBase child in form.Children)
				{
					switch (form.Type)
					{
						case MusicForm.Song: CreateTreeNodeSection(newNode, (MusicFormSection)child); break;
						case MusicForm.Section: CreateTreeNodePhrase(newNode, (MusicFormPhrase)child); break;
						case MusicForm.Phrase: CreateTreeNodeMeasure(newNode, (MusicFormMeasure)child); break;
						case MusicForm.Measure: CreateTreeNodeMotif(newNode, (MusicFormMotif)child); break;
						case MusicForm.Motif: CreateTreeNodeCell(newNode, (MusicFormCell)child); break;
						case MusicForm.Cell: break;
						case MusicForm.Note:// CreateTreeNodeSection(newNode, section); break;
						default: throw new ApplicationException("Error!");
					}
				}

				newNode.Checked = true;
				treeViewMain.SelectedNode = newNode;
			}
			catch (Exception ex)
			{
				Logger.LogProcessFail("Failed to create new " + formTypeName + "!\n" + ex.Message, Logger.CategoryName.MusicFormCreation);
				throw;
			}

			if (parentNode == null)
				Logger.LogProcessSuccess("Successfully added new song (" + newName + ")!", Logger.CategoryName.MusicFormCreation);
			else
				Logger.LogProcessSuccess("Successfully added new " + formTypeName + " (" + newName + ") to " + parentNode.FullPath + "!", Logger.CategoryName.MusicFormCreation);

			return newNode;
		}

		#endregion

		#region Specific creation

		#region Song

		protected void CreateTreeNodeSong()
		{
			Logger.LogProcess("Now creating a random song with the specified parameters...", Logger.CategoryName.MusicFormCreation);

			MusicalProperties songProperties = ReadSongProperties();

			string newName = MusicFormBase.ClassDefaults.RootScale.Name
							+ " - " +
							MusicFormBase.ClassDefaults.RootOctave.ToString()
							+ " - #" +
							(this.treeViewMain.Nodes.Count + 1).ToString();

			MusicFormSong newSong = new MusicFormSong(newName);

			newSong.Properties = songProperties;
			
			newSong.Create();

			TreeNode newNode = CreateMusicObject(null, newSong);
			
			this.Project.AddSong(newSong);
			
			newNode.Tag = newSong;

			treeViewMain.CollapseAll();

			Logger.LogProcessSuccess("Song is in " + songProperties.RootScale.Name + "...", Logger.CategoryName.MusicFormCreation);

			this.MainMusicWindow.UpdateWebMapWindows();

			this.labelSongLength.Text = newSong.Length.ToString();

			RebuildRepositoryTreeView(true);

			treeViewMain.SelectedNode = treeViewMain.Nodes[treeViewMain.Nodes.Count - 1];
			treeViewMain.SelectedNode.BeginEdit();
		}

		private MusicalProperties ReadSongProperties()
		{
			int refindex = 0;
			Midi.Note tonic = Midi.Note.ParseNote((string)this.songScaleTonic.SelectedItem, ref refindex);
			Midi.ScalePattern pattern = Midi.Scale.Patterns[this.songScalePattern.SelectedIndex];

			MusicalProperties songProperties = MusicFormBase.ClassDefaults;

			songProperties.RootScale = new MusicScale(tonic, pattern);
			songProperties.Tempo = (int)this.upDownSongTempo.Value;
			songProperties.Numerator = byte.Parse((string)this.SongTimeSignNumerator.SelectedItem);
			songProperties.Denominator = byte.Parse((string)this.SongTimeSignDenominator.SelectedItem);
			songProperties.RootOctave = (COctave)this.comboBoxRootOctave.SelectedIndex;
			songProperties.OctaveSpan = 1;//int.Parse((string)this.comboBoxOctaveSpan.SelectedItem);
			songProperties.SmallestNoteValue = this.comboBoxSongSmallestNote.SelectedIndex;
			songProperties.LargestNoteValue = this.comboBoxSongLongestNote.SelectedIndex;
			songProperties.RestNoteChance = (float)this.restChance.Value / 100.0f;
			songProperties.NumSectionsPerSong = (uint)this.songPropertiesNumSections.Value;
			songProperties.NumPhrasesPerSection = (uint)this.songPropertiesNumPhrases.Value;
			songProperties.NumMeasuresPerPhrase = (uint)this.songPropertiesNumMeasures.Value;
			songProperties.ChordChance = (float)this.songPropertiesChordChance.Value / 100.0f;

			MusicFormBase.ClassDefaults = songProperties;
			return songProperties;
		}
		
		#endregion

		#region Section

		protected void CreateTreeNodeSection(TreeNode parentNode, MusicFormSection section)
		{
			TreeNode newNode = CreateMusicObject(parentNode, section);

			newNode.Tag = section;

			//foreach (MusicFormPhrase phrase in section.Phrases)
			//    CreateTreeNodePhrase(newNode, phrase);
		}

		protected void CreateTreeNodeSection()
		{
			TreeNode newNode = CreateMusicObject(MusicForm.Section);

			//Cancelled or something
			if (newNode == null)
				return;

			MusicFormSong parentForm = (MusicFormSong)newNode.Parent.Tag;
			MusicFormSection newSection = new MusicFormSection(parentForm, "Section " + parentForm.NumParts);

			newSection.Create();

			newNode.Tag = newSection;

			foreach (MusicFormPhrase phrase in newSection.Phrases)
				CreateTreeNodePhrase(newNode, phrase);

			treeViewMain.SelectedNode = newNode;

			treeViewMain.CollapseAll();

			treeViewMain.SelectedNode.BeginEdit();
		}
		
		#endregion

		#region Phrase

		protected void CreateTreeNodePhrase(TreeNode parentNode, MusicFormPhrase phrase)
		{
			TreeNode newNode = CreateMusicObject(parentNode, phrase);

			newNode.Tag = phrase;

			//foreach (MusicFormMeasure measure in phrase.Measures)
			//    CreateTreeNodeMeasure(newNode, measure);
		}

		protected void CreateTreeNodePhrase()
		{
			TreeNode newNode = CreateMusicObject(MusicForm.Phrase);

			//Cancelled or something
			if (newNode == null)
				return;

			MusicFormSection parentForm = (MusicFormSection)newNode.Parent.Tag;
			MusicFormPhrase newPhrase = new MusicFormPhrase(parentForm, "Phrase " + parentForm.NumParts);

			newPhrase.Create();

			newNode.Tag = newPhrase;

			foreach (MusicFormMeasure measure in newPhrase.Measures)
				CreateTreeNodeMeasure(newNode, measure);

			treeViewMain.SelectedNode = newNode;

			treeViewMain.CollapseAll();

			treeViewMain.SelectedNode.BeginEdit();
		}

		#endregion

		#region Measure

		protected void CreateTreeNodeMeasure(TreeNode parentNode, MusicFormMeasure measure)
		{
			TreeNode newNode = CreateMusicObject(parentNode, measure);

			newNode.Tag = measure;

			//foreach (MusicFormMotif motif in measure.Motifs)
			//    CreateTreeNodeMotif(newNode, motif);
		}

		protected void CreateTreeNodeMeasure()
		{
			TreeNode newNode = CreateMusicObject(MusicForm.Measure);

			//Cancelled or something
			if (newNode == null)
				return;

			MusicFormPhrase parentForm = (MusicFormPhrase)newNode.Parent.Tag;
			MusicFormMeasure newMeasure = new MusicFormMeasure(parentForm, "Measure " + parentForm.NumParts);

			newMeasure.Create();

			newNode.Tag = newMeasure;

			foreach (MusicFormMotif motif in newMeasure.Motifs)
				CreateTreeNodeMotif(newNode, motif);

			treeViewMain.SelectedNode = newNode;

			treeViewMain.CollapseAll();

			treeViewMain.SelectedNode.BeginEdit();
		}

		#endregion

		#region Motif

		protected void CreateTreeNodeMotif(TreeNode parentNode, MusicFormMotif motif)
		{
			TreeNode newNode = CreateMusicObject(parentNode, motif);

			newNode.Tag = motif;

			//foreach (MusicFormCell cell in motif.Cells)
			//    CreateTreeNodeCell(newNode, cell);
		}

		protected void CreateTreeNodeMotif()
		{
			TreeNode newNode = CreateMusicObject(MusicForm.Motif);

			//Cancelled or something
			if (newNode == null)
				return;

			MusicFormMeasure parentForm = (MusicFormMeasure)newNode.Parent.Tag;
			MusicFormMotif newMotif = new MusicFormMotif(parentForm, "Motif " + parentForm.NumParts);

			newMotif.Create();

			newNode.Tag = newMotif;

			foreach (MusicFormCell cell in newMotif.Cells)
				CreateTreeNodeCell(newNode, cell);

			treeViewMain.SelectedNode = newNode;

			treeViewMain.CollapseAll();

			treeViewMain.SelectedNode.BeginEdit();
		}

		#endregion

		#region Cell

		protected void CreateTreeNodeCell(TreeNode parentNode, MusicFormCell cell)
		{
			TreeNode newNode = CreateMusicObject(parentNode, cell);

			newNode.Tag = cell;
		}

		protected void CreateTreeNodeCell()
		{
			TreeNode newNode = CreateMusicObject(MusicForm.Cell);

			//Cancelled or something
			if (newNode == null)
				return;

			MusicFormMotif parentForm = (MusicFormMotif)newNode.Parent.Tag;
			MusicFormCell newCell = new MusicFormCell(parentForm, "Cell " + parentForm.NumParts);

			newCell.Create();

			newNode.Tag = newCell;

			//Notes?
			//foreach (MusicFormCell cell in newCell.Cells)
			//    CreateCell(newNode, cell);

			treeViewMain.SelectedNode = newNode;

			treeViewMain.CollapseAll();

			treeViewMain.SelectedNode.BeginEdit();
		}

		#endregion

		#endregion

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Events and Callbacks

		private void MainWindow_Load(object sender, EventArgs e)
		{
			ShowSplashDialog();
		}

		#region Button clicks

		#region Add new form buttons

		#region Normal (large) tab control buttons

		private void buttonAddNewSong_Click(object sender, EventArgs e)
		{
			CreateTreeNodeSong();
		}

		private void buttonAddNewSequence_Click(object sender, EventArgs e)
		{
			CreateTreeNodeSection();
		}

		private void buttonAddNewPhrase_Click(object sender, EventArgs e)
		{
			CreateTreeNodePhrase();
		}

		private void buttonAddNewMeasure_Click(object sender, EventArgs e)
		{
			CreateTreeNodeMeasure();
		}

		private void buttonAddNewMotif_Click(object sender, EventArgs e)
		{
			CreateTreeNodeMotif();
		}

		private void buttonAddNewCell_Click(object sender, EventArgs e)
		{
			CreateTreeNodeCell();
		}

		#endregion

		#region Mini tab button

		void SongTabNew_Click(object sender, EventArgs e)
		{
			buttonAddNewSong_Click(this, e);
		}

		void SequenceTabNew_Click(object sender, EventArgs e)
		{
			buttonAddNewSequence_Click(this, e);
		}

		void PhraseTabNew_Click(object sender, EventArgs e)
		{
			buttonAddNewPhrase_Click(this, e);
		}

		void MeasureTabNew_Click(object sender, EventArgs e)
		{
			buttonAddNewMeasure_Click(this, e);
		}

		void MotifTabNew_Click(object sender, EventArgs e)
		{
			buttonAddNewMotif_Click(this, e);
		}

		void CellTabNew_Click(object sender, EventArgs e)
		{
			buttonAddNewCell_Click(this, e);
		}

		#endregion

		#endregion

		#endregion

		#region Menu Events

		private void changeMIDIInToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowInstrumentChooser();
		}

		private void layoutViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.MainMusicWindow.CurrentViewMode = MusicStructureViewer.ViewMode.WebMap;
		}

		private void outlineViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.MainMusicWindow.CurrentViewMode = MusicStructureViewer.ViewMode.Outline;
		}

		private void staffViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.MainMusicWindow.CurrentViewMode = MusicStructureViewer.ViewMode.Staff;
		}

		private void flowChartViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.MainMusicWindow.CurrentViewMode = MusicStructureViewer.ViewMode.FlowChart;
		}

		private void objectPropertiesWindowToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			tabControlMainProperties.Visible = tabControlMainProperties.Enabled = !tabControlMainProperties.Enabled;
		}

		private void miniOutlineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			treeViewMain.Visible = treeViewMain.Enabled = !treeViewMain.Enabled;
		}

		private void outputWindowToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			treeListViewMessageLog.Visible = treeListViewMessageLog.Enabled = !treeListViewMessageLog.Enabled;
		}

		private void pianoWindowToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			this.PianoWindowVisible = !this.PianoWindowVisible;
		}
		
		private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();

			try
			{
				dlg.CheckPathExists = true;
				dlg.DefaultExt = "dna";
				dlg.FileName = currentPiece.SMSName;
				dlg.Filter = "BioMusic Files (*.dna)|*.dna|All files (*.*)|*.*";
				dlg.InitialDirectory = "C:\\Users\\Garrett\\BioMusic\\Projects\\Project Name\\";
				dlg.OverwritePrompt = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					currentPiece.SaveToFile(dlg.FileName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowHelpBasicInstructions();
		}

		private void releaseNotesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowHelpReleaseNotes();
		}

		#endregion

		#region Tool window events

		#region Logger callback

		private void eventLogMain_EntryWritten(object sender, EntryWrittenEventArgs e)
		{
			RebuildTreeListViewLog(true);

			//treeListViewMessageLog.ExpandAll();

			//If the last item (before we added this new one) is selected,
			//"stick" to the bottom of the log and auto-scroll
			//if (treeListViewMessageLog.SelectedIndex == treeListViewMessageLog.Items.Count - 2)
				treeListViewMessageLog.SelectedIndex = treeListViewMessageLog.Items.Count - 1;
			treeListViewMessageLog.FocusedItem = treeListViewMessageLog.SelectedItem;
		}

		#endregion

		#region Tab window events

		private void tabControlMainProperties_DrawItem(object sender, DrawItemEventArgs e)
		{
			//TabControl parent = sender as TabControl;
			//Graphics g = e.Graphics;

			//if (e.State == DrawItemState.Selected)
			//{
			//    e.DrawBackground();
			//    g.DrawString(parent.TabPages[e.Index].Text, e.Font, Brushes.Blue,
				
			//}
			//else
			//{
			//}
		}

		#endregion

		#region Main Tree events

		private void treeViewMain_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Node.Parent != null)
				e.Node.Name = e.Node.Parent.FullPath + e.Node.TreeView.PathSeparator + e.Label;
			else
			{
				if (e.Label == null)
					e.Node.Name = e.Node.Text;
				else
					e.Node.Name = e.Label;
			}
		}

		protected void DeleteSelectedTreeNode()
		{
#if !DEBUG
			if (MessageBox.Show(this,
						"Are you sure you want to delete this object?\nThis will delete all of its child objects too.\n\nThis is irreversible!",
						"Are you sure?", MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
#endif
				DeleteNodeAndItem();
#if !DEBUG
			}
#endif
		}

		private void DeleteNodeAndItem()
		{
			string nodePath = treeViewMain.SelectedNode.FullPath;
						
			((MusicFormBase)treeViewMain.SelectedNode.Tag).Destroy();
			
			//TODO: Remove item from project
			//projectSongs.Remove(nodePath);
			
			treeViewMain.SelectedNode.Remove();

			Logger.LogSuccess("Successfully deleted " + nodePath + "!", Logger.CategoryName.Cleanup);
		}

		protected void PlaySelectedTreeNode()
		{
			if (currentPiece != null && currentPiece.Playing == true)
			{
				//if (threadSongPlayer.IsBusy)
				{
					currentPiece.Playing = false;
				}
				//else
				//	throw new ApplicationException("Not sure why the current piece would be playing but the thread isn't running!");
			}

			currentPiece = (MusicFormBase)this.treeViewMain.SelectedNode.Tag;

			//while (threadSongPlayer.IsBusy) threadSongPlayer.CancelAsync();

			threadSongPlayer.RunWorkerAsync();
		}

		private void treeViewMain_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
				DeleteSelectedTreeNode();
		}

		private void contextMenuSongStructures_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Text == "&Play")
				PlaySelectedTreeNode();
		}

		private void menuRenameItem_Click(object sender, EventArgs e)
		{
			treeViewMain.SelectedNode.BeginEdit();
		}

		private void menuItemStop_Click(object sender, EventArgs e)
		{
			if (currentPiece != null)
				currentPiece.Playing = false;//.SendMessage(this, new FSMMessage(FSMMessageID.Stop));
		}
		
		
		#endregion

		private void threadSongPlayer_DoWork(object sender, DoWorkEventArgs e)
		{
			Logger.LogMessage("Now playing " + currentPiece.Path + "...", Logger.CategoryName.Playback);

			currentPiece.Play();

			while (currentPiece.Playing)
			{
				if (threadSongPlayer.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
					currentPiece.SMS_Update(null);
			}

			if (threadSongPlayer.CancellationPending)
				Logger.LogWarning("Playback stopped.", Logger.CategoryName.Playback);
			else
				Logger.LogSuccess("Done playing " + currentPiece.Path + "!", Logger.CategoryName.Playback);
		}

		#endregion			

		#region Color Extras (Need to make external)

		//Color InvertColor(Color color)
		//{
		//    return Color.FromArgb(Byte.MaxValue - color.R,
		//      Byte.MaxValue - color.G, Byte.MaxValue - color.B);
		//}

		public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
		{
			int max = Math.Max(color.R, Math.Max(color.G, color.B));
			int min = Math.Min(color.R, Math.Min(color.G, color.B));

			hue = color.GetHue();
			saturation = (max == 0) ? 0 : 1d - (1d * min / max);
			value = max / 255d;
		}

		public static Color ColorFromHSV(double hue, double saturation, double value)
		{
			int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
			double f = hue / 60 - Math.Floor(hue / 60);

			value = value * 255;
			int v = Convert.ToInt32(value);
			int p = Convert.ToInt32(value * (1 - saturation));
			int q = Convert.ToInt32(value * (1 - f * saturation));
			int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

			if (hi == 0)
				return Color.FromArgb(255, v, t, p);
			else if (hi == 1)
				return Color.FromArgb(255, q, v, p);
			else if (hi == 2)
				return Color.FromArgb(255, p, v, t);
			else if (hi == 3)
				return Color.FromArgb(255, p, q, v);
			else if (hi == 4)
				return Color.FromArgb(255, t, p, v);
			else
				return Color.FromArgb(255, v, p, q);
		}

		#endregion

		#region Song Properties Tab

		private Color GetColorByLetter(char note)
		{
			switch (note)
			{
				case 'A': return ColorTranslator.FromWin32(0x7F7FFF); break;	//Red
				case 'B': return ColorTranslator.FromWin32(0x7FD0FF); break;	//Orange
				case 'C': return ColorTranslator.FromWin32(0x7FFFFF); break;	//Yellow
				case 'D': return ColorTranslator.FromWin32(0x7FFF7F); break;	//Green
				case 'E': return ColorTranslator.FromWin32(0xFF7F7F); break;	//Blue
				case 'F': return ColorTranslator.FromWin32(0xCC3299); break;	//Indigo
				case 'G': return ColorTranslator.FromWin32(0xEE82EE); break;	//Violet

				default: throw new ApplicationException("Shouldn't be here!");
			}
		}

		private void songScaleTonic_DrawItem(object sender, DrawItemEventArgs e)
		{
			Color bgColor = Color.White;
			string text = (string)this.songScaleTonic.Items[e.Index];
			char note = text[0];

			if (text.Contains("b") || text.Contains("#"))
			{
				Color first = GetColorByLetter(note),
					second = GetColorByLetter(note < 'G' ? (char)(note + 1) : 'A');
				int r, g, b;
				r = first.R + second.R;
				g = first.G + second.G;
				b = first.B + second.B;
				r /= 2;
				g /= 2;
				b /= 2;
				bgColor = Color.FromArgb(r, g, b);
			}
			else
				bgColor = GetColorByLetter(note);
			
			//Not sure if needed, help included it even though they drew a filled rect
			e.DrawBackground();

			e.Graphics.FillRectangle(new SolidBrush(bgColor), e.Bounds);

			e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);

			e.DrawFocusRectangle();
		}

		#region Combobox stuff

		private void comboBoxSongSmallestNote_SelectedIndexChanged(object sender, EventArgs e)
		{
			VerifyNoteLengths(false);
		}

		private void VerifyNoteLengths(bool bResetLonger)
		{
			NoteLength shortest = (NoteLength)(1 << comboBoxSongSmallestNote.SelectedIndex),
						longest = (NoteLength)(1 << comboBoxSongLongestNote.SelectedIndex);

			if (shortest < longest) //Confusing I know: whole=1, quarter=4
			{
				string message = "Shortest note cannot be longer than the longest.";
				Logger.LogWarning(message, Logger.CategoryName.FormControl);
#if !DEBUG
				MessageBox.Show(message);
#endif

				if (bResetLonger)
					comboBoxSongLongestNote.SelectedIndex = comboBoxSongSmallestNote.SelectedIndex;
				else
					comboBoxSongSmallestNote.SelectedIndex = comboBoxSongLongestNote.SelectedIndex;
			}
		}

		private void comboBoxSongLongestNote_SelectedIndexChanged(object sender, EventArgs e)
		{
			VerifyNoteLengths(true);
		}

		private void comboBoxSongScales_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckScaleOctaveCompatability();
		}

		private void CheckScaleOctaveCompatability()
		{
			string modeName = (string)((Midi.ScalePattern)this.songScalePattern.SelectedItem).Name;
			string tonicName = (string)this.songScaleTonic.SelectedItem;

			if (this.comboBoxRootOctave.SelectedIndex == (int)COctave.C0)
			{
				//If the scale doesn't have A (or A#, but isn't Ab) or B (or Bb) as it's tonic
				if ((!tonicName.Contains("A") && !tonicName.Contains("B"))
					|| tonicName.Contains("Ab"))
				{
					string message = "Current scale (" + tonicName + " " + modeName + ") doesn't support octave C0! Setting to C1";
					Logger.LogWarning(message, Logger.CategoryName.FormControl);
#if !DEBUG
					MessageBox.Show(message);
#endif
					this.comboBoxRootOctave.SelectedIndex = (int)COctave.C1;
				}
			}
			else if (!(tonicName.Contains("C") && modeName.Contains("Major"))
						 && this.comboBoxRootOctave.SelectedIndex == (int)COctave.C7)
			{
				string message = "Only C Major can be in the octave C7, changing root octave to C6";
				Logger.LogWarning(message, Logger.CategoryName.FormControl);
#if !DEBUG
				MessageBox.Show(message);
#endif
				this.comboBoxRootOctave.SelectedIndex = (int)COctave.C6;
			}
		}

		private void comboBoxOctaveSpan_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void comboBoxRootOctave_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckScaleOctaveCompatability();
		}

		#endregion

		private void upDownSongTempo_ValueChanged(object sender, EventArgs e)
		{

		}

		#endregion

		#region Help labels

		private void helpLabelChordChance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ShowChordChoiceDialog();
		}

		#endregion

		#region TreeListView logger

		private void treeListViewMessageLog_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
		{
			LoggerMessage msg = (LoggerMessage)e.Model;

			switch (msg.Type)
			{
				case LoggerMessage.MsgType.Error:
					e.Item.ForeColor = Color.Red;
					break;

				case LoggerMessage.MsgType.Fail:
					e.Item.ForeColor = Color.White;
					e.Item.BackColor = Color.Red;
					break;

				case LoggerMessage.MsgType.Information:
					break;

				case LoggerMessage.MsgType.Success:
					e.Item.ForeColor = Color.Green;
					e.Item.BackColor = Color.LightGreen;
					break;

				case LoggerMessage.MsgType.Warning:
					e.Item.ForeColor = Color.Orange;
					e.Item.BackColor = Color.LightBlue;
					break;
			}
		}

		private void treeListViewMessageLog_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
		{
			//switch (e
		}

		#endregion

		#endregion
		
		///////////////////////////////////////////////////////////////////

		#endregion
	}
}
