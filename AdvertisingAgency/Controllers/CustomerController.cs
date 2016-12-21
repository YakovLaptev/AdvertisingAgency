using AdvertisingAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvertisingAgency.Controllers
{
    public class CustomerController : Controller
    {
        Entities en = new Entities();

        // GET: Customer
        public ActionResult Index()
        {            
            var c = en.customers.ToList();            
            return View(c);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, customer collection)
        {
            try
            {
                // TODO: Add update logic here
                en.customers.Find(id).fio = collection.fio;
                //en.customers.Find(id).registrationDate = collection.registrationDate;
                //если нашел такой то меняет по всей базе en.customers.Find(id).email = collection.email;
                en.customers.Find(id).AspNetUser.UserName = collection.AspNetUser.UserName;
                en.customers.Find(id).AspNetUser.AspNetRole.Id = en.AspNetRoles.Where(p => p.Name == collection.AspNetUser.AspNetRole.Name).FirstOrDefault().Id;
                en.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                en.SaveChanges();
                return RedirectToAction("../Customer/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
