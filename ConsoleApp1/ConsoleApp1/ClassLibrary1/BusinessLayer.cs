﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;

namespace BusinessLayer
{
    public class BusinessLayerMethods
    {
        private IRepository _repository;

        public BusinessLayerMethods(IRepository _repository)
        {
            this._repository = new XmlRepository();
        }

        /// <summary>
        /// Get one worker with some index number
        /// </summary>
        /// <param name="indexNumber">Parameter for search</param>
        /// <returns>Information of selected worker in string format</returns>
        public virtual void ShowOnePerson(int indexNumber, string xmlPath, string xsdPath)
        {
            foreach (var person in this._repository.Get("Workers/*["+ indexNumber + "]", xmlPath, xsdPath))
            {
                Console.WriteLine(person);
            }
        }

        /// <summary>
        /// Get all workers with selected appointment
        /// </summary>
        /// <param name="searchAppointment">Parameter for search</param>
        public virtual void SearchByAppointment(string searchAppointment, string xmlPath, string xsdPath)
        {
            IEnumerable<Worker> selectPeople = this._repository.Get("Workers/*[Appointment = '" + searchAppointment + "']", xmlPath, xsdPath);

            if (selectPeople.Count() > 0)
            {
                foreach (var person in selectPeople)
                {
                    Console.WriteLine(person);
                }
            }
            else
            {
                Console.WriteLine("The search returns no results.");
            }
        }

        /// <summary>
        /// Get all workers with selected name
        /// </summary>
        /// <param name="searchingName">Parameter for search</param>
        public void SearchByName(string searchingName, string xmlPath, string xsdPath)
        {
            IEnumerable<Worker> searchResult = this._repository.Get("Workers/*[Appointment = '" + searchingName + "']", xmlPath, xsdPath);

            if (searchResult.Count() > 0)
            {
                foreach (var res in searchResult)
                {
                    Console.WriteLine(res);
                }
            }
            else
            {
                Console.WriteLine("The search returns no results.");
            }
        }

        /// <summary>
        /// Count workers by appointment
        /// </summary>
        /// <param name="countAppointment">Parameter for count</param>
        /// <returns>List of appointments and employees' first name and last name holding these positions</returns>
        public string CountWorkers(string countAppointment, string xmlPath, string xsdPath)
        {
            IEnumerable<Worker> workers = this._repository.Get("Workers/*[Appointment = '" + countAppointment + "']", xmlPath, xsdPath);

            string result = string.Format("{0} : {1}", countAppointment, workers.Count());
            return result;
        }

        /// <summary>
        /// Check whether the object is a type "Developer"
        /// </summary>
        /// <param name="obj">Object for check</param>
        /// <returns>Boolean value</returns>
        public bool IsDeveloper(Object obj)
        {
            bool val = obj is Developer;
            return val;
        }
    }
}