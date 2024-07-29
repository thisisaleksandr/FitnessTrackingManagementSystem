using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingManagementSystem.Classes
{
    abstract class DataLog<T> where T : DataLog<T>
    {
        public abstract int ID {  get; set; }
        public abstract string Date {  get; set; }

        public User _current_user;

        public DataLog(User curr_user)
        {
            _current_user = curr_user;
        }

        public abstract List<T> getLastEntries();
    }
}
