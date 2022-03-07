using DataWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApplication.Controllers
{
    
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult AddUserToRole()
        {
            ViewData["Roles"] = new SelectList(_roleManager.Roles, "Name", "Name");
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string role, string user)
        {
            var _user = await _userManager.FindByIdAsync(user);
            IdentityResult result = await _userManager.AddToRoleAsync(_user, role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewRole(string id)
        {
            var users = await _userManager.GetUsersInRoleAsync(id);
            ViewBag.role = id;
            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var member = await _userManager.FindByIdAsync(id);

            IdentityResult result = await _userManager.DeleteAsync(member);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
