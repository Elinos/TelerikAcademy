using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
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
                    throw new ArgumentNullException("Pilot name can't be null"); 
                }
                else if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Pilot name can't be empty string or sequence of white spaces");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine can't be null");
            }
            else
            {
                this.machines.Add(machine);
            }
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} - ", this.Name);
            if (machines.Count == 0)
            {
                output.Append("no machines");
            }
            else if(machines.Count == 1)
            {
                output.AppendLine("1 machine");
                foreach (var machine in machines)
                {
                    output.Append(machine.ToString());
                }
            }
            else
            {
                output.AppendFormat("{0} machines\n", machines.Count);
                var orderedMachienes = machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);
                output.Append(String.Join("\n", orderedMachienes));
            }
            return output.ToString();
        }
    }
}
