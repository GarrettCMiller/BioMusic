using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic.Code
{

#if USE_DERIVED_MUSIC_SCALES

	[Serializable()]
	public class Scale : Midi.Scale
	{
	}

	[Serializable()]
	public class Chord : Midi.Chord
	{
	}

	[Serializable()]
	public class ChordPattern : Midi.ChordPattern
	{
	}

#endif

}
