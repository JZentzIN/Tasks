using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        private static string _userName = "Ryan";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetUserDetails()
        {
            return Json(UserName);
        }

        public JsonResult GetAdditionalTasks()
        {
            //TODO: get list from database.  for now, just hardcode list of tasks
            List<Task> taskList = new List<Task>();
            Task task = new Task();
            task.id = 1;
            task.dueDate = DateTime.Now.AddDays(-1);
            task.dueDateString = task.dueDate.ToString("MM/dd/yyyy");
            task.complete = true;
            task.name = "Make Job Posting";
            taskList.Add(task);

            task = new Task();
            task.id = 2;
            task.dueDate = DateTime.Now.AddDays(-1);
            task.dueDateString = task.dueDate.ToString("MM/dd/yyyy");
            task.complete = true;
            task.name = "Collect Resumes";
            taskList.Add(task);

            task = new Task();
            task.id = 3;
            task.dueDate = DateTime.Now;
            task.dueDateString = task.dueDate.ToString("MM/dd/yyyy");
            task.complete = false;
            task.name = "Interview Candidates";
            taskList.Add(task);

            task = new Task();
            task.id = 4;
            task.dueDate = DateTime.Now.AddDays(1);
            task.dueDateString = task.dueDate.ToString("MM/dd/yyyy");
            task.complete = false;
            task.name = "Hire the most qualified Candidate (Jessica Zentz)";
            taskList.Add(task);

            return Json(JsonConvert.SerializeObject(taskList));
        }

        public void Save(string id, string dueDate, string task, bool complete)
        {
            //TODO: this is where I would save to the database
        }
        public void Delete(string id)
        {
            //TODO: this is where I would save to the database
            if (!String.IsNullOrEmpty(id))
            {
                //delete
            }
           
        }

        class Task
        {
            public int id;
            public DateTime dueDate;
            public string dueDateString;
            public Boolean complete;
            public String name;
             
        }
    }
}
