using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.HealthPoints = 0;
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Machine name can't be null");
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Machine name can't be empty string or sequence of white spaces:");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot can't be null");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Attack points can't be null");
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attack points can't be negative");
                }
                else
                {
                    this.attackPoints = value;
                }
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Defense points can't be null");
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defense points can't be negative");
                }
                else
                {
                    this.defensePoints = value;
                }
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(string target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("Target can't be null");
            }
            else if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentOutOfRangeException("Target can't be empty string or sequence of white spaces");
            }
            else
            {
                this.targets.Add(target);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("- {0}\n", this.Name);
            output.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            output.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            output.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            output.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            output.Append(" *Targets: ");
            if (targets.Count == 0)
            {
                output.AppendLine("None");
            }
            else
            {
                output.AppendLine(string.Join(", ", targets));
            }
            return output.ToString();
        }
    }
}
