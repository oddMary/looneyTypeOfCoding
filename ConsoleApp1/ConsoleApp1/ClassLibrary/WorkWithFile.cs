﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using ClassLibrary.Models;

namespace ClassLibrary
{
   public class WorkWithFile
    {
        public WorkWithFile()
        {
        }
        
        /// <summary>
        /// Write information to file
        /// </summary>
        /// <param name="people">The list of all workers</param>
        public void WriteToFile(List<Worker> people)
        {
            Repository repository = new Repository();
            string textToWriteInAFile = "";
           
            foreach (var person in people)
            {
                if (repository.IsDeveloper(person))
                {
                    textToWriteInAFile += person.ToString() + "\r\n";
                }
                else
                {
                    textToWriteInAFile += person.ToString() + "\r\n";
                }
            }
            File.WriteAllText(Config._filePath, textToWriteInAFile);
            Console.WriteLine("Recording data was successful.");
        }

        /// <summary>
        /// Read information from file
        /// </summary>
        /// <param name="people">The list of all workers</param>
        public virtual void ReadFromFile(List<Worker> people)
        {
            people.Clear();

            foreach (var line in File.ReadLines(Config._filePath))
            {
                string[] names = line.Split(' ');

                int id = int.Parse(names[0]);
                string firstName = names[1];
                string lastName = names[2];
                EnumsForModels.TypeOfSex sex = (EnumsForModels.TypeOfSex)Enum.Parse(typeof(EnumsForModels.TypeOfSex), names[3]);
                string appointment = names[4];
                string date = names[5];
                int salary = int.Parse(names[6]);

                if(names.Length == 10)
                {
                    string devLang = names[7];
                    string experience = names[8];
                    string level = names[9];
                    Developer developer = new Developer(id, firstName, lastName, sex, appointment, date, salary, devLang, experience, level);
                    people.Add(developer);
                }
                if(names.Length == 8)
                {
                    int yearsInService = int.Parse(names[7]);
                    OfficeWorker office = new OfficeWorker(id, firstName, lastName, sex, appointment, date, salary, yearsInService);
                    people.Add(office);
                }
            }            
            Console.WriteLine("Reading data was successful.");
        }

        /// <summary>
        /// Add information about worker to file in string format
        /// </summary>
        /// <param name="obj">Oblect with properties of worker</param>
        public void AddPersonToFile(Object obj)
        {
            Repository rep = new Repository();

            int index = rep.AddIndexNumber();
            int stringCount = CountStringsInFile();
            string textToWriteInAFile = "";
            if (stringCount != 0)
            {
                textToWriteInAFile += System.Environment.NewLine;
            }
            textToWriteInAFile += obj.ToString();
            File.AppendAllText(Config._filePath, textToWriteInAFile);
            Console.WriteLine("Recording data was successful.");
        }

        /// <summary>
        /// Count strings in file
        /// </summary>
        /// <returns>Number of strings</returns>
        public int CountStringsInFile()
        {
            int stringCount = File.ReadAllLines(Config._filePath).Length;
            return stringCount;
        }
    }
}
