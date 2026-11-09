using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BioMusic.Code.MusicForms;

namespace BioMusic.Code.Project
{
	public class Project
	{
		#region Enums

		#endregion

		#region Delegates

		#endregion

		#region Fields

		/// <summary>
		/// The songs in the project.
		/// </summary>
		private SongArray songs;

		/// <summary>
		/// The name of the project.
		/// </summary>
		private string name;

		#endregion

		#region Properties

		/// <summary>
		/// Gets/sets the songs.
		/// </summary>
		public SongArray Songs
		{
			get { return this.songs; }
			protected set { this.songs = value; }
		}

		/// <summary>
		/// Gets the number of songs in the project.
		/// </summary>
		public int NumSongs
		{
			get { return this.Songs.Count; }
		}

		/// <summary>
		/// Gets/sets the name of the project.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		#endregion

		#region Construction

		public Project()
		{
			InitMemory();
		}

		#endregion

		#region Methods

		#region Initialization

		protected virtual void InitMemory()
		{
			this.Songs = new SongArray(false);
		}		

		#endregion
		
		#region Clean up

		protected virtual void Dispose()
		{
			this.Songs.Clear();
		}

		#endregion

		#region Adding songs

		public virtual void AddSong(MusicFormSong song)
		{
			this.Songs.Add(song);
		}

		#endregion

		#endregion

		#region Indexers

		public MusicFormSong this[int i]
		{
			get { return this.Songs[i]; }
			set { this.Songs.SetByIndex(i, value); }
		}

		public MusicFormSong this[string name]
		{
			get { return this.Songs[name]; }
		}

		#endregion

		#region Events

		#endregion
	}
}
