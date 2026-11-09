using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
//using Sanford.Multimedia.Timers;

using BioMusic.Code.Utility;

namespace BioMusic
{
	class BioSequence 
	{
		protected BioSequenceGene gene = new BioSequenceGene();

		protected Track track;
		protected Sequence sequence;
		protected Sequencer sequencer;

		protected RecordingSession recSession;

		protected Random rand = new Random();
		
		protected ChannelMessageBuilder msgBuilder = new ChannelMessageBuilder();

		protected MusicScale currentScale;
		protected Note currentNote;

		protected MidiInternalClock clock;
		protected SongPositionPointerBuilder songPosition = new SongPositionPointerBuilder();

		public BioSequence()
		{
			recSession = new RecordingSession(clock);
		}

		public void CreateTrackFromGene()
		{
			int BPS = gene.BPM / 60;
			int numSteps = (int)((float)BPS * gene.PlayLength);

			//currentScale = new MusicScale(gene.Key);
			//currentNote = (Note)currentScale.Notes[gene.FirstNote];
			
			msgBuilder.MidiChannel = 0;
			clock.Start();

			for (int i = 0; i < numSteps; i++)
			{
				msgBuilder.Command = ChannelCommand.NoteOn;
				
				msgBuilder.Data1 = (int)currentNote;
				msgBuilder.Data2 = 127;

				msgBuilder.Build();
				recSession.Record(msgBuilder.Result);

				//clock.SetTicks(clock.Ticks + clock.Tempo);

				if (rand.NextDouble() <= gene.ChanceOfHoldingNote)
				{
				}
				else
				{
					//Shut off note
					//TODO: NEEDS WORK ON NOTE LENGTH
					msgBuilder.Command = ChannelCommand.NoteOff;
					msgBuilder.Data2 = 0;
					msgBuilder.Build();
					recSession.Record(msgBuilder.Result);

					if (rand.NextDouble() <= gene.ChanceOfRepeatingNote)
					{
					}
					else
					{
						if (rand.NextDouble() <= gene.ChanceOfRestNote)
						{
							//clock.SetTicks(clock.Ticks + clock.Tempo);
							continue;
						}

						ChooseNextNote();
					}
				}
			}

			clock.Stop();

			recSession.Build();
			//recSession.Result
		}

		protected void ChooseNextNote()
		{
			//currentNote = (Note)currentScale.Notes[rand.Next(currentScale.NoteCount)];
		}
	}
}
