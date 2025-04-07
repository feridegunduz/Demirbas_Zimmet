using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")] //markalara sadece admin erişebilir

    public class ZimmetController : Controller
    {


        private readonly IService<Zimmet> _service;
        private  readonly IService<Demirbas> _serviceDemirbas;
        private readonly IService<Kullanan> _serviceOwners;


        public ZimmetController(IService<Zimmet> service, IService<Demirbas> serviceDemirbas, IService<Kullanan> serviceOwners)
        {
            _service = service;
            _serviceDemirbas = serviceDemirbas;
            _serviceOwners = serviceOwners;
        }

        // GET: ZimmetController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: ZimmetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ZimmetController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            ViewBag.MusteriId = new SelectList(await _serviceOwners.GetAllAsync(), "Id", "Adi");

            //data value field ve data text field

            return View();
        }

        // POST: ZimmetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Zimmet zimmet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(zimmet);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Kullanan eklenirken hata oluştu.");
                }
            }

            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            ViewBag.MusteriId = new SelectList(await _serviceOwners.GetAllAsync(), "Id", "Adi");

            return View(zimmet);
        }

        // GET: ZimmetController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            ViewBag.MusteriId = new SelectList(await _serviceOwners.GetAllAsync(), "Id", "Adi");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ZimmetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Zimmet zimmet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(zimmet);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Kullanan eklenirken hata oluştu.");
                }
            }

            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            ViewBag.MusteriId = new SelectList(await _serviceOwners.GetAllAsync(), "Id", "Adi");

            return View(zimmet);
        }

        // GET: ZimmetController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ZimmetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Zimmet zimmet)
        {
            try
            {
                _service.Delete(zimmet);
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
