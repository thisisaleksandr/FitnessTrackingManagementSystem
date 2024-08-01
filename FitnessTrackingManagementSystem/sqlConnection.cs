using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingManagementSystem
{
    public class sqlConnectionString
    {
        // SQL connection string. I use this string in other classes to connect to the database
        public static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\fitnessManager.mdf;Integrated Security = True";
    }
}
