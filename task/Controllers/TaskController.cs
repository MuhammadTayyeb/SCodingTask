using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task.Models;

namespace task.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
   
        public JsonResult Get_AllTask()
        {
            using (TaskEntities1 Obj = new TaskEntities1())
            {
                List<Task> task= Obj.Tasks.ToList();
                return Json(task, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get_TaskById(string Id)
        {
            using (TaskEntities1 Obj = new TaskEntities1())
            {
                int tId = int.Parse(Id);
                return Json(Obj.Tasks.Find(tId), JsonRequestBehavior.AllowGet);
            }
        }
        public string Insert_task(Task task)
        {
            if (task != null)
            {
                using (TaskEntities1 Obj = new TaskEntities1())
                {
                    Obj.Tasks.Add(task);
                    Obj.SaveChanges();
                    return "Task Added Successfully";
                }
            }
            else
            {
                return "Task Not Inserted! Try Again";
            }
        }
        public string Delete_task(Task task)
        {
            if (task != null)
            {
                using (TaskEntities1 Obj = new TaskEntities1())
                {
                    var tk = Obj.Entry(task);
                    if (tk.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Tasks.Attach(task);
                        Obj.Tasks.Remove(task);
                    }
                    Obj.SaveChanges();
                    return "Task Deleted Successfully";
                }
            }
            else
            {
                return "Task Not Deleted! Try Again";
            }
        }
        public string Update_task(Task task)
        {
            if (task != null)
            {
                using (TaskEntities1 Obj = new TaskEntities1())
                {
                    var tk = Obj.Entry(task);
                    Task tkObj = Obj.Tasks.Where(x => x.id == task.id).First();
                    tkObj.dateCreated = task.dateCreated;
                    tkObj.dateUpdated = task.dateUpdated;
                    tkObj.description = task.description;
                    tkObj.name = task.name;
                    Obj.SaveChanges();
                    return "Task Updated Successfully";
                }
            }
            else
            {
                return "Task Not Updated! Try Again";
            }
        }
    }
}
