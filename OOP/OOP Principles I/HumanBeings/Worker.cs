using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanBeings
{
    class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public int WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set { workHoursPerDay = value; }
        }


        public int WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }

        public decimal MoneyPerHour()
        {
            return weekSalary / workHoursPerDay * 5;
        }
    }
}
