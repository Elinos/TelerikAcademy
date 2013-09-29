
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleSity
{
    public class FinishGameMessage
    {
        public int Score { get; set; }

        public bool IsGameOver { get; set; }

        public string Message { get; set; }
    }
}
