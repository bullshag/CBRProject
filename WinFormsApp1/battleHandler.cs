using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class battleHandler
    {
        public struct characterSlot
        {
            public int cid;
            public int slotID;
            public int speed;
            public bool alive;
            public characterData _charData;
        }

        public struct npcSlot
        {
            public int cid;
            public int slotID;
            public int speed;
            public bool alive;
            public npcData _npcData;
        }


    }
}
