using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter: Machine, IFighter
    {
        private bool stealthMode;


        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode) 
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 200;
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            if (stealthMode == true)
            {
                stealthMode = false;
            }
            else
            {
                stealthMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            if (stealthMode)
            {
                output.AppendFormat(" *Stealth: ON");
            }
            else
            {
                output.AppendFormat(" *Stealth: OFF");
            }
            return output.ToString();
        }
    }
}
