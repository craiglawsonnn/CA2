using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    //creating the enum
    public enum TypeOfActivity { Air, Water, Land }
    public class Activity :IComparable
    {
        //creating the attributes for the class
        #region Attributes
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }

        private string _description;

        public TypeOfActivity ActivityType { get; set; }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
#endregion

        //creatting the constructor
        public Activity(string name, decimal cost, DateTime date, string desc, TypeOfActivity activityType)
        {
            Name = name;
            Cost = cost;
            ActivityDate = date;
            Description = desc;
            ActivityType = activityType;
        }

        //making an icomparable method but wasnt sure how to implement without breaking the rest of my code
        int IComparable.CompareTo(object obj)
        {
            Activity that = (Activity)obj;
            return ActivityDate.CompareTo(that.ActivityDate);
        }

        //un-used description method 
        /*public string Desc()
        {
            return $"{Description}";
        }*/

        //Overriding the default ToString
        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

    }
}
