﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using System.Threading.Tasks;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")] //markalara sadece admin erişebilir

    public class UsersController : Controller
    {

        private readonly IUserService _service;
        private readonly IService<Rol> _serviceRol;


        public UsersController(IUserService service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }

        // GET: UsersController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetCustomList();
            return View(model);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Kullanici kullanici)
        {
            if ( ModelState.IsValid)
            {
                try
                {
                   await _service.AddAsync(kullanici);
                   await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Kullanıcı eklenirken hata oluştu.");
                }
            }

            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");

            return View(kullanici);

        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");

            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Kullanıcı eklenirken hata oluştu.");
                }
            }

            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");

            return View(kullanici);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kullanici kullanici)
        {
            try
            {
                _service.Delete(kullanici);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
