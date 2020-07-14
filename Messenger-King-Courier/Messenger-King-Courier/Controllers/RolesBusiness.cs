using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Messenger_King_Courier.Model;
using Messenger_King_Courier.Models;
using Messenger_King_Courier.ViewModels;

namespace Messenger_King_Courier.BusinessLogic
{
    public class RolesBusiness
    {
        ApplicationDbContext con = new ApplicationDbContext();
        private RoleManager<ApplicationRole> RoleManager { get; set; }
        private UserManager<ApplicationUser> UserManager { get; set; }

        public RolesBusiness()
        {
            RoleManager = new RoleManager<ApplicationRole>(store: new RoleStore<ApplicationRole>(context: new ApplicationDbContext()));
            UserManager = new UserManager<ApplicationUser>(store: new UserStore<ApplicationUser>(context: new ApplicationDbContext()));
        }

        public bool RoleExists(string name)
        {
            return RoleManager.RoleExists(roleName: name);
        }

        public bool CreateRole(string name)
        {
            var idResult = RoleManager.Create(role: new ApplicationRole(roleName: name));
            return idResult.Succeeded;
        }

        public List<RolesView> AllRoles()
        {
            var list = con.Roles;

            var view = new List<RolesView>();

            foreach (var role in list)
            {
                view.Add(item: new RolesView()
                {
                    RoleId = role.Id,
                    Name = role.Name
                });
            }

            return view;
        }

        public void AddUserToRole(string userid, string rolename)
        {
            var exists = FindRoleAndCreate(role: rolename);
            UserManager.AddToRole(userId: userid, role: rolename);
        }

        public List<UsersView> UsersInRole(string roleId)
        {
          
            var role = con.Roles.ToList().Where(predicate: x => x.Name == roleId).FirstOrDefault();

            var list = con.UserInRole.ToList().Where(predicate: x => x.RoleId == role.Id).ToList();

            List<UsersView> ulist = new List<UsersView>();

            foreach (var uir in list)
            {
                var user = UserManager.Users.ToList().Where(predicate: x => x.Id == uir.UserId).FirstOrDefault();

                ulist.Add(item: new UsersView
                {
                    UserId = user.Id,
                    Name = user.Email
                });
            }

            return ulist;
        }

        public RolesView FindRoleById(string id)
        {
            var role = RoleManager.FindById(roleId: id);

            RolesView view = new RolesView();

            view.RoleId = role.Id;
            view.Name = role.Name;

            return view;
        }

        public List<RolesView> RolesForThisUser(string userid)
        {
            List<RolesView> rolesList = new List<RolesView>();

            foreach (var userrole in con.UserInRole)
            {
                if (userid == userrole.UserId)
                {
                    var role = FindRoleById(id: userrole.RoleId);

                    rolesList.Add(item: new RolesView()
                    {
                        RoleId = role.RoleId,
                        Name = role.Name
                    });
                }
            }

            return rolesList;
        }

        public void RemoveFromRole(string userid, string role)
        {
            UserManager.RemoveFromRole(userId: userid, role: role);
            con.SaveChanges();
        }

        public string UnassignFromRole(string userid, string role)
        {
            string feed = "";

            var r = con.Roles.ToList().Where(predicate: x => x.Name.Contains(value: role)).FirstOrDefault();

            try
            {
                var uir = con.UserInRole.ToList().Where(predicate: x => x.RoleId == r.Id && x.UserId == userid).FirstOrDefault();

                if (uir != null)
                {
                    con.UserInRole.Remove(entity: uir);
                    con.SaveChanges();

                    feed = "User successfully unassigned the role.";
                }

                else
                {
                    feed = "User not found!";
                }
            }

            catch (Exception x)
            {
                feed = "Please try again.";
            }

            return feed;
        }

        public bool FindRoleAndCreate(string role)
        {
            var exists = RoleManager.FindByName(roleName: role);

            if (exists != null)
            {
                return true;
            }

            else
            {
                CreateRole(name: role);
                return false;
            }
        }

        public bool IsUserInRole(string userid, string roleid)
        {
            return UserManager.IsInRole(userId: userid, role: roleid);
        }
    }
}