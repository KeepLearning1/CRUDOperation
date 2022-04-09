using CognineCompany.DataLayer;
using CognineCompany.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace CognineCompany.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext ctx = new EmployeeContext();
        
        public ActionResult Index()
        {
            return View(ctx.Employees.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            ctx.Employees.Add(employee);
            dynamic a = ctx.SaveChanges();
            if(a>0)
            {
                ViewBag.CreateMessage=("<script> alert('Data Saved..')</script>");

                return RedirectToAction("Index");
            }
           else
            {
                ViewBag.CreateMessage=("<script> alert('Data NotSaved..')</script>");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = ctx.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            ctx.Entry(employee).State=EntityState.Modified;
            dynamic a = ctx.SaveChanges();
            if (a > 0)
            {
                ViewBag.UpdateMessage = ("<script> alert('Data Updated..')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script> alert('Data NotUpdated..')</script>");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var row = ctx.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }


        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            ctx.Entry(employee).State = EntityState.Deleted;
            dynamic a = ctx.SaveChanges();
            if (a > 0)
            {
                ViewBag.UpdateMessage = ("<script> alert('Data Deleted..')</script>");
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script> alert('Data NotDeleted..')</script>");
            }
            return View();
        }



        public ActionResult Details(int id)
        {
            var row = ctx.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

      
    }
}