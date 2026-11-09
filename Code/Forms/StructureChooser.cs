using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using GeneticMusicMaker.Code.MusicForms;

namespace GeneticMusicMaker.Code.Forms
{
	public partial class StructureChooser : Form
	{
		#region Tree item check box stuff

		#region p/invoke
		// constants used to hide a checkbox 
		public static readonly int TVIF_STATE = 0x8;
		public static readonly int TVIS_STATEIMAGEMASK = 0xF000;
		public static readonly int TV_FIRST = 0x1100;
		public static readonly uint TVM_SETITEM = (uint)(TV_FIRST + 63);

		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
		IntPtr lParam);

		// struct used to set node properties 
		protected struct TVITEM
		{
			public int mask;
			public IntPtr hItem;
			public int state;
			public int stateMask;
			[MarshalAs(UnmanagedType.LPTStr)]
			public String lpszText;
			public int cchTextMax;
			public int iImage;
			public int iSelectedImage;
			public int cChildren;
			public IntPtr lParam;

		}
		#endregion

		protected void DisplayTreeItemCheckBox(TreeNode node)
		{
			DisplayTreeItemCheckBox(node, true);
		}

		protected void DisplayTreeItemCheckBox(TreeNode node, bool bVisible)
		{
			node.Tag = bVisible;
			TVITEM tvi = new TVITEM();
			tvi.hItem = node.Handle;
			tvi.mask = TVIF_STATE;
			tvi.stateMask = TVIS_STATEIMAGEMASK;
			tvi.state = (bVisible ? 1 << 12 : 0);
			IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
			Marshal.StructureToPtr(tvi, lparam, false);
			SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, lparam); 
		}

		#endregion

		////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////

		#region Fields

		Control controlAnchor = null;
		bool bUnchecking = false;
		MusicForm currentSelectionType = MusicForm.Song;

		#endregion

		////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////

		#region Construction

		public StructureChooser(MusicForm choiceType, TreeNodeCollection treeNodes)
		{
			InitializeComponent();
			currentSelectionType = choiceType;
			LoadTreeNodes(choiceType, treeNodes);
		}

		#endregion

		////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////

		#region Load tree nodes

		void LoadTreeNodes(MusicForm choiceType, TreeNodeCollection treeNodes)
		{
			foreach (TreeNode node in treeNodes)
			{
				TreeNode newNode = treeViewStructures.Nodes.Add(node.FullPath, node.Text);

				if (newNode.Level < (int)choiceType)
					LoadTreeNodes(choiceType, node.Nodes, newNode);
				
				DisplayTreeItemCheckBox(newNode, (newNode.Level == (int)choiceType));

				if (newNode.Level < (int)choiceType && newNode.Nodes.Count == 0)
				{
					newNode.ForeColor = Color.Gray;
				}
			}
		}
		
		void LoadTreeNodes(MusicForm choiceType, TreeNodeCollection treeNodes, TreeNode parent)
		{
			foreach (TreeNode node in treeNodes)
			{
				TreeNode newNode = parent.Nodes.Add(node.FullPath, node.Text);

				if (newNode.Level < (int)choiceType)
					LoadTreeNodes(choiceType, node.Nodes, newNode);

				DisplayTreeItemCheckBox(newNode, (newNode.Level == (int)choiceType));

				if (newNode.Level < (int)choiceType && newNode.Nodes.Count == 0)
				{
					newNode.ForeColor = Color.Gray;
				}
			}
		}

		#endregion

		////////////////////////////////////////////////////////////////

		#region Properties

		public Control ControlAnchor
		{
			get { return this.controlAnchor; }

			set { controlAnchor = value; this.Location = controlAnchor.PointToScreen(Point.Empty); }
		}
		
		public TreeNode SelectedItem
		{
			get { return GetSelectedTreeItem(); }
		}

		#endregion

		////////////////////////////////////////////////////////////////

		#region Get selected tree item

		protected TreeNode GetSelectedTreeItem()
		{
			foreach (TreeNode node in treeViewStructures.Nodes)
			{
				if (node.Level == (int)currentSelectionType)
				{
					if (node.Checked)
						return node;
				}
				else
				{
					TreeNode temp = GetSelectedTreeItem(node.Nodes);
					if (temp == null) continue;
					return temp;
				}
			}

			return null;
		}

		protected TreeNode GetSelectedTreeItem(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Level == (int)currentSelectionType)
				{
					if (node.Checked)
						return node;
				}
				else
				{
					TreeNode temp = GetSelectedTreeItem(node.Nodes);
					if (temp == null) continue;
					return temp;
				}
			}

			return null;
		}

		#endregion

		////////////////////////////////////////////////////////////////

		#region Events

		private void treeViewStructures_AfterCheck(object sender, TreeViewEventArgs e)
		{
			//if (this.bUnchecking || e.Action != TreeViewAction.Unknown)
			//{
			//    foreach (TreeNode node in treeViewStructures.Nodes)
			//    {
			//        if (node == e.Node) continue;

			//        if (node.Level == (int)currentSelectionType)
			//        {
			//            bool tempBool = this.bUnchecking;
			//            this.bUnchecking = false;
			//            node.Checked = false;
			//            this.bUnchecking = tempBool;
			//        }
			//        else
			//            UncheckAllChildNodes(node);
			//    }
			//}
		}

		private void treeViewStructures_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (this.bUnchecking || e.Action != TreeViewAction.Unknown)
			{
				foreach (TreeNode node in treeViewStructures.Nodes)
				{
					if (node == e.Node) continue;

					if (node.Level == (int)currentSelectionType)
					{
						bool tempBool = this.bUnchecking;
						this.bUnchecking = false;
						node.Checked = false;
						this.bUnchecking = tempBool;
					}
					else
						UncheckAllChildNodes(node);
				}
			}
		}

		// Updates all child tree nodes recursively.
		private void UncheckAllChildNodes(TreeNode treeNode)
		{
			foreach (TreeNode node in treeNode.Nodes)
			{
				if (node.Level == (int)currentSelectionType)
				{
					bool tempBool = bUnchecking;
					bUnchecking = false;
					node.Checked = false;
					bUnchecking = tempBool;
				}
				else
					UncheckAllChildNodes(node);
			}
		}

		private void DrawNode(DrawTreeNodeEventArgs e, TreeNode node, Brush fontColor, FontStyle fontStyle, Brush bgBrush)
		{
			Font newFont = null;

			if (this.Font == null)
				newFont = new Font(Control.DefaultFont.FontFamily, Control.DefaultFont.Size, fontStyle);
			else
				newFont = new Font(this.Font.FontFamily, this.Font.Size, fontStyle);

			Rectangle newBounds = GetAdjustedBounds(e.Bounds);
			e.Graphics.FillRectangle(bgBrush, newBounds);
			e.Graphics.DrawString(node.Text, newFont, fontColor, newBounds);
		}

		private Rectangle GetAdjustedBounds(Rectangle current)
		{
			Rectangle newBounds = current;
			newBounds.X += 1; newBounds.Width += 2;//newBounds.Height -= 1; newBounds.Y += 1;
			return newBounds;
		}

		private void treeViewStructures_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			TreeNode node = e.Node;

			if ((bool)node.Tag == false && node.GetNodeCount(false) == 0)
			{
				DrawNode(e, node, Brushes.Gray, FontStyle.Strikeout, Brushes.White);
				return;
			}
			
			if ((e.State & TreeNodeStates.Default) != 0)
			{
				DrawNode(e, node, new SolidBrush(node.TreeView.ForeColor), FontStyle.Regular, Brushes.White);
				return;
			}
	
			FontStyle fontStyle = FontStyle.Regular;
			Color fontColor = Color.Black;
			Color bgColor = Color.White;

			if ((e.State & TreeNodeStates.Hot) != 0)
			{
				if ((e.State & TreeNodeStates.Checked) != 0)
				{
					if ((e.State & TreeNodeStates.Selected) != 0)
					{
						fontColor = Color.Purple;
						bgColor = Color.DarkSlateBlue;
					}
					else
					{
						fontColor = Color.Violet;
						bgColor = Color.LightSteelBlue;
					}
				}
				else
				{
					if ((e.State & TreeNodeStates.Selected) != 0)
					{
						fontColor = Color.BlueViolet;
						bgColor = Color.LightSalmon;
					}
					else
					{
						fontColor = Color.Blue;
					}
				}

				fontStyle |= FontStyle.Underline;
			}
			else
			{
				if ((e.State & TreeNodeStates.Checked) != 0)
					bgColor = Color.SlateBlue;

				if ((e.State & TreeNodeStates.Selected) != 0)
					bgColor = Color.MediumSlateBlue;
			}

			if ((e.State & TreeNodeStates.Selected) != 0)
				fontStyle |= FontStyle.Italic;

			if ((e.State & TreeNodeStates.Checked) != 0)
				fontStyle |= FontStyle.Bold;

			DrawNode(e, node, new SolidBrush(fontColor), fontStyle, new SolidBrush(bgColor));

			// If the node has focus, draw the focus rectangle large, making
			// it large enough to include the text of the node tag, if present.
			if ((e.State & TreeNodeStates.Focused) != 0)
			{
				using (Pen focusPen = new Pen(Color.Black))
				{
					focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
					Rectangle focusBounds = GetAdjustedBounds(e.Node.Bounds);
					focusBounds.Size = new Size(focusBounds.Width /*- 1*/,
					focusBounds.Height /*- 1*/);
					e.Graphics.DrawRectangle(focusPen, focusBounds);
				}
			}
		}

		private void treeViewStructures_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level == (int)currentSelectionType)
			{
				this.bUnchecking = true;
				e.Node.Checked = true;
				this.bUnchecking = false;
			}
		}

		private void treeViewStructures_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.GetNodeCount(false) > 0 && !e.Node.IsExpanded)
				e.Node.Expand();
			else if ((bool)e.Node.Tag == true)
			{
				e.Node.Checked = true;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void treeViewStructures_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
		{
			//if (e.Node.GetNodeCount(false) > 0 || (bool)e.Node.Tag)
			//{
			//    //e.Node.
			//    e.Node.ForeColor = Color.Green;
			//    e.Node.NodeFont = new Font(e.Node.TreeView.Font, /*FontStyle.Bold |*/ FontStyle.Underline);
			//}
			//else
			//    e.Node.NodeFont = new Font(e.Node.TreeView.Font, FontStyle.Strikeout);
		}

		#endregion		
	}
}
