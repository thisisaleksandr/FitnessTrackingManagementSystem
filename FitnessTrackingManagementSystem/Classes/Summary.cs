using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingManagementSystem.Classes
{
    public abstract class Summary
    {
        //public User _currentUser;
        public int CaloriesBurned { get; set;}
        public int CaloriesConsumed { get; set;}
        public int CalculatedNet { get; set; }
        public DateTime TodayDate { get; set; }

        public abstract void UpdateData(User currentUser);

    }
}
