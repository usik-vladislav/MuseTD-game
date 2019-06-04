using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Loop
{
    public Dictionary<int, Mob> LoopBeat { get; set; }

    public Dictionary<int, Mob> LoopD4 { get; set; }

    public Loop()
    {
        LoopBeat = new Dictionary<int, Mob>();
        LoopD4 = new Dictionary<int, Mob>();
    }

}

