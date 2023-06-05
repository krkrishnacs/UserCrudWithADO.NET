using eDominerUser.Models;
using eDominerUser.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace eDominerUser.Controllers
{
    public class eDominerUsersController : Controller
    {
        eDominerUserRepo dominerUserRepo = new eDominerUserRepo();
        // GET: eDominerUsers
        [HttpGet]
        public ActionResult UserAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(eDominerUserModel eDominer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eDominerUserRepo eDominerUser = new eDominerUserRepo();

                    if (eDominerUser.AddUser(eDominer))
                    {
                        ViewBag.Message = "User Added successfully";
                        ModelState.Clear();
                    }
                    return View();
                }
                return RedirectToAction(nameof(GetAllEmpDetails));
            }
            catch
            {
                return View();
            }

            //return View();
        }



        [HttpGet]
        public ActionResult GetAllEmpDetails()
        {
            ModelState.Clear();
            var list = dominerUserRepo.GetAllRecod();
            if (list.Count == 0)
            {
                TempData["alertMessage"] = "Currently Data Table has  not Avaiable Data";
            }
            //else
            //{
            //    if (string.IsNullOrEmpty(Searchvalue))
            //    {
            //        ViewBag["ms"] = "This User is Not Avilable In the DataBase!";
            //        return View(list);
            //    }
            //    //else
            //    //{
            //    //    if (Searchvalue.ToLower() == "Searchvalue")

            //    //    {
            //    //        var search = list.Where(p => p.Name.ToLower().Contains(Searchvalue.ToLower()));
            //    //        return View(search);
            //    //    }
            //    //}
            //}
            return View(list);
        }


        [HttpGet]
        public ActionResult EditEmpDetails(int Id)
        {
            eDominerUserRepo eDominerUser = new eDominerUserRepo();

            var uselist = eDominerUser.GetUserById(Id).FirstOrDefault();
            if (uselist == null)
            {
                return RedirectToAction("GetAllEmpDetails");
            }
            return View(uselist);

        }


        [HttpPost, ActionName("EditEmpDetails")]
        public ActionResult EditEmpDetails(eDominerUserModel dominerUserModel)
        {
            try
            {
                eDominerUserRepo eDominerUser = new eDominerUserRepo();
                eDominerUser.UpdateUser(dominerUserModel);

                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Deleted(int Id)
        {
            try
            {
                eDominerUserRepo eDominerUserRepo = new eDominerUserRepo();
                if (eDominerUserRepo.DeleteEmployee(Id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult StateList(int StateId)
        {
            eDominerUserRepo eDominerUser = new eDominerUserRepo();
            var uselist = eDominerUser.GetState(StateId).FirstOrDefault();
            if (uselist == null)
            {
                return RedirectToAction("GetAllEmpDetails");
            }
            return View(uselist);

        }


    }
}