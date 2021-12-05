using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace MidiSynth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MidiOut midiOut = new MidiOut(0);
        uint playFlag = 3;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void keyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (playFlag < 1)
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
        private void keyUpEventHandler(object sender, KeyEventArgs e)
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
            playFlag = 0;
        }
    }
}
