﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingManagementSystem.Classes
{
    public class User
    {
        private int _id;
        private string _username;     
        private int _bmr_calories;
        private int _calorie_goal;

        public int ID { get { return _id; } }
        public string Username { get { return _username; } set { _username = value; } }
        public int Bmr_calories 
        { get 
            { return _bmr_calories; } 
        set 
            {
                if (value >= 500)
                {
                _bmr_calories = value; 
                }
            } 
        }
        public int Calorie_goal { get { return _calorie_goal; } set { _calorie_goal = value; } }

        public User(int id, string user_name, int bmr_calories, int calorie_goal)
        {
            _id = id;
            Username = user_name;
            _bmr_calories = bmr_calories;
            _calorie_goal = calorie_goal;
        }

        // calculate the daily calorie needs
        // I used Harris-Benedict formula to calculate calorie needs
        public int CalculateBMR(int age, double weight, double height, bool male)
        {
            double bmr;
            if (male)
            {
                bmr = 66 + (6.23 * weight) + (12.7 * height) - (6.8 * age);
                Console.WriteLine(bmr);
            }
            else
            {
                bmr = 655 + (4.3 * weight) + (4.7 * height) - (4.7 * age);
            }
            return (int)Math.Round(1.2 * bmr, 0);
        }
    }
}
