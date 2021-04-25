using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.ENTITY.Entities;
using ResitalTurizmWEB.UI.Identity;
using ResitalTurizmWEB.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IOtelService _otelService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public AdminController(IOtelService otelService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _otelService = otelService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user!=null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);
                ViewBag.Roles = roles;
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("~/admin/user/list");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model,string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user!=null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }
            return View(model);
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }

        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();
            var userList = _userManager.Users.ToList();

            foreach (var user in userList)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonmembers;
                list.Add(user);
            }

            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { }) //null hatası almamak icin ?? new string[]{ }
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                return Redirect("/admin/role/" + model.RoleId);
            }
            return View();
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult OtelList()
        {
            return View(new OtelListViewModel()
            {
                Oteller = _otelService.GetAll()
            });
        }

        public IActionResult CreateOtel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOtel(OtelModel model)
        {
            if (ModelState.IsValid) //validasyon işlemi başarılıysa
            {
                var entity = new Otel()
                {
                    OtelAdı = model.OtelAdı,
                    Fiyat = (double)model.Fiyat,
                    OtelAdres = model.OtelAdres,
                    ImageUrl = model.ImageUrl,
                    CategoryID = model.CategoryID,
                    OtelKategorisi = model.OtelKategorisi
                };
                _otelService.Create(entity);
                //TempData["message"] = $"{entity.OtelAdı} isimli Otel eklendi.";

                var msg = new AlertMessage()
                {
                    Message = $"{entity.OtelAdı} isimli Otel eklendi.",
                    AlertType = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg); //Json formatını kullanabilmek icin newtonsoft nuget arat. Projeye yükledim.Json kullanmadıgımda Tempdata'dan serileştirme hatası aldım.
                return RedirectToAction("OtelList");
            }
            return View(model);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var entity = _otelService.GetByID((int)id); //bu aşamaya geldiysek null degildir. yani ? koymaya gerek yok.
            if (entity==null)
            {
                return NotFound();
            }
            var model = new OtelModel()
            {
                OtelID = entity.OtelID,
                OtelAdı = entity.OtelAdı,
                Fiyat = entity.Fiyat,
                OtelAdres = entity.OtelAdres,
                ImageUrl = entity.ImageUrl,
                CategoryID = entity.CategoryID,
                OtelKategorisi = entity.OtelKategorisi,
                IsApproved = entity.IsApproved

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OtelModel model, IFormFile file) /*file kısmı resim upload işlemi için*/
        {
            if (ModelState.IsValid)
            {
                var entity = _otelService.GetByID(model.OtelID);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.OtelAdı = model.OtelAdı;
                entity.Fiyat = (double)model.Fiyat;
                entity.OtelAdres = model.OtelAdres;
                entity.CategoryID = model.CategoryID;
                entity.OtelKategorisi = model.OtelKategorisi;
                entity.IsApproved = model.IsApproved;

                if (file != null)
                {
                    //entity.ImageUrl = file.FileName;
                    var extention = Path.GetExtension(file.FileName); //uzantı nedir
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\template\\img", randomName);

                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _otelService.Update(entity);
                //TempData["message"] = $"{entity.OtelAdı} isimli Otel güncellendi.";
                var msg = new AlertMessage()
                {
                    Message = $"{entity.OtelAdı} isimli Otel güncellendi.",
                    AlertType = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("OtelList");
            }
            return View(model);
           
        }

        public IActionResult DeleteOtel(int otelID)
        {
            var entity = _otelService.GetByID(otelID);
            if (entity!=null)
            {
                _otelService.Delete(entity);
            }
            //TempData["message"] = $"{entity.OtelAdı} isimli Otel güncellendi.";
            var msg = new AlertMessage()
            {
                Message = $"{entity.OtelAdı} isimli Otel silindi.",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("OtelList");
        }
    }
}
