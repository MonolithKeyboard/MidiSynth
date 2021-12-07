using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Midi;
using Melanchall.DryWetMidi;

namespace MidiSynth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MidiOut midiOut = new MidiOut(0);
        private uint playFlag = 0;
        private uint keyCount = 0;
        private int selectedPatch = 0;
        private bool recordFlag = false;
        private Dictionary<string, int> noteMap = new Dictionary<string, int>() {
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
            }
        }
        private void PianoButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            midiOut.Send(MidiMessage.StartNote(noteMap[clickedButton.Content.ToString()], 127, 1).RawData);
            Thread.Sleep(200);
            midiOut.Send(MidiMessage.StopNote(noteMap[clickedButton.Content.ToString()], 127, 1).RawData);
        }
        private void PatchSliderValueChanged(object sender, EventArgs e)
        {
            selectedPatch = Convert.ToInt32(patchSlider.Value);
            midiOut.Send(MidiMessage.ChangePatch(selectedPatch, 1).RawData);
        }
        private void PreviewKeyDownEventHandler(object sender, KeyEventArgs e)
        {
            keyCount++;
        }
        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (playFlag < keyCount && recordFlag == false)
            {
                switch (e.Key)
                {
                    case Key.Z: //C4
                        midiOut.Send(MidiMessage.StartNote(60, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.S: //C4#|D4b
                        midiOut.Send(MidiMessage.StartNote(61, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.X: //D4
                        midiOut.Send(MidiMessage.StartNote(62, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.D: //D4#|E4b
                        midiOut.Send(MidiMessage.StartNote(63, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.C:  //E4
                        midiOut.Send(MidiMessage.StartNote(64, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.V: //F4
                        midiOut.Send(MidiMessage.StartNote(65, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.G: //F4#|G4b
                        midiOut.Send(MidiMessage.StartNote(66, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.B: //G4
                        midiOut.Send(MidiMessage.StartNote(67, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.H: //G4#|A4b
                        midiOut.Send(MidiMessage.StartNote(68, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.N: //A4
                        midiOut.Send(MidiMessage.StartNote(69, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.J: //A4#|B4b
                        midiOut.Send(MidiMessage.StartNote(70, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.M: //B4
                        midiOut.Send(MidiMessage.StartNote(71, 127, 1).RawData);
                        playFlag += 1;
                        return;
                    case Key.OemComma: //C5
                        midiOut.Send(MidiMessage.StartNote(72, 127, 1).RawData);
                        playFlag += 1;
                        return;
                }
            }
        }
        private void KeyUpEventHandler(object sender, KeyEventArgs e)
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
            keyCount = 0;
            playFlag = 0;
        }
    }
}
