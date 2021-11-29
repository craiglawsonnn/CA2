using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Activity
    {
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public enum TypeOfActivity { Air, Water, Land }

        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

    }
}
