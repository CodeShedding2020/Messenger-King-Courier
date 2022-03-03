using Messenger_King_Courier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger_King_Courier.BusinessLogic;
using Messenger_King_Courier.Model;
using Messenger_King_Courier.ViewModels;

namespace roles.Controllers
{
    public class RolesController : Controller
    {
        RolesBusiness rb = new RolesBusiness();
        ApplicationDbContext con = new ApplicationDbContext();


        // GET: Roles
        public ActionResult Index()
        {
            return View(rb.AllRoles());
        }



        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(string name)
        {

            if (name == "")
            {
                ViewBag.Result = "Please enter Role Name.";
            }

            else
            {
                bool found = rb.RoleExists(name);

                if (found == true)
                {
                    ViewBag.Result = "Role name " + name + " already exists.";
                }

                else
                {
                    rb.CreateRole(name);

                    ViewBag.Result = "Role created successfully.";
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

            return View();
        }



        [HttpGet]
        public ActionResult UsersInRole()
        {
            ViewBag.Roles = new SelectList(con.appRoles, "Name", "Name");

            try
            {
                ViewBag.Feed = Session["feedack"].ToString();
            }

            catch (Exception x)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult UsersInRole(string Id)
        {
            ViewBag.Roles = new SelectList(con.appRoles, "Name", "Name");

            List<UsersView> list = new List<UsersView>();

            if (Id == "")
            {
                ViewBag.Result = "Please select a role.";
                return View();
            }

            list = rb.UsersInRole(Id);


            if (list.Count == 0)
            {
                ViewBag.Result = "No users in this role.";
                return View();
            }

            ViewBag.Count = "[" + list.Count + "] Users found.";

            Session["RoleId"] = Id;
            Session["feedack"] = "";

            return View(list);
        }

        public ActionResult UnassignUsersInRole(string userId)
        {
            string roleId = Session["RoleId"].ToString();

            string feed = rb.UnassignFromRole(userId, roleId);

            Session["feedack"] = feed;

            return RedirectToAction("UsersInRole");
        }



        [HttpGet]
        public ActionResult AddUserToRole()
        {
            ViewBag.Users = new SelectList(con.Users, "Id", "Email");
            ViewBag.Roles = new SelectList(con.appRoles, "Name", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult AddUserToRole(string Id, string Name)
        {
            ViewBag.Users = new SelectList(con.Users, "Id", "Email");
            ViewBag.Roles = new SelectList(con.appRoles, "Name", "Name");

            if (Id != "" && Name != null)
            {
                if (rb.IsUserInRole(Id, Name) == false)
                {
                    rb.AddUserToRole(Id, Name);
                    ViewBag.Result = "User successfully assigned a role!";
                }

                else
                {
                    ViewBag.Result = "User is already in selected Role!";
                }
            }

            else
            {
                ViewBag.Result = "Please select Username and Rolename!";
            }

            return View();
        }



        [HttpGet]
        public ActionResult RolesForThisUser()
        {
            ViewBag.Users = new SelectList(con.Users, "Id", "Email");

            try
            {
                ViewBag.Feed = Session["feed"].ToString();
            }

            catch (Exception c)
            {

            }

            return View();
        }

        [HttpPost]
        public ActionResult RolesForThisUser(string Id)
        {
            ViewBag.Users = new SelectList(con.Users, "Id", "Email");

            Session["UserId"] = Id;

            List<RolesView> roleslist = rb.RolesForThisUser(Id);

            if (roleslist == null)
            {
                ViewBag.Result = "This User isn't assigned any Role!";
                return View();
            }

            ViewBag.Count = "[" + roleslist.Count + "] Role(s) found!";

            return View(roleslist);
        }



        public ActionResult RemoveFromRole(string id)
        {
            string userid = Session["UserId"].ToString();

            string feed = "";

            try
            {
                if (userid != null && id != null)
                {
                    feed = rb.UnassignFromRole(userid, id);
                }
            }

            catch (Exception x)
            {
                ViewBag.Result = "Please select User.";
            }

            Session["feed"] = feed;


            return RedirectToAction("RolesForThisUser");
        }
    }
}