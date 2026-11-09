namespace BioMusic.Code.Forms
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainerMainLeft = new System.Windows.Forms.SplitContainer();
			this.panelMainViewerFrame = new System.Windows.Forms.Panel();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainWindowViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layoutViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outlineViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.staffViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowChartViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.sheetMusicPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miniOutlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.objectPropertiesWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pianoWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeMIDIInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.treeListViewMessageLog = new BrightIdeasSoftware.TreeListView();
			this.treeListViewColEventID = new BrightIdeasSoftware.OLVColumn();
			this.treeListViewColCategory = new BrightIdeasSoftware.OLVColumn();
			this.treeListViewColType = new BrightIdeasSoftware.OLVColumn();
			this.treeListViewColTime = new BrightIdeasSoftware.OLVColumn();
			this.treeListViewColMsg = new BrightIdeasSoftware.OLVColumn();
			this.treeListViewRepository = new BrightIdeasSoftware.TreeListView();
			this.repositoryColName = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColLength = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColChildren = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColSections = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColPhrases = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColMeasures = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColMotifs = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColCells = new BrightIdeasSoftware.OLVColumn();
			this.repositoryColNotes = new BrightIdeasSoftware.OLVColumn();
			this.splitContainerMainRight = new System.Windows.Forms.SplitContainer();
			this.tabControlMainProperties = new System.Windows.Forms.TabControl();
			this.tabPageBuildSong = new System.Windows.Forms.TabPage();
			this.splitContainerSongProps = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelSongProps = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxOctaveSpan = new System.Windows.Forms.ComboBox();
			this.helpLabelSongScale = new System.Windows.Forms.LinkLabel();
			this.helpLabelLength = new System.Windows.Forms.LinkLabel();
			this.labelSongLength = new System.Windows.Forms.Label();
			this.helpLabelRootOctave = new System.Windows.Forms.LinkLabel();
			this.comboBoxRootOctave = new System.Windows.Forms.ComboBox();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.helpLabelSmallestNote = new System.Windows.Forms.LinkLabel();
			this.comboBoxSongSmallestNote = new System.Windows.Forms.ComboBox();
			this.helpLabelTempo = new System.Windows.Forms.LinkLabel();
			this.upDownSongTempo = new System.Windows.Forms.NumericUpDown();
			this.helpLabelSongTimeSign = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.SongTimeSignNumerator = new System.Windows.Forms.ComboBox();
			this.SongTimeSignDenominator = new System.Windows.Forms.ComboBox();
			this.helpLabelLongestNote = new System.Windows.Forms.LinkLabel();
			this.comboBoxSongLongestNote = new System.Windows.Forms.ComboBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.restChance = new System.Windows.Forms.NumericUpDown();
			this.helpLabelNumSections = new System.Windows.Forms.LinkLabel();
			this.songPropertiesNumSections = new System.Windows.Forms.NumericUpDown();
			this.helpLabelNumPhrases = new System.Windows.Forms.LinkLabel();
			this.songPropertiesNumPhrases = new System.Windows.Forms.NumericUpDown();
			this.songPropertiesNumMeasures = new System.Windows.Forms.NumericUpDown();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.songScaleTonic = new System.Windows.Forms.ComboBox();
			this.songScalePattern = new System.Windows.Forms.ComboBox();
			this.helpLabelChordChance = new System.Windows.Forms.LinkLabel();
			this.songPropertiesChordChance = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.maskedTextBox11 = new System.Windows.Forms.MaskedTextBox();
			this.maskedTextBox10 = new System.Windows.Forms.MaskedTextBox();
			this.maskedTextBox01 = new System.Windows.Forms.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.maskedTextBox00 = new System.Windows.Forms.MaskedTextBox();
			this.tabPageBuildSequence = new System.Windows.Forms.TabPage();
			this.buttonAddNewSequence = new System.Windows.Forms.Button();
			this.tabPageBuildPhrase = new System.Windows.Forms.TabPage();
			this.buttonAddNewPhrase = new System.Windows.Forms.Button();
			this.tabPageBuildMeasure = new System.Windows.Forms.TabPage();
			this.buttonAddNewMeasure = new System.Windows.Forms.Button();
			this.tabPageBuildMotif = new System.Windows.Forms.TabPage();
			this.buttonAddNewMotif = new System.Windows.Forms.Button();
			this.tabPageBuildCell = new System.Windows.Forms.TabPage();
			this.buttonAddNewCell = new System.Windows.Forms.Button();
			this.imageListMusicIcons = new System.Windows.Forms.ImageList(this.components);
			this.treeViewMain = new System.Windows.Forms.TreeView();
			this.contextMenuSongStructures = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuPlayItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPlayItemSpecial = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPlayChildren = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemStop = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.menuRenameItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.menuCutItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCopyItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPasteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.menuPropertiesItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageListMusicStructures = new System.Windows.Forms.ImageList(this.components);
			this.threadSongPlayer = new System.ComponentModel.BackgroundWorker();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.treeListView1 = new BrightIdeasSoftware.TreeListView();
			this.columnTrackID = new BrightIdeasSoftware.OLVColumn();
			this.columnTrackName = new BrightIdeasSoftware.OLVColumn();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainerMainLeft.Panel1.SuspendLayout();
			this.splitContainerMainLeft.Panel2.SuspendLayout();
			this.splitContainerMainLeft.SuspendLayout();
			this.panelMainViewerFrame.SuspendLayout();
			this.menuStripMain.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeListViewMessageLog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeListViewRepository)).BeginInit();
			this.splitContainerMainRight.Panel1.SuspendLayout();
			this.splitContainerMainRight.Panel2.SuspendLayout();
			this.splitContainerMainRight.SuspendLayout();
			this.tabControlMainProperties.SuspendLayout();
			this.tabPageBuildSong.SuspendLayout();
			this.splitContainerSongProps.Panel1.SuspendLayout();
			this.splitContainerSongProps.Panel2.SuspendLayout();
			this.splitContainerSongProps.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanelSongProps.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.upDownSongTempo)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.restChance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesNumSections)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesNumPhrases)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesNumMeasures)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesChordChance)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabPageBuildSequence.SuspendLayout();
			this.tabPageBuildPhrase.SuspendLayout();
			this.tabPageBuildMeasure.SuspendLayout();
			this.tabPageBuildMotif.SuspendLayout();
			this.tabPageBuildCell.SuspendLayout();
			this.contextMenuSongStructures.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainerMainLeft);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainerMainRight);
			this.splitContainer1.Size = new System.Drawing.Size(1184, 962);
			this.splitContainer1.SplitterDistance = 846;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainerMainLeft
			// 
			this.splitContainerMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMainLeft.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMainLeft.Name = "splitContainerMainLeft";
			this.splitContainerMainLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMainLeft.Panel1
			// 
			this.splitContainerMainLeft.Panel1.Controls.Add(this.panelMainViewerFrame);
			this.splitContainerMainLeft.Panel1.Controls.Add(this.menuStripMain);
			// 
			// splitContainerMainLeft.Panel2
			// 
			this.splitContainerMainLeft.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainerMainLeft.Size = new System.Drawing.Size(846, 962);
			this.splitContainerMainLeft.SplitterDistance = 726;
			this.splitContainerMainLeft.TabIndex = 0;
			// 
			// panelMainViewerFrame
			// 
			this.panelMainViewerFrame.Controls.Add(this.splitContainer3);
			this.panelMainViewerFrame.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMainViewerFrame.Enabled = false;
			this.panelMainViewerFrame.Location = new System.Drawing.Point(0, 24);
			this.panelMainViewerFrame.Name = "panelMainViewerFrame";
			this.panelMainViewerFrame.Size = new System.Drawing.Size(846, 702);
			this.panelMainViewerFrame.TabIndex = 1;
			this.panelMainViewerFrame.Visible = false;
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(846, 24);
			this.menuStripMain.TabIndex = 0;
			this.menuStripMain.Text = "Main Menu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.printToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.newProjectToolStripMenuItem.Text = "&New Project...";
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.openProjectToolStripMenuItem.Text = "&Open Project...";
			// 
			// saveProjectToolStripMenuItem
			// 
			this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
			this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.saveProjectToolStripMenuItem.Text = "&Save Project";
			this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
			// 
			// saveProjectAsToolStripMenuItem
			// 
			this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
			this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.saveProjectAsToolStripMenuItem.Text = "Save Project &As...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.importToolStripMenuItem.Text = "&Import...";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.exportToolStripMenuItem.Text = "&Export...";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.printToolStripMenuItem.Text = "&Print...";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator5,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator6,
            this.findToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(119, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.findToolStripMenuItem.Text = "&Find...";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainWindowViewToolStripMenuItem,
            this.toolStripSeparator7,
            this.sheetMusicPreviewToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolWindowsToolStripMenuItem,
            this.changeMIDIInToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// mainWindowViewToolStripMenuItem
			// 
			this.mainWindowViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layoutViewToolStripMenuItem,
            this.outlineViewToolStripMenuItem,
            this.staffViewToolStripMenuItem,
            this.flowChartViewToolStripMenuItem});
			this.mainWindowViewToolStripMenuItem.Name = "mainWindowViewToolStripMenuItem";
			this.mainWindowViewToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.mainWindowViewToolStripMenuItem.Text = "Main Window &View";
			// 
			// layoutViewToolStripMenuItem
			// 
			this.layoutViewToolStripMenuItem.Name = "layoutViewToolStripMenuItem";
			this.layoutViewToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.layoutViewToolStripMenuItem.Text = "&Layout View";
			this.layoutViewToolStripMenuItem.Click += new System.EventHandler(this.layoutViewToolStripMenuItem_Click);
			// 
			// outlineViewToolStripMenuItem
			// 
			this.outlineViewToolStripMenuItem.Name = "outlineViewToolStripMenuItem";
			this.outlineViewToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.outlineViewToolStripMenuItem.Text = "&Outline View";
			this.outlineViewToolStripMenuItem.Click += new System.EventHandler(this.outlineViewToolStripMenuItem_Click);
			// 
			// staffViewToolStripMenuItem
			// 
			this.staffViewToolStripMenuItem.Name = "staffViewToolStripMenuItem";
			this.staffViewToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.staffViewToolStripMenuItem.Text = "&Staff View";
			this.staffViewToolStripMenuItem.Click += new System.EventHandler(this.staffViewToolStripMenuItem_Click);
			// 
			// flowChartViewToolStripMenuItem
			// 
			this.flowChartViewToolStripMenuItem.Name = "flowChartViewToolStripMenuItem";
			this.flowChartViewToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.flowChartViewToolStripMenuItem.Text = "&Flow Chart View";
			this.flowChartViewToolStripMenuItem.Click += new System.EventHandler(this.flowChartViewToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(210, 6);
			// 
			// sheetMusicPreviewToolStripMenuItem
			// 
			this.sheetMusicPreviewToolStripMenuItem.Name = "sheetMusicPreviewToolStripMenuItem";
			this.sheetMusicPreviewToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.sheetMusicPreviewToolStripMenuItem.Text = "&Sheet Music Preview...";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(210, 6);
			// 
			// toolWindowsToolStripMenuItem
			// 
			this.toolWindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputWindowToolStripMenuItem,
            this.miniOutlineToolStripMenuItem,
            this.objectPropertiesWindowToolStripMenuItem,
            this.pianoWindowToolStripMenuItem});
			this.toolWindowsToolStripMenuItem.Name = "toolWindowsToolStripMenuItem";
			this.toolWindowsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.toolWindowsToolStripMenuItem.Text = "&Tool Windows";
			// 
			// outputWindowToolStripMenuItem
			// 
			this.outputWindowToolStripMenuItem.Checked = true;
			this.outputWindowToolStripMenuItem.CheckOnClick = true;
			this.outputWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.outputWindowToolStripMenuItem.Name = "outputWindowToolStripMenuItem";
			this.outputWindowToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.outputWindowToolStripMenuItem.Text = "&Output Window";
			this.outputWindowToolStripMenuItem.CheckedChanged += new System.EventHandler(this.outputWindowToolStripMenuItem_CheckedChanged);
			// 
			// miniOutlineToolStripMenuItem
			// 
			this.miniOutlineToolStripMenuItem.Checked = true;
			this.miniOutlineToolStripMenuItem.CheckOnClick = true;
			this.miniOutlineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miniOutlineToolStripMenuItem.Name = "miniOutlineToolStripMenuItem";
			this.miniOutlineToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.miniOutlineToolStripMenuItem.Text = "&Mini-Outline Window";
			this.miniOutlineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.miniOutlineToolStripMenuItem_CheckedChanged);
			// 
			// objectPropertiesWindowToolStripMenuItem
			// 
			this.objectPropertiesWindowToolStripMenuItem.Checked = true;
			this.objectPropertiesWindowToolStripMenuItem.CheckOnClick = true;
			this.objectPropertiesWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.objectPropertiesWindowToolStripMenuItem.Name = "objectPropertiesWindowToolStripMenuItem";
			this.objectPropertiesWindowToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.objectPropertiesWindowToolStripMenuItem.Text = "Object P&roperties Window";
			this.objectPropertiesWindowToolStripMenuItem.CheckedChanged += new System.EventHandler(this.objectPropertiesWindowToolStripMenuItem_CheckedChanged);
			// 
			// pianoWindowToolStripMenuItem
			// 
			this.pianoWindowToolStripMenuItem.Checked = true;
			this.pianoWindowToolStripMenuItem.CheckOnClick = true;
			this.pianoWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.pianoWindowToolStripMenuItem.Name = "pianoWindowToolStripMenuItem";
			this.pianoWindowToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.pianoWindowToolStripMenuItem.Text = "&Piano Window";
			this.pianoWindowToolStripMenuItem.CheckedChanged += new System.EventHandler(this.pianoWindowToolStripMenuItem_CheckedChanged);
			// 
			// changeMIDIInToolStripMenuItem
			// 
			this.changeMIDIInToolStripMenuItem.Name = "changeMIDIInToolStripMenuItem";
			this.changeMIDIInToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.changeMIDIInToolStripMenuItem.Text = "Change MIDI Instrument...";
			this.changeMIDIInToolStripMenuItem.Click += new System.EventHandler(this.changeMIDIInToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.releaseNotesToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// instructionsToolStripMenuItem
			// 
			this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
			this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.instructionsToolStripMenuItem.Text = "&Instructions...";
			this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
			// 
			// releaseNotesToolStripMenuItem
			// 
			this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
			this.releaseNotesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.releaseNotesToolStripMenuItem.Text = "&Release Notes...";
			this.releaseNotesToolStripMenuItem.Click += new System.EventHandler(this.releaseNotesToolStripMenuItem_Click);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.treeListViewMessageLog);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.treeListViewRepository);
			this.splitContainer2.Size = new System.Drawing.Size(846, 232);
			this.splitContainer2.SplitterDistance = 443;
			this.splitContainer2.TabIndex = 1;
			// 
			// treeListViewMessageLog
			// 
			this.treeListViewMessageLog.AllColumns.Add(this.treeListViewColEventID);
			this.treeListViewMessageLog.AllColumns.Add(this.treeListViewColCategory);
			this.treeListViewMessageLog.AllColumns.Add(this.treeListViewColType);
			this.treeListViewMessageLog.AllColumns.Add(this.treeListViewColTime);
			this.treeListViewMessageLog.AllColumns.Add(this.treeListViewColMsg);
			this.treeListViewMessageLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.treeListViewColEventID,
            this.treeListViewColCategory,
            this.treeListViewColType,
            this.treeListViewColTime,
            this.treeListViewColMsg});
			this.treeListViewMessageLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeListViewMessageLog.FullRowSelect = true;
			this.treeListViewMessageLog.GridLines = true;
			this.treeListViewMessageLog.Location = new System.Drawing.Point(0, 0);
			this.treeListViewMessageLog.MultiSelect = false;
			this.treeListViewMessageLog.Name = "treeListViewMessageLog";
			this.treeListViewMessageLog.OwnerDraw = true;
			this.treeListViewMessageLog.RevealAfterExpand = false;
			this.treeListViewMessageLog.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.treeListViewMessageLog.ShowGroups = false;
			this.treeListViewMessageLog.ShowItemCountOnGroups = true;
			this.treeListViewMessageLog.ShowItemToolTips = true;
			this.treeListViewMessageLog.Size = new System.Drawing.Size(443, 232);
			this.treeListViewMessageLog.TabIndex = 0;
			this.treeListViewMessageLog.UseCompatibleStateImageBehavior = false;
			this.treeListViewMessageLog.View = System.Windows.Forms.View.Details;
			this.treeListViewMessageLog.VirtualMode = true;
			this.treeListViewMessageLog.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.treeListViewMessageLog_FormatCell);
			this.treeListViewMessageLog.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListViewMessageLog_FormatRow);
			// 
			// treeListViewColEventID
			// 
			this.treeListViewColEventID.AspectName = "EventID";
			this.treeListViewColEventID.IsEditable = false;
			this.treeListViewColEventID.MinimumWidth = 5;
			this.treeListViewColEventID.Text = "EventID";
			this.treeListViewColEventID.ToolTipText = "The ID number associated with the event.";
			this.treeListViewColEventID.Width = 80;
			// 
			// treeListViewColCategory
			// 
			this.treeListViewColCategory.AspectName = "CategoryName";
			this.treeListViewColCategory.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.treeListViewColCategory.IsEditable = false;
			this.treeListViewColCategory.MaximumWidth = 150;
			this.treeListViewColCategory.MinimumWidth = 10;
			this.treeListViewColCategory.Text = "Category";
			this.treeListViewColCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.treeListViewColCategory.ToolTipText = "The category of the event.";
			this.treeListViewColCategory.Width = 65;
			// 
			// treeListViewColType
			// 
			this.treeListViewColType.AspectName = "Type";
			this.treeListViewColType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.treeListViewColType.IsEditable = false;
			this.treeListViewColType.MaximumWidth = 150;
			this.treeListViewColType.MinimumWidth = 5;
			this.treeListViewColType.Text = "Type";
			this.treeListViewColType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.treeListViewColType.ToolTipText = "The type of event (info, warning, error, success, fail).";
			this.treeListViewColType.Width = 65;
			// 
			// treeListViewColTime
			// 
			this.treeListViewColTime.AspectName = "TimeStamp";
			this.treeListViewColTime.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.treeListViewColTime.IsEditable = false;
			this.treeListViewColTime.MaximumWidth = 200;
			this.treeListViewColTime.MinimumWidth = 5;
			this.treeListViewColTime.Text = "Timestamp";
			this.treeListViewColTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.treeListViewColTime.ToolTipText = "The date and time the event occurred.";
			this.treeListViewColTime.Width = 130;
			// 
			// treeListViewColMsg
			// 
			this.treeListViewColMsg.AspectName = "Text";
			this.treeListViewColMsg.IsEditable = false;
			this.treeListViewColMsg.MinimumWidth = 5;
			this.treeListViewColMsg.Text = "Message";
			this.treeListViewColMsg.ToolTipText = "A description of the event.";
			this.treeListViewColMsg.Width = 550;
			// 
			// treeListViewRepository
			// 
			this.treeListViewRepository.AllColumns.Add(this.repositoryColName);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColLength);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColChildren);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColSections);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColPhrases);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColMeasures);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColMotifs);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColCells);
			this.treeListViewRepository.AllColumns.Add(this.repositoryColNotes);
			this.treeListViewRepository.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.repositoryColName,
            this.repositoryColLength,
            this.repositoryColChildren,
            this.repositoryColSections,
            this.repositoryColPhrases,
            this.repositoryColMeasures,
            this.repositoryColMotifs,
            this.repositoryColCells,
            this.repositoryColNotes});
			this.treeListViewRepository.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeListViewRepository.Location = new System.Drawing.Point(0, 0);
			this.treeListViewRepository.Name = "treeListViewRepository";
			this.treeListViewRepository.OwnerDraw = true;
			this.treeListViewRepository.ShowGroups = false;
			this.treeListViewRepository.Size = new System.Drawing.Size(399, 232);
			this.treeListViewRepository.TabIndex = 0;
			this.treeListViewRepository.UseCompatibleStateImageBehavior = false;
			this.treeListViewRepository.View = System.Windows.Forms.View.Details;
			this.treeListViewRepository.VirtualMode = true;
			// 
			// repositoryColName
			// 
			this.repositoryColName.AspectName = "Value.Name";
			this.repositoryColName.CheckBoxes = true;
			this.repositoryColName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColName.Text = "Name";
			this.repositoryColName.ToolTipText = "Name of the music form";
			this.repositoryColName.TriStateCheckBoxes = true;
			this.repositoryColName.Width = 100;
			// 
			// repositoryColLength
			// 
			this.repositoryColLength.AspectName = "Value.Length";
			this.repositoryColLength.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColLength.IsEditable = false;
			this.repositoryColLength.Text = "Length";
			this.repositoryColLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColLength.ToolTipText = "The play length of the form.";
			// 
			// repositoryColChildren
			// 
			this.repositoryColChildren.AspectName = "Value.NumParts";
			this.repositoryColChildren.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColChildren.IsEditable = false;
			this.repositoryColChildren.Text = "Children";
			this.repositoryColChildren.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColChildren.ToolTipText = "The number of child forms (not including \"grandchildren\" or beyond).";
			this.repositoryColChildren.Width = 50;
			// 
			// repositoryColSections
			// 
			this.repositoryColSections.AspectName = "Value.NumSections";
			this.repositoryColSections.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColSections.IsEditable = false;
			this.repositoryColSections.Text = "Sections";
			this.repositoryColSections.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColSections.ToolTipText = "The total number of sections contained within the song (0 for everything else).";
			this.repositoryColSections.Width = 53;
			// 
			// repositoryColPhrases
			// 
			this.repositoryColPhrases.AspectName = "Value.NumPhrases";
			this.repositoryColPhrases.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColPhrases.IsEditable = false;
			this.repositoryColPhrases.Text = "Phrases";
			this.repositoryColPhrases.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColPhrases.ToolTipText = "The total number of phrases contained within the form.";
			this.repositoryColPhrases.Width = 50;
			// 
			// repositoryColMeasures
			// 
			this.repositoryColMeasures.AspectName = "Value.NumMeasures";
			this.repositoryColMeasures.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColMeasures.IsEditable = false;
			this.repositoryColMeasures.Text = "Measures";
			this.repositoryColMeasures.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColMeasures.ToolTipText = "The total number of measures within the form.";
			this.repositoryColMeasures.Width = 58;
			// 
			// repositoryColMotifs
			// 
			this.repositoryColMotifs.AspectName = "Value.NumMotifs";
			this.repositoryColMotifs.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColMotifs.IsEditable = false;
			this.repositoryColMotifs.Text = "Motifs";
			this.repositoryColMotifs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColMotifs.ToolTipText = "The total number of motifs within the form.";
			this.repositoryColMotifs.Width = 50;
			// 
			// repositoryColCells
			// 
			this.repositoryColCells.AspectName = "Value.NumCells";
			this.repositoryColCells.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColCells.IsEditable = false;
			this.repositoryColCells.Text = "Cells";
			this.repositoryColCells.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColCells.ToolTipText = "The total number of cells within the form.";
			this.repositoryColCells.Width = 50;
			// 
			// repositoryColNotes
			// 
			this.repositoryColNotes.AspectName = "Value.NumNotes";
			this.repositoryColNotes.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColNotes.IsEditable = false;
			this.repositoryColNotes.Text = "Notes";
			this.repositoryColNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.repositoryColNotes.ToolTipText = "The total number of notes in the form.";
			this.repositoryColNotes.Width = 50;
			// 
			// splitContainerMainRight
			// 
			this.splitContainerMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMainRight.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMainRight.Name = "splitContainerMainRight";
			this.splitContainerMainRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMainRight.Panel1
			// 
			this.splitContainerMainRight.Panel1.Controls.Add(this.tabControlMainProperties);
			// 
			// splitContainerMainRight.Panel2
			// 
			this.splitContainerMainRight.Panel2.Controls.Add(this.treeViewMain);
			this.splitContainerMainRight.Size = new System.Drawing.Size(334, 962);
			this.splitContainerMainRight.SplitterDistance = 590;
			this.splitContainerMainRight.TabIndex = 0;
			// 
			// tabControlMainProperties
			// 
			this.tabControlMainProperties.Controls.Add(this.tabPageBuildSong);
			this.tabControlMainProperties.Controls.Add(this.tabPageBuildSequence);
			this.tabControlMainProperties.Controls.Add(this.tabPageBuildPhrase);
			this.tabControlMainProperties.Controls.Add(this.tabPageBuildMeasure);
			this.tabControlMainProperties.Controls.Add(this.tabPageBuildMotif);
			this.tabControlMainProperties.Controls.Add(this.tabPageBuildCell);
			this.tabControlMainProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMainProperties.ImageList = this.imageListMusicIcons;
			this.tabControlMainProperties.Location = new System.Drawing.Point(0, 0);
			this.tabControlMainProperties.Name = "tabControlMainProperties";
			this.tabControlMainProperties.SelectedIndex = 0;
			this.tabControlMainProperties.Size = new System.Drawing.Size(334, 590);
			this.tabControlMainProperties.TabIndex = 0;
			this.tabControlMainProperties.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMainProperties_DrawItem);
			// 
			// tabPageBuildSong
			// 
			this.tabPageBuildSong.Controls.Add(this.splitContainerSongProps);
			this.tabPageBuildSong.ImageIndex = 13;
			this.tabPageBuildSong.Location = new System.Drawing.Point(4, 23);
			this.tabPageBuildSong.Name = "tabPageBuildSong";
			this.tabPageBuildSong.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBuildSong.Size = new System.Drawing.Size(326, 563);
			this.tabPageBuildSong.TabIndex = 0;
			this.tabPageBuildSong.Text = "Song";
			this.tabPageBuildSong.UseVisualStyleBackColor = true;
			// 
			// splitContainerSongProps
			// 
			this.splitContainerSongProps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSongProps.Location = new System.Drawing.Point(3, 3);
			this.splitContainerSongProps.Name = "splitContainerSongProps";
			this.splitContainerSongProps.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerSongProps.Panel1
			// 
			this.splitContainerSongProps.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainerSongProps.Panel2
			// 
			this.splitContainerSongProps.Panel2.Controls.Add(this.groupBox2);
			this.splitContainerSongProps.Size = new System.Drawing.Size(320, 557);
			this.splitContainerSongProps.SplitterDistance = 436;
			this.splitContainerSongProps.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanelSongProps);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 436);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Song Properties";
			// 
			// tableLayoutPanelSongProps
			// 
			this.tableLayoutPanelSongProps.ColumnCount = 2;
			this.tableLayoutPanelSongProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSongProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSongProps.Controls.Add(this.comboBoxOctaveSpan, 1, 3);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelSongScale, 0, 1);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelLength, 0, 0);
			this.tableLayoutPanelSongProps.Controls.Add(this.labelSongLength, 1, 0);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelRootOctave, 0, 2);
			this.tableLayoutPanelSongProps.Controls.Add(this.comboBoxRootOctave, 1, 2);
			this.tableLayoutPanelSongProps.Controls.Add(this.linkLabel2, 0, 3);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelSmallestNote, 0, 4);
			this.tableLayoutPanelSongProps.Controls.Add(this.comboBoxSongSmallestNote, 1, 4);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelTempo, 0, 6);
			this.tableLayoutPanelSongProps.Controls.Add(this.upDownSongTempo, 1, 6);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelSongTimeSign, 0, 7);
			this.tableLayoutPanelSongProps.Controls.Add(this.tableLayoutPanel2, 1, 7);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelLongestNote, 0, 5);
			this.tableLayoutPanelSongProps.Controls.Add(this.comboBoxSongLongestNote, 1, 5);
			this.tableLayoutPanelSongProps.Controls.Add(this.linkLabel1, 0, 8);
			this.tableLayoutPanelSongProps.Controls.Add(this.restChance, 1, 8);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelNumSections, 0, 10);
			this.tableLayoutPanelSongProps.Controls.Add(this.songPropertiesNumSections, 1, 10);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelNumPhrases, 0, 11);
			this.tableLayoutPanelSongProps.Controls.Add(this.songPropertiesNumPhrases, 1, 11);
			this.tableLayoutPanelSongProps.Controls.Add(this.songPropertiesNumMeasures, 1, 12);
			this.tableLayoutPanelSongProps.Controls.Add(this.linkLabel3, 0, 12);
			this.tableLayoutPanelSongProps.Controls.Add(this.tableLayoutPanel3, 1, 1);
			this.tableLayoutPanelSongProps.Controls.Add(this.helpLabelChordChance, 0, 9);
			this.tableLayoutPanelSongProps.Controls.Add(this.songPropertiesChordChance, 1, 9);
			this.tableLayoutPanelSongProps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelSongProps.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanelSongProps.Name = "tableLayoutPanelSongProps";
			this.tableLayoutPanelSongProps.RowCount = 14;
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSongProps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.tableLayoutPanelSongProps.Size = new System.Drawing.Size(314, 417);
			this.tableLayoutPanelSongProps.TabIndex = 1;
			// 
			// comboBoxOctaveSpan
			// 
			this.comboBoxOctaveSpan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxOctaveSpan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxOctaveSpan.Enabled = false;
			this.comboBoxOctaveSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxOctaveSpan.FormattingEnabled = true;
			this.comboBoxOctaveSpan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "Full"});
			this.comboBoxOctaveSpan.Location = new System.Drawing.Point(117, 92);
			this.comboBoxOctaveSpan.Name = "comboBoxOctaveSpan";
			this.comboBoxOctaveSpan.Size = new System.Drawing.Size(194, 21);
			this.comboBoxOctaveSpan.TabIndex = 7;
			this.comboBoxOctaveSpan.SelectedIndexChanged += new System.EventHandler(this.comboBoxOctaveSpan_SelectedIndexChanged);
			// 
			// helpLabelSongScale
			// 
			this.helpLabelSongScale.AutoEllipsis = true;
			this.helpLabelSongScale.AutoSize = true;
			this.helpLabelSongScale.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelSongScale.Location = new System.Drawing.Point(3, 32);
			this.helpLabelSongScale.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.helpLabelSongScale.Name = "helpLabelSongScale";
			this.helpLabelSongScale.Size = new System.Drawing.Size(108, 25);
			this.helpLabelSongScale.TabIndex = 1;
			this.helpLabelSongScale.TabStop = true;
			this.helpLabelSongScale.Text = "Scale";
			this.helpLabelSongScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// helpLabelLength
			// 
			this.helpLabelLength.AutoSize = true;
			this.helpLabelLength.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelLength.LinkArea = new System.Windows.Forms.LinkArea(8, 7);
			this.helpLabelLength.Location = new System.Drawing.Point(3, 5);
			this.helpLabelLength.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.helpLabelLength.Name = "helpLabelLength";
			this.helpLabelLength.Size = new System.Drawing.Size(108, 17);
			this.helpLabelLength.TabIndex = 2;
			this.helpLabelLength.TabStop = true;
			this.helpLabelLength.Text = "Length (seconds)";
			this.helpLabelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.helpLabelLength.UseCompatibleTextRendering = true;
			// 
			// labelSongLength
			// 
			this.labelSongLength.AutoSize = true;
			this.labelSongLength.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelSongLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSongLength.Location = new System.Drawing.Point(117, 5);
			this.labelSongLength.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelSongLength.Name = "labelSongLength";
			this.labelSongLength.Size = new System.Drawing.Size(194, 17);
			this.labelSongLength.TabIndex = 3;
			this.labelSongLength.Text = "00:00:00.000";
			this.labelSongLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// helpLabelRootOctave
			// 
			this.helpLabelRootOctave.AutoSize = true;
			this.helpLabelRootOctave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelRootOctave.Location = new System.Drawing.Point(3, 67);
			this.helpLabelRootOctave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.helpLabelRootOctave.Name = "helpLabelRootOctave";
			this.helpLabelRootOctave.Size = new System.Drawing.Size(108, 17);
			this.helpLabelRootOctave.TabIndex = 4;
			this.helpLabelRootOctave.TabStop = true;
			this.helpLabelRootOctave.Text = "Root Octave";
			this.helpLabelRootOctave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxRootOctave
			// 
			this.comboBoxRootOctave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxRootOctave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRootOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxRootOctave.FormattingEnabled = true;
			this.comboBoxRootOctave.Items.AddRange(new object[] {
            "C 0",
            "C 1",
            "C 2",
            "C 3",
            "C 4",
            "C 5",
            "C 6",
            "C 7"});
			this.comboBoxRootOctave.Location = new System.Drawing.Point(117, 65);
			this.comboBoxRootOctave.Name = "comboBoxRootOctave";
			this.comboBoxRootOctave.Size = new System.Drawing.Size(194, 21);
			this.comboBoxRootOctave.TabIndex = 5;
			this.comboBoxRootOctave.SelectedIndexChanged += new System.EventHandler(this.comboBoxRootOctave_SelectedIndexChanged);
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.linkLabel2.Location = new System.Drawing.Point(3, 94);
			this.linkLabel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(108, 17);
			this.linkLabel2.TabIndex = 6;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Octave Span";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// helpLabelSmallestNote
			// 
			this.helpLabelSmallestNote.AutoSize = true;
			this.helpLabelSmallestNote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelSmallestNote.Location = new System.Drawing.Point(3, 116);
			this.helpLabelSmallestNote.Name = "helpLabelSmallestNote";
			this.helpLabelSmallestNote.Size = new System.Drawing.Size(108, 27);
			this.helpLabelSmallestNote.TabIndex = 8;
			this.helpLabelSmallestNote.TabStop = true;
			this.helpLabelSmallestNote.Text = "Shortest Note";
			this.helpLabelSmallestNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxSongSmallestNote
			// 
			this.comboBoxSongSmallestNote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxSongSmallestNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSongSmallestNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSongSmallestNote.FormattingEnabled = true;
			this.comboBoxSongSmallestNote.Items.AddRange(new object[] {
            "(    1    )   Whole",
            "(  1/2  )    Half",
            "(  1/4  )    Quarter",
            "(  1/8  )    Eighth",
            "( 1/16 )    Sixteenth",
            "( 1/32 )    Thirty-Second",
            "( 1/64 )    Sixty-Fourth"});
			this.comboBoxSongSmallestNote.Location = new System.Drawing.Point(117, 119);
			this.comboBoxSongSmallestNote.Name = "comboBoxSongSmallestNote";
			this.comboBoxSongSmallestNote.Size = new System.Drawing.Size(194, 21);
			this.comboBoxSongSmallestNote.TabIndex = 9;
			this.comboBoxSongSmallestNote.SelectedIndexChanged += new System.EventHandler(this.comboBoxSongSmallestNote_SelectedIndexChanged);
			// 
			// helpLabelTempo
			// 
			this.helpLabelTempo.AutoSize = true;
			this.helpLabelTempo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelTempo.Location = new System.Drawing.Point(3, 170);
			this.helpLabelTempo.Name = "helpLabelTempo";
			this.helpLabelTempo.Size = new System.Drawing.Size(108, 26);
			this.helpLabelTempo.TabIndex = 10;
			this.helpLabelTempo.TabStop = true;
			this.helpLabelTempo.Text = "Tempo";
			this.helpLabelTempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// upDownSongTempo
			// 
			this.upDownSongTempo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.upDownSongTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.upDownSongTempo.Location = new System.Drawing.Point(117, 173);
			this.upDownSongTempo.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
			this.upDownSongTempo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.upDownSongTempo.Name = "upDownSongTempo";
			this.upDownSongTempo.Size = new System.Drawing.Size(194, 20);
			this.upDownSongTempo.TabIndex = 11;
			this.upDownSongTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.upDownSongTempo.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.upDownSongTempo.ValueChanged += new System.EventHandler(this.upDownSongTempo_ValueChanged);
			// 
			// helpLabelSongTimeSign
			// 
			this.helpLabelSongTimeSign.AutoSize = true;
			this.helpLabelSongTimeSign.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelSongTimeSign.Location = new System.Drawing.Point(3, 196);
			this.helpLabelSongTimeSign.Name = "helpLabelSongTimeSign";
			this.helpLabelSongTimeSign.Size = new System.Drawing.Size(108, 33);
			this.helpLabelSongTimeSign.TabIndex = 12;
			this.helpLabelSongTimeSign.TabStop = true;
			this.helpLabelSongTimeSign.Text = "Time Signature";
			this.helpLabelSongTimeSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.SongTimeSignNumerator, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.SongTimeSignDenominator, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(117, 199);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 27);
			this.tableLayoutPanel2.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(87, 0);
			this.label6.Margin = new System.Windows.Forms.Padding(0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 27);
			this.label6.TabIndex = 0;
			this.label6.Text = "/";
			// 
			// SongTimeSignNumerator
			// 
			this.SongTimeSignNumerator.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SongTimeSignNumerator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SongTimeSignNumerator.Enabled = false;
			this.SongTimeSignNumerator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SongTimeSignNumerator.FormattingEnabled = true;
			this.SongTimeSignNumerator.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
			this.SongTimeSignNumerator.Location = new System.Drawing.Point(3, 3);
			this.SongTimeSignNumerator.Name = "SongTimeSignNumerator";
			this.SongTimeSignNumerator.Size = new System.Drawing.Size(81, 21);
			this.SongTimeSignNumerator.TabIndex = 1;
			// 
			// SongTimeSignDenominator
			// 
			this.SongTimeSignDenominator.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SongTimeSignDenominator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SongTimeSignDenominator.Enabled = false;
			this.SongTimeSignDenominator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SongTimeSignDenominator.FormattingEnabled = true;
			this.SongTimeSignDenominator.Items.AddRange(new object[] {
            "2",
            "4",
            "8"});
			this.SongTimeSignDenominator.Location = new System.Drawing.Point(110, 3);
			this.SongTimeSignDenominator.Name = "SongTimeSignDenominator";
			this.SongTimeSignDenominator.Size = new System.Drawing.Size(81, 21);
			this.SongTimeSignDenominator.TabIndex = 2;
			// 
			// helpLabelLongestNote
			// 
			this.helpLabelLongestNote.AutoSize = true;
			this.helpLabelLongestNote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelLongestNote.Location = new System.Drawing.Point(3, 143);
			this.helpLabelLongestNote.Name = "helpLabelLongestNote";
			this.helpLabelLongestNote.Size = new System.Drawing.Size(108, 27);
			this.helpLabelLongestNote.TabIndex = 14;
			this.helpLabelLongestNote.TabStop = true;
			this.helpLabelLongestNote.Text = "Longest Note";
			this.helpLabelLongestNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxSongLongestNote
			// 
			this.comboBoxSongLongestNote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxSongLongestNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSongLongestNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSongLongestNote.FormattingEnabled = true;
			this.comboBoxSongLongestNote.Items.AddRange(new object[] {
            "(    1    )   Whole",
            "(  1/2  )    Half",
            "(  1/4  )    Quarter",
            "(  1/8  )    Eighth",
            "( 1/16 )    Sixteenth",
            "( 1/32 )    Thirty-Second",
            "( 1/64 )    Sixty-Fourth"});
			this.comboBoxSongLongestNote.Location = new System.Drawing.Point(117, 146);
			this.comboBoxSongLongestNote.Name = "comboBoxSongLongestNote";
			this.comboBoxSongLongestNote.Size = new System.Drawing.Size(194, 21);
			this.comboBoxSongLongestNote.TabIndex = 15;
			this.comboBoxSongLongestNote.SelectedIndexChanged += new System.EventHandler(this.comboBoxSongLongestNote_SelectedIndexChanged);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.linkLabel1.Location = new System.Drawing.Point(3, 229);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(108, 26);
			this.linkLabel1.TabIndex = 16;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Rest Note Chance";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// restChance
			// 
			this.restChance.DecimalPlaces = 1;
			this.restChance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.restChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.restChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.restChance.Location = new System.Drawing.Point(117, 232);
			this.restChance.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            65536});
			this.restChance.Name = "restChance";
			this.restChance.Size = new System.Drawing.Size(194, 20);
			this.restChance.TabIndex = 17;
			this.restChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.restChance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// helpLabelNumSections
			// 
			this.helpLabelNumSections.AutoSize = true;
			this.helpLabelNumSections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelNumSections.Location = new System.Drawing.Point(3, 281);
			this.helpLabelNumSections.Name = "helpLabelNumSections";
			this.helpLabelNumSections.Size = new System.Drawing.Size(108, 26);
			this.helpLabelNumSections.TabIndex = 18;
			this.helpLabelNumSections.TabStop = true;
			this.helpLabelNumSections.Text = "Number of Sections";
			this.helpLabelNumSections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// songPropertiesNumSections
			// 
			this.songPropertiesNumSections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.songPropertiesNumSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.songPropertiesNumSections.Location = new System.Drawing.Point(117, 284);
			this.songPropertiesNumSections.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.songPropertiesNumSections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.songPropertiesNumSections.Name = "songPropertiesNumSections";
			this.songPropertiesNumSections.Size = new System.Drawing.Size(194, 20);
			this.songPropertiesNumSections.TabIndex = 19;
			this.songPropertiesNumSections.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.songPropertiesNumSections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// helpLabelNumPhrases
			// 
			this.helpLabelNumPhrases.AutoSize = true;
			this.helpLabelNumPhrases.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelNumPhrases.Location = new System.Drawing.Point(3, 307);
			this.helpLabelNumPhrases.Name = "helpLabelNumPhrases";
			this.helpLabelNumPhrases.Size = new System.Drawing.Size(108, 26);
			this.helpLabelNumPhrases.TabIndex = 20;
			this.helpLabelNumPhrases.TabStop = true;
			this.helpLabelNumPhrases.Text = "Phrases Per Section";
			this.helpLabelNumPhrases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// songPropertiesNumPhrases
			// 
			this.songPropertiesNumPhrases.Dock = System.Windows.Forms.DockStyle.Fill;
			this.songPropertiesNumPhrases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.songPropertiesNumPhrases.Location = new System.Drawing.Point(117, 310);
			this.songPropertiesNumPhrases.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.songPropertiesNumPhrases.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.songPropertiesNumPhrases.Name = "songPropertiesNumPhrases";
			this.songPropertiesNumPhrases.Size = new System.Drawing.Size(194, 20);
			this.songPropertiesNumPhrases.TabIndex = 21;
			this.songPropertiesNumPhrases.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.songPropertiesNumPhrases.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// songPropertiesNumMeasures
			// 
			this.songPropertiesNumMeasures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.songPropertiesNumMeasures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.songPropertiesNumMeasures.Location = new System.Drawing.Point(117, 336);
			this.songPropertiesNumMeasures.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.songPropertiesNumMeasures.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.songPropertiesNumMeasures.Name = "songPropertiesNumMeasures";
			this.songPropertiesNumMeasures.Size = new System.Drawing.Size(194, 20);
			this.songPropertiesNumMeasures.TabIndex = 22;
			this.songPropertiesNumMeasures.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.songPropertiesNumMeasures.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// linkLabel3
			// 
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.linkLabel3.Location = new System.Drawing.Point(3, 333);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(108, 26);
			this.linkLabel3.TabIndex = 23;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Measures Per Phrase";
			this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.songScaleTonic, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.songScalePattern, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(117, 30);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 29);
			this.tableLayoutPanel3.TabIndex = 24;
			// 
			// songScaleTonic
			// 
			this.songScaleTonic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.songScaleTonic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.songScaleTonic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.songScaleTonic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.songScaleTonic.FormattingEnabled = true;
			this.songScaleTonic.Items.AddRange(new object[] {
            "A",
            "A#/Bb",
            "B",
            "C",
            "C#/Db",
            "D",
            "D#/Eb",
            "E",
            "F",
            "F#/Gb",
            "G",
            "G#/Ab"});
			this.songScaleTonic.Location = new System.Drawing.Point(3, 3);
			this.songScaleTonic.MaxDropDownItems = 15;
			this.songScaleTonic.Name = "songScaleTonic";
			this.songScaleTonic.Size = new System.Drawing.Size(71, 21);
			this.songScaleTonic.TabIndex = 0;
			this.songScaleTonic.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.songScaleTonic_DrawItem);
			// 
			// songScalePattern
			// 
			this.songScalePattern.Dock = System.Windows.Forms.DockStyle.Fill;
			this.songScalePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.songScalePattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.songScalePattern.FormattingEnabled = true;
			this.songScalePattern.Location = new System.Drawing.Point(80, 3);
			this.songScalePattern.Name = "songScalePattern";
			this.songScalePattern.Size = new System.Drawing.Size(111, 21);
			this.songScalePattern.TabIndex = 1;
			// 
			// helpLabelChordChance
			// 
			this.helpLabelChordChance.AutoSize = true;
			this.helpLabelChordChance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpLabelChordChance.Location = new System.Drawing.Point(3, 255);
			this.helpLabelChordChance.Name = "helpLabelChordChance";
			this.helpLabelChordChance.Size = new System.Drawing.Size(108, 26);
			this.helpLabelChordChance.TabIndex = 25;
			this.helpLabelChordChance.TabStop = true;
			this.helpLabelChordChance.Text = "Chord Chance";
			this.helpLabelChordChance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.helpLabelChordChance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpLabelChordChance_LinkClicked);
			// 
			// songPropertiesChordChance
			// 
			this.songPropertiesChordChance.DecimalPlaces = 1;
			this.songPropertiesChordChance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.songPropertiesChordChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.songPropertiesChordChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.songPropertiesChordChance.Location = new System.Drawing.Point(117, 258);
			this.songPropertiesChordChance.Name = "songPropertiesChordChance";
			this.songPropertiesChordChance.Size = new System.Drawing.Size(194, 20);
			this.songPropertiesChordChance.TabIndex = 26;
			this.songPropertiesChordChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.songPropertiesChordChance.Value = new decimal(new int[] {
            500,
            0,
            0,
            65536});
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 117);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Section Transitions";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox11, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox10, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox01, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox00, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 98);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// maskedTextBox11
			// 
			this.maskedTextBox11.BeepOnError = true;
			this.maskedTextBox11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maskedTextBox11.Enabled = false;
			this.maskedTextBox11.HideSelection = false;
			this.maskedTextBox11.Location = new System.Drawing.Point(192, 43);
			this.maskedTextBox11.Mask = "#.##%";
			this.maskedTextBox11.Name = "maskedTextBox11";
			this.maskedTextBox11.Size = new System.Drawing.Size(119, 20);
			this.maskedTextBox11.TabIndex = 7;
			this.maskedTextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// maskedTextBox10
			// 
			this.maskedTextBox10.BeepOnError = true;
			this.maskedTextBox10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maskedTextBox10.Enabled = false;
			this.maskedTextBox10.HideSelection = false;
			this.maskedTextBox10.Location = new System.Drawing.Point(68, 43);
			this.maskedTextBox10.Mask = "#.##%";
			this.maskedTextBox10.Name = "maskedTextBox10";
			this.maskedTextBox10.Size = new System.Drawing.Size(118, 20);
			this.maskedTextBox10.TabIndex = 6;
			this.maskedTextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// maskedTextBox01
			// 
			this.maskedTextBox01.BeepOnError = true;
			this.maskedTextBox01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maskedTextBox01.Enabled = false;
			this.maskedTextBox01.HideSelection = false;
			this.maskedTextBox01.Location = new System.Drawing.Point(192, 23);
			this.maskedTextBox01.Mask = "#.##%";
			this.maskedTextBox01.Name = "maskedTextBox01";
			this.maskedTextBox01.Size = new System.Drawing.Size(119, 20);
			this.maskedTextBox01.TabIndex = 5;
			this.maskedTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Section 1";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 58);
			this.label3.TabIndex = 1;
			this.label3.Text = "Section 2";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(68, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "Section 1";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(192, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 20);
			this.label5.TabIndex = 3;
			this.label5.Text = "Section 2";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// maskedTextBox00
			// 
			this.maskedTextBox00.BeepOnError = true;
			this.maskedTextBox00.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maskedTextBox00.Enabled = false;
			this.maskedTextBox00.HideSelection = false;
			this.maskedTextBox00.Location = new System.Drawing.Point(68, 23);
			this.maskedTextBox00.Mask = "#.##%";
			this.maskedTextBox00.Name = "maskedTextBox00";
			this.maskedTextBox00.Size = new System.Drawing.Size(118, 20);
			this.maskedTextBox00.TabIndex = 4;
			this.maskedTextBox00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tabPageBuildSequence
			// 
			this.tabPageBuildSequence.Controls.Add(this.buttonAddNewSequence);
			this.tabPageBuildSequence.ImageIndex = 0;
			this.tabPageBuildSequence.Location = new System.Drawing.Point(4, 23);
			this.tabPageBuildSequence.Name = "tabPageBuildSequence";
			this.tabPageBuildSequence.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBuildSequence.Size = new System.Drawing.Size(326, 563);
			this.tabPageBuildSequence.TabIndex = 1;
			this.tabPageBuildSequence.Text = "Section";
			this.tabPageBuildSequence.UseVisualStyleBackColor = true;
			// 
			// buttonAddNewSequence
			// 
			this.buttonAddNewSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewSequence.Location = new System.Drawing.Point(3, 3);
			this.buttonAddNewSequence.Name = "buttonAddNewSequence";
			this.buttonAddNewSequence.Size = new System.Drawing.Size(320, 23);
			this.buttonAddNewSequence.TabIndex = 0;
			this.buttonAddNewSequence.Text = "Add New Sequence";
			this.buttonAddNewSequence.UseVisualStyleBackColor = true;
			this.buttonAddNewSequence.Click += new System.EventHandler(this.buttonAddNewSequence_Click);
			// 
			// tabPageBuildPhrase
			// 
			this.tabPageBuildPhrase.Controls.Add(this.buttonAddNewPhrase);
			this.tabPageBuildPhrase.ImageIndex = 1;
			this.tabPageBuildPhrase.Location = new System.Drawing.Point(4, 23);
			this.tabPageBuildPhrase.Name = "tabPageBuildPhrase";
			this.tabPageBuildPhrase.Size = new System.Drawing.Size(326, 563);
			this.tabPageBuildPhrase.TabIndex = 2;
			this.tabPageBuildPhrase.Text = "Phrase";
			this.tabPageBuildPhrase.UseVisualStyleBackColor = true;
			// 
			// buttonAddNewPhrase
			// 
			this.buttonAddNewPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewPhrase.Location = new System.Drawing.Point(3, 3);
			this.buttonAddNewPhrase.Name = "buttonAddNewPhrase";
			this.buttonAddNewPhrase.Size = new System.Drawing.Size(320, 23);
			this.buttonAddNewPhrase.TabIndex = 1;
			this.buttonAddNewPhrase.Text = "Add New Phrase";
			this.buttonAddNewPhrase.UseVisualStyleBackColor = true;
			this.buttonAddNewPhrase.Click += new System.EventHandler(this.buttonAddNewPhrase_Click);
			// 
			// tabPageBuildMeasure
			// 
			this.tabPageBuildMeasure.Controls.Add(this.buttonAddNewMeasure);
			this.tabPageBuildMeasure.ImageIndex = 2;
			this.tabPageBuildMeasure.Location = new System.Drawing.Point(4, 23);
			this.tabPageBuildMeasure.Name = "tabPageBuildMeasure";
			this.tabPageBuildMeasure.Size = new System.Drawing.Size(326, 563);
			this.tabPageBuildMeasure.TabIndex = 3;
			this.tabPageBuildMeasure.Text = "Measure";
			this.tabPageBuildMeasure.UseVisualStyleBackColor = true;
			// 
			// buttonAddNewMeasure
			// 
			this.buttonAddNewMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewMeasure.Location = new System.Drawing.Point(3, 3);
			this.buttonAddNewMeasure.Name = "buttonAddNewMeasure";
			this.buttonAddNewMeasure.Size = new System.Drawing.Size(320, 23);
			this.buttonAddNewMeasure.TabIndex = 1;
			this.buttonAddNewMeasure.Text = "Add New Measure";
			this.buttonAddNewMeasure.UseVisualStyleBackColor = true;
			this.buttonAddNewMeasure.Click += new System.EventHandler(this.buttonAddNewMeasure_Click);
			// 
			// tabPageBuildMotif
			// 
			this.tabPageBuildMotif.Controls.Add(this.buttonAddNewMotif);
			this.tabPageBuildMotif.ImageIndex = 3;
			this.tabPageBuildMotif.Location = new System.Drawing.Point(4, 23);
			this.tabPageBuildMotif.Name = "tabPageBuildMotif";
			this.tabPageBuildMotif.Size = new System.Drawing.Size(326, 563);
			this.tabPageBuildMotif.TabIndex = 4;
			this.tabPageBuildMotif.Text = "Motif";
			this.tabPageBuildMotif.UseVisualStyleBackColor = true;
			// 
			// buttonAddNewMotif
			// 
			this.buttonAddNewMotif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewMotif.Location = new System.Drawing.Point(3, 3);
			this.buttonAddNewMotif.Name = "buttonAddNewMotif";
			this.buttonAddNewMotif.Size = new System.Drawing.Size(320, 23);
			this.buttonAddNewMotif.TabIndex = 1;
			this.buttonAddNewMotif.Text = "Add New Motif";
			this.buttonAddNewMotif.UseVisualStyleBackColor = true;
			this.buttonAddNewMotif.Click += new System.EventHandler(this.buttonAddNewMotif_Click);
			// 
			// tabPageBuildCell
			// 
			this.tabPageBuildCell.Controls.Add(this.buttonAddNewCell);
			this.tabPageBuildCell.ImageKey = "SixteenthNote.jpg";
			this.tabPageBuildCell.Location = new System.Drawing.Point(4, 23);
			this.tabPageBuildCell.Name = "tabPageBuildCell";
			this.tabPageBuildCell.Size = new System.Drawing.Size(326, 563);
			this.tabPageBuildCell.TabIndex = 5;
			this.tabPageBuildCell.Text = "Cell";
			this.tabPageBuildCell.UseVisualStyleBackColor = true;
			// 
			// buttonAddNewCell
			// 
			this.buttonAddNewCell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewCell.Location = new System.Drawing.Point(3, 3);
			this.buttonAddNewCell.Name = "buttonAddNewCell";
			this.buttonAddNewCell.Size = new System.Drawing.Size(320, 23);
			this.buttonAddNewCell.TabIndex = 1;
			this.buttonAddNewCell.Text = "Add New Cell";
			this.buttonAddNewCell.UseVisualStyleBackColor = true;
			this.buttonAddNewCell.Click += new System.EventHandler(this.buttonAddNewCell_Click);
			// 
			// imageListMusicIcons
			// 
			this.imageListMusicIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMusicIcons.ImageStream")));
			this.imageListMusicIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListMusicIcons.Images.SetKeyName(0, "WholeNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(1, "HalfNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(2, "QuarterNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(3, "EighthNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(4, "SixteenthNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(5, "Sharp.jpg");
			this.imageListMusicIcons.Images.SetKeyName(6, "Flat.jpg");
			this.imageListMusicIcons.Images.SetKeyName(7, "TrebleClef.jpg");
			this.imageListMusicIcons.Images.SetKeyName(8, "BassClef.jpg");
			this.imageListMusicIcons.Images.SetKeyName(9, "KeySignature.jpg");
			this.imageListMusicIcons.Images.SetKeyName(10, "BarLine.jpg");
			this.imageListMusicIcons.Images.SetKeyName(11, "DoubleBar.jpg");
			this.imageListMusicIcons.Images.SetKeyName(12, "BoldDoubleBar.jpg");
			this.imageListMusicIcons.Images.SetKeyName(13, "BlankStaffWithTrebleClef.jpg");
			// 
			// treeViewMain
			// 
			this.treeViewMain.CheckBoxes = true;
			this.treeViewMain.ContextMenuStrip = this.contextMenuSongStructures;
			this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewMain.FullRowSelect = true;
			this.treeViewMain.HideSelection = false;
			this.treeViewMain.ImageIndex = 0;
			this.treeViewMain.ImageList = this.imageListMusicIcons;
			this.treeViewMain.LabelEdit = true;
			this.treeViewMain.Location = new System.Drawing.Point(0, 0);
			this.treeViewMain.Name = "treeViewMain";
			this.treeViewMain.SelectedImageIndex = 0;
			this.treeViewMain.Size = new System.Drawing.Size(334, 368);
			this.treeViewMain.TabIndex = 0;
			this.treeViewMain.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewMain_AfterLabelEdit);
			this.treeViewMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewMain_KeyUp);
			// 
			// contextMenuSongStructures
			// 
			this.contextMenuSongStructures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPlayItem,
            this.menuPlayItemSpecial,
            this.toolStripSeparator9,
            this.menuItemStop,
            this.toolStripSeparator12,
            this.menuRenameItem,
            this.toolStripSeparator10,
            this.menuCutItem,
            this.menuCopyItem,
            this.menuPasteItem,
            this.menuDeleteItem,
            this.toolStripSeparator11,
            this.menuPropertiesItem});
			this.contextMenuSongStructures.Name = "contextMenuSongStructures";
			this.contextMenuSongStructures.Size = new System.Drawing.Size(145, 226);
			this.contextMenuSongStructures.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuSongStructures_ItemClicked);
			// 
			// menuPlayItem
			// 
			this.menuPlayItem.Name = "menuPlayItem";
			this.menuPlayItem.Size = new System.Drawing.Size(144, 22);
			this.menuPlayItem.Text = "&Play";
			// 
			// menuPlayItemSpecial
			// 
			this.menuPlayItemSpecial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPlayChildren,
            this.toolStripMenuItem1});
			this.menuPlayItemSpecial.Name = "menuPlayItemSpecial";
			this.menuPlayItemSpecial.Size = new System.Drawing.Size(144, 22);
			this.menuPlayItemSpecial.Text = "Play";
			// 
			// menuPlayChildren
			// 
			this.menuPlayChildren.Name = "menuPlayChildren";
			this.menuPlayChildren.Size = new System.Drawing.Size(201, 22);
			this.menuPlayChildren.Text = "Play children";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
			this.toolStripMenuItem1.Text = "Play Children Randomly";
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(141, 6);
			// 
			// menuItemStop
			// 
			this.menuItemStop.Name = "menuItemStop";
			this.menuItemStop.Size = new System.Drawing.Size(144, 22);
			this.menuItemStop.Text = "&Stop";
			this.menuItemStop.Click += new System.EventHandler(this.menuItemStop_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(141, 6);
			// 
			// menuRenameItem
			// 
			this.menuRenameItem.Name = "menuRenameItem";
			this.menuRenameItem.Size = new System.Drawing.Size(144, 22);
			this.menuRenameItem.Text = "Rename...";
			this.menuRenameItem.Click += new System.EventHandler(this.menuRenameItem_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(141, 6);
			// 
			// menuCutItem
			// 
			this.menuCutItem.Name = "menuCutItem";
			this.menuCutItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.menuCutItem.Size = new System.Drawing.Size(144, 22);
			this.menuCutItem.Text = "Cut";
			// 
			// menuCopyItem
			// 
			this.menuCopyItem.Name = "menuCopyItem";
			this.menuCopyItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.menuCopyItem.Size = new System.Drawing.Size(144, 22);
			this.menuCopyItem.Text = "Copy";
			// 
			// menuPasteItem
			// 
			this.menuPasteItem.Name = "menuPasteItem";
			this.menuPasteItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.menuPasteItem.Size = new System.Drawing.Size(144, 22);
			this.menuPasteItem.Text = "Paste";
			// 
			// menuDeleteItem
			// 
			this.menuDeleteItem.Name = "menuDeleteItem";
			this.menuDeleteItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.menuDeleteItem.Size = new System.Drawing.Size(144, 22);
			this.menuDeleteItem.Text = "Delete";
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(141, 6);
			// 
			// menuPropertiesItem
			// 
			this.menuPropertiesItem.Name = "menuPropertiesItem";
			this.menuPropertiesItem.Size = new System.Drawing.Size(144, 22);
			this.menuPropertiesItem.Text = "Properties...";
			// 
			// imageListMusicStructures
			// 
			this.imageListMusicStructures.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListMusicStructures.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListMusicStructures.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// threadSongPlayer
			// 
			this.threadSongPlayer.WorkerReportsProgress = true;
			this.threadSongPlayer.WorkerSupportsCancellation = true;
			this.threadSongPlayer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadSongPlayer_DoWork);
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.treeListView1);
			this.splitContainer3.Size = new System.Drawing.Size(846, 702);
			this.splitContainer3.SplitterDistance = 282;
			this.splitContainer3.TabIndex = 0;
			// 
			// treeListView1
			// 
			this.treeListView1.AllColumns.Add(this.columnTrackID);
			this.treeListView1.AllColumns.Add(this.columnTrackName);
			this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTrackID,
            this.columnTrackName});
			this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeListView1.Location = new System.Drawing.Point(0, 0);
			this.treeListView1.Name = "treeListView1";
			this.treeListView1.OwnerDraw = true;
			this.treeListView1.ShowGroups = false;
			this.treeListView1.Size = new System.Drawing.Size(846, 416);
			this.treeListView1.TabIndex = 0;
			this.treeListView1.UseCompatibleStateImageBehavior = false;
			this.treeListView1.View = System.Windows.Forms.View.Details;
			this.treeListView1.VirtualMode = true;
			// 
			// columnTrackID
			// 
			this.columnTrackID.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnTrackID.Text = "Track ID";
			this.columnTrackID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// columnTrackName
			// 
			this.columnTrackName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnTrackName.Text = "Track Name";
			this.columnTrackName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 962);
			this.Controls.Add(this.splitContainer1);
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BioMusic";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainerMainLeft.Panel1.ResumeLayout(false);
			this.splitContainerMainLeft.Panel1.PerformLayout();
			this.splitContainerMainLeft.Panel2.ResumeLayout(false);
			this.splitContainerMainLeft.ResumeLayout(false);
			this.panelMainViewerFrame.ResumeLayout(false);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeListViewMessageLog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeListViewRepository)).EndInit();
			this.splitContainerMainRight.Panel1.ResumeLayout(false);
			this.splitContainerMainRight.Panel2.ResumeLayout(false);
			this.splitContainerMainRight.ResumeLayout(false);
			this.tabControlMainProperties.ResumeLayout(false);
			this.tabPageBuildSong.ResumeLayout(false);
			this.splitContainerSongProps.Panel1.ResumeLayout(false);
			this.splitContainerSongProps.Panel2.ResumeLayout(false);
			this.splitContainerSongProps.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanelSongProps.ResumeLayout(false);
			this.tableLayoutPanelSongProps.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.upDownSongTempo)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.restChance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesNumSections)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesNumPhrases)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesNumMeasures)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.songPropertiesChordChance)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabPageBuildSequence.ResumeLayout(false);
			this.tabPageBuildPhrase.ResumeLayout(false);
			this.tabPageBuildMeasure.ResumeLayout(false);
			this.tabPageBuildMotif.ResumeLayout(false);
			this.tabPageBuildCell.ResumeLayout(false);
			this.contextMenuSongStructures.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainerMainLeft;
		private System.Windows.Forms.SplitContainer splitContainerMainRight;
		private System.Windows.Forms.TabControl tabControlMainProperties;
		private System.Windows.Forms.TabPage tabPageBuildSong;
		private System.Windows.Forms.TabPage tabPageBuildSequence;
		private System.Windows.Forms.TabPage tabPageBuildPhrase;
		private System.Windows.Forms.TabPage tabPageBuildMeasure;
		private System.Windows.Forms.TabPage tabPageBuildMotif;
		private System.Windows.Forms.TabPage tabPageBuildCell;
		private System.Windows.Forms.TreeView treeViewMain;
		private System.Windows.Forms.ImageList imageListMusicStructures;
		private System.Windows.Forms.Button buttonAddNewSequence;
		private System.Windows.Forms.Button buttonAddNewPhrase;
		private System.Windows.Forms.Button buttonAddNewMeasure;
		private System.Windows.Forms.Button buttonAddNewMotif;
		private System.Windows.Forms.Button buttonAddNewCell;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mainWindowViewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem layoutViewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outlineViewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem staffViewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flowChartViewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem sheetMusicPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem toolWindowsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miniOutlineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem objectPropertiesWindowToolStripMenuItem;
		private System.Windows.Forms.ImageList imageListMusicIcons;
		private System.Windows.Forms.ToolStripMenuItem pianoWindowToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuSongStructures;
		private System.Windows.Forms.ToolStripMenuItem menuPlayItem;
		private System.Windows.Forms.ToolStripMenuItem menuPlayItemSpecial;
		private System.Windows.Forms.ToolStripMenuItem menuPlayChildren;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem menuRenameItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem menuCutItem;
		private System.Windows.Forms.ToolStripMenuItem menuCopyItem;
		private System.Windows.Forms.ToolStripMenuItem menuPasteItem;
		private System.Windows.Forms.ToolStripMenuItem menuDeleteItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem menuPropertiesItem;
		private System.Windows.Forms.Panel panelMainViewerFrame;
		private System.ComponentModel.BackgroundWorker threadSongPlayer;
		private System.Windows.Forms.SplitContainer splitContainerSongProps;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSongProps;
		private System.Windows.Forms.LinkLabel helpLabelSongScale;
		private System.Windows.Forms.LinkLabel helpLabelLength;
		private System.Windows.Forms.Label labelSongLength;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.LinkLabel helpLabelRootOctave;
		private System.Windows.Forms.ComboBox comboBoxRootOctave;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.ComboBox comboBoxOctaveSpan;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.MaskedTextBox maskedTextBox00;
		private System.Windows.Forms.MaskedTextBox maskedTextBox11;
		private System.Windows.Forms.MaskedTextBox maskedTextBox10;
		private System.Windows.Forms.MaskedTextBox maskedTextBox01;
		private System.Windows.Forms.LinkLabel helpLabelSmallestNote;
		private System.Windows.Forms.ComboBox comboBoxSongSmallestNote;
		private System.Windows.Forms.LinkLabel helpLabelTempo;
		private System.Windows.Forms.NumericUpDown upDownSongTempo;
		private System.Windows.Forms.LinkLabel helpLabelSongTimeSign;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox SongTimeSignNumerator;
		private System.Windows.Forms.ComboBox SongTimeSignDenominator;
		private System.Windows.Forms.ToolStripMenuItem menuItemStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem changeMIDIInToolStripMenuItem;
		private System.Windows.Forms.LinkLabel helpLabelLongestNote;
		private System.Windows.Forms.ComboBox comboBoxSongLongestNote;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.NumericUpDown restChance;
		private System.Windows.Forms.LinkLabel helpLabelNumSections;
		private System.Windows.Forms.NumericUpDown songPropertiesNumSections;
		private System.Windows.Forms.LinkLabel helpLabelNumPhrases;
		private System.Windows.Forms.NumericUpDown songPropertiesNumPhrases;
		private System.Windows.Forms.NumericUpDown songPropertiesNumMeasures;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ComboBox songScaleTonic;
		private System.Windows.Forms.ComboBox songScalePattern;
		private System.Windows.Forms.LinkLabel helpLabelChordChance;
		private System.Windows.Forms.NumericUpDown songPropertiesChordChance;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private BrightIdeasSoftware.TreeListView treeListViewMessageLog;
		private BrightIdeasSoftware.OLVColumn treeListViewColEventID;
		private BrightIdeasSoftware.OLVColumn treeListViewColCategory;
		private BrightIdeasSoftware.OLVColumn treeListViewColType;
		private BrightIdeasSoftware.OLVColumn treeListViewColTime;
		private BrightIdeasSoftware.OLVColumn treeListViewColMsg;
		private BrightIdeasSoftware.TreeListView treeListViewRepository;
		private BrightIdeasSoftware.OLVColumn repositoryColName;
		private BrightIdeasSoftware.OLVColumn repositoryColLength;
		private BrightIdeasSoftware.OLVColumn repositoryColChildren;
		private BrightIdeasSoftware.OLVColumn repositoryColSections;
		private BrightIdeasSoftware.OLVColumn repositoryColPhrases;
		private BrightIdeasSoftware.OLVColumn repositoryColMeasures;
		private BrightIdeasSoftware.OLVColumn repositoryColMotifs;
		private BrightIdeasSoftware.OLVColumn repositoryColCells;
		private BrightIdeasSoftware.OLVColumn repositoryColNotes;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem releaseNotesToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private BrightIdeasSoftware.TreeListView treeListView1;
		private BrightIdeasSoftware.OLVColumn columnTrackID;
		private BrightIdeasSoftware.OLVColumn columnTrackName;

	}
}

