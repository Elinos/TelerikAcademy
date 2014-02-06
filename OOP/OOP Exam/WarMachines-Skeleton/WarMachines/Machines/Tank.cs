using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.defenseMode = true;
            this.DefensePoints += 30; //defenseMode
            this.AttackPoints -= 40; //defenseMode
        }

        public bool DefenseMode
        {
            get
            {
                return this.DefenseMode;
            }
        }

        public void ToggleDefenseMode()
        {
            if (defenseMode == true)
            {
                defenseMode = false;
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                defenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            if (defenseMode)
            {
                output.AppendFormat(" *Defense: ON");
            }
            else
            {
                output.AppendFormat(" *Defense: OFF");
            }
            return output.ToString();
        }
    }
}
