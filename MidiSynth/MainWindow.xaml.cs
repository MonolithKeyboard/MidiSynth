using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using NAudio.Midi;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.IO;


namespace MidiSynth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MidiOut midiOut = new MidiOut(0);
        NoteLenghtTuples notes = new NoteLenghtTuples();
        int[] tmpArray = new int[3];
        private bool playFlag = false;
        private int selectedPatch = 0;
        private bool recordFlag = false;
        private Stopwatch stopwatch = new Stopwatch();
        private Dictionary<string, int> noteMap = new Dictionary<string, int>() 
        {
            { "C4", 60 },
            { "C4#D4b", 61 },
            { "D4", 62 },
            { "D4#E4b", 63 },
            { "E4", 64 },
            { "F4", 65 },
            { "F4#G4b", 66 },
            { "G4", 67 },
            { "G4#A4b", 68 },
            { "A4", 69 },
            { "A4#B4b", 70 },
            { "B4", 71 },
            { "C5", 72 }
        };
        private Dictionary<string, int> patchMap = new Dictionary<string, int>()
        {
            {"Пианино", 0},
            {"Электропианино", 4},
            {"Ксилофон", 13},
            {"Гитара", 24},
            {"Бас", 32}
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RecordButtonClick(object sender, EventArgs e)
        {
            Button recordButton = (Button)sender;
            if (recordFlag == false)
            {
                recordButton.Background = Brushes.Red;
                recordFlag = true;
            }
            else
            {
                recordButton.Background = Brushes.White;
                recordFlag = false;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Serialize file(*.bin)|*.bin|Все файлы(*.*)|*.*";
                if (save.ShowDialog() != true) { return; }
                FileStream stream = new FileStream(save.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, notes);
                stream.Close();
            }
        }
        private void PianoButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            midiOut.Send(MidiMessage.StartNote(noteMap[clickedButton.Content.ToString()], 127, 1).RawData);
            Thread.Sleep(150);
            midiOut.Send(MidiMessage.StopNote(noteMap[clickedButton.Content.ToString()], 127, 1).RawData);
        }
        private void PatchComboBoxSelected(object sender, EventArgs e)
        {
            selectedPatch = patchMap[PatchComboBox.SelectedItem.ToString()];
            midiOut.Send(MidiMessage.ChangePatch(selectedPatch, 1).RawData);
        }
        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (playFlag == false && recordFlag == false)
            {
                switch (e.Key)
                {
                    case Key.Z: //C4
                        midiOut.Send(MidiMessage.StartNote(60, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.S: //C4#|D4b
                        midiOut.Send(MidiMessage.StartNote(61, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.X: //D4
                        midiOut.Send(MidiMessage.StartNote(62, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D: //D4#|E4b
                        midiOut.Send(MidiMessage.StartNote(63, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.C:  //E4
                        midiOut.Send(MidiMessage.StartNote(64, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.V: //F4
                        midiOut.Send(MidiMessage.StartNote(65, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.G: //F4#|G4b
                        midiOut.Send(MidiMessage.StartNote(66, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.B: //G4
                        midiOut.Send(MidiMessage.StartNote(67, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.H: //G4#|A4b
                        midiOut.Send(MidiMessage.StartNote(68, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.N: //A4
                        midiOut.Send(MidiMessage.StartNote(69, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.J: //A4#|B4b
                        midiOut.Send(MidiMessage.StartNote(70, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.M: //B4
                        midiOut.Send(MidiMessage.StartNote(71, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.OemComma: //C5
                        midiOut.Send(MidiMessage.StartNote(72, 127, 1).RawData);
                        playFlag = true;
                        return;
                }
            }
            else if (playFlag == false && recordFlag == true)
            {
                stopwatch.Reset();
                stopwatch.Start();
                int msgStart;
                switch (e.Key)
                {
                    case Key.Z: //C4
                        msgStart = MidiMessage.StartNote(60, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.S: //C4#|D4b
                        msgStart = MidiMessage.StartNote(61, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.X: //D4
                        msgStart = MidiMessage.StartNote(62, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.D: //D4#|E4b
                        msgStart = MidiMessage.StartNote(63, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.C:  //E4
                        msgStart = MidiMessage.StartNote(64, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.V: //F4
                        msgStart = MidiMessage.StartNote(65, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.G: //F4#|G4b
                        msgStart = MidiMessage.StartNote(66, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.B: //G4
                        msgStart = MidiMessage.StartNote(67, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.H: //G4#|A4b
                        msgStart = MidiMessage.StartNote(68, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.N: //A4
                        msgStart = MidiMessage.StartNote(69, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.J: //A4#|B4b
                        msgStart = MidiMessage.StartNote(70, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.M: //B4
                        msgStart = MidiMessage.StartNote(71, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.OemComma: //C5
                        msgStart = MidiMessage.StartNote(72, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                }
            }
        }
        public void StopAllNotes()
        {
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
        private void KeyUpEventHandler(object sender, KeyEventArgs e)
        {
            if (recordFlag == false)
            {
                StopAllNotes();
                playFlag = false;
            }
            else if (recordFlag == true)
            {
                stopwatch.Stop();
                tmpArray[1] = (int)stopwatch.ElapsedMilliseconds + 250;
                tmpArray[2] = selectedPatch;
                StopAllNotes();
                playFlag = false;
                notes.NoteLenghtTupleList.AddLast(tmpArray);
            }
        }
        private void OpenSerializedButtonClick(object sender, EventArgs e)
        {
            midiOut.Close();
            midiOut.Dispose();
            NoteLenghtTuples playNotes = new NoteLenghtTuples();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Serialize file(*.bin)|*.bin|Все файлы(*.*)|*.*";
            if (open.ShowDialog() != true) { return; }
            FileStream stream = new FileStream(open.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            playNotes = (NoteLenghtTuples)bf.Deserialize(stream);
            stream.Close();
            SoundPlayer player = new SoundPlayer();
            player.PlayNotes(playNotes, selectedPatch);
            midiOut = new MidiOut(0);
        }
    }
}
