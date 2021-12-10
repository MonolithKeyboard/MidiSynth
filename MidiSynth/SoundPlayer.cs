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
            midiOut.Send(MidiMessage.ChangePatch(patch, 1).RawData);
            foreach (int[] arr in notes.NoteLenghtTupleList)
            {
                midiOut.Send(arr[0]);
                Thread.Sleep(arr[1]);
                Thread.Sleep(100);
                midiOut.Send(MidiMessage.StopNote(60, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(61, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(62, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(63, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(64, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(65, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(66, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(67, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(68, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(69, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(70, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(71, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(72, 127, 1).RawData);
            }
            midiOut.Close();
            midiOut.Dispose();
        }
    }
}
