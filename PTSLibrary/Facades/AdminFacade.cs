﻿using PTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Facades
{
    public class AdminFacade : SuperFacade
    {
        private new DataAccess.AdminDAO dao;

        public AdminFacade() : base(new DataAccess.AdminDAO())
        {
            dao = (DataAccess.AdminDAO)base.dao;
        }
        //Authenticate
        public int Authenticate(string email, string password)
        {
            if (email == "" || email == "" || password == "")
            {
                throw new Exception("All fields must be filled");
            }
            return dao.Authenticate(email, password);
        }
        //Create project
        public void CreateProject(string projectName, string projectDescription, string level, int projectDuration, string github, string link)
        {
            if (projectName == null || projectDescription == "" || level == null)
            {
                throw new Exception("Please fill in all fields with * ");
            }
            dao.CreateProject(projectName, projectDescription, level, projectDuration, github, link);
        }
        //Delete project
        public void DeleteProject(int id)
        {
            dao.DeleteProject(id);
        }
        //Update project
        public void UpdateProject(string projectName, string description, string level, int duration, string github, string link, int projectID)
        {
            if (projectName == null || description == "" || level == "" || duration == 0 || link == null)
            {
                throw new Exception("Please fill in all fields with * ");
            }
            dao.UpdateProject(projectName, description, level, duration, github, link, projectID);
        }
        //General Users
        public UserModel[] GetListOfUsers()
        {
            return (dao.GetListOfUsers()).ToArray();
        }
        //Teamleaders
        public UserModel[] GetListOfTeamLeaders()
        {
            return (dao.GetListOfUsers()).ToArray();
        }
        //Create Cohort
        public void CreateCohort(DateTime startDate)
        {
            dao.CreateCohort(startDate);
        }
        //Cohort list
        public CohortModel[] GetListOfCohorts()
        {
            return (dao.GetListOfCohorts()).ToArray();
        }
        //Create task
        public void CreateTask(string task, int projectID)
        {
            if (task == null || task == "" )
            {
                throw new Exception("Missing Data");
            }
            dao.CreateTask(task, projectID);
        }
        //Create Teamleader
        public void CreateTeamleader(string firstname, string lastname, string email, string tempPwd)
        {
            if (firstname == null || firstname == "" || lastname == null || email == null || tempPwd == null)
            {
                throw new Exception("Missing Data");
            }
            dao.CreateTeamleader(firstname,lastname,email,tempPwd);
        }
        //AssignProject
        public void AssignProject(DateTime startdate, int projectID, int cohortID, int teamleaderID, int adminID)
        {
            if (startdate == null || projectID == 0 || cohortID == 0 || teamleaderID == 0)
            {
                throw new Exception("Missing Data");
            }
            dao.AsssignProject(startdate,projectID,cohortID,teamleaderID,adminID);
        }
    }
}
