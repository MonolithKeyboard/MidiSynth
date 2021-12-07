using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiSynth
{
    [Serializable]
    public class NoteLenghtTuples
    {
        public LinkedList<int[]> NoteLenghtTupleList { get; private set; }
        public NoteLenghtTuples()
        {
            NoteLenghtTupleList = new LinkedList<int[]>();
        }
        public void ClearList()
        {
            NoteLenghtTupleList.Clear();
        }
    }
}
