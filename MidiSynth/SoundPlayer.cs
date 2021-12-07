using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NAudio.Midi;

namespace MidiSynth
{
    public class SoundPlayer
    {
        private MidiOut midiOut;
        public NoteLenghtTuples NotesForPlaying { get; private set; }
        public SoundPlayer() { }
        public void PlayNotes(NoteLenghtTuples notes, int patch)
        {
            if (patch > 127 || patch < 0)
            {
                throw new ArgumentOutOfRangeException("Некорректный номер инструмента");
            }
            midiOut = new MidiOut(0);
            foreach(int[] arr in notes.NoteLenghtTupleList)
            {
                midiOut.Send(arr[0]);
                Thread.Sleep(arr[1]);
                midiOut.Send(arr[2]);
                Thread.Sleep(100);
            }
            midiOut.Close();
            midiOut.Dispose();
        }
    }
}
