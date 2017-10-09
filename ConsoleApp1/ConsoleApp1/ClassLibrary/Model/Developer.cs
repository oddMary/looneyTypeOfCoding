﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DataAccess.Models
{
    [Serializable]    
    public class Developer : Worker
    {
        public string DevLang { get; set; }
        public string Experience { get; set; }
        public string Level { get; set; }
        
        public Developer()
        {
        }

        public Developer(string firstName, string lastName, EnumsForModels.TypeOfSex sex, string appointment, string date, 
                                                   int salary, string devLang, string experience, string level) 
                                                   : base(firstName, lastName, sex, appointment, date, salary)
        {
            base._id = Guid.NewGuid();
            base.FirstName = firstName;
            base.LastName = lastName;
            base.Sex = sex;
            base.Appointment = appointment;
            base.Date = date;
            base.Salary = salary;
            this.DevLang = devLang;
            this.Experience = experience;
            this.Level = level;
        }

        /// <summary>
        /// Show all properties of worker in one string
        /// </summary>
        /// <returns>The string, contains properties of worker</returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} ", FirstName, LastName, Sex, Appointment, Date, Salary,
                DevLang, Experience, Level);
        }
    }
}
