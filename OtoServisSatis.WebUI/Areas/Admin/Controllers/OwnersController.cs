using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{

    [Area("Admin"), Authorize(Policy = "AdminPolicy")] //markalara sadece admin erişebilir

    public class OwnersController : Controller
    {

        private readonly IService<Kullanan> _service;
        private readonly IService<Demirbas> _serviceDemirbas;


        public OwnersController(IService<Kullanan> service, IService<Demirbas> serviceDemirbas)
        {
            _service = service;
            _serviceDemirbas = serviceDemirbas;
        }

        // GET: OwnerController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnerController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Kullanan kullanan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(kullanan);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Kullanan eklenirken hata oluştu.");
                }
            }

            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            return View(kullanan);
            
          
        }

        // GET: OwnerController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");

            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Kullanan kullanan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     _service.Update(kullanan);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu.");
                }
            }

            ViewBag.DemirbasId = new SelectList(await _serviceDemirbas.GetAllAsync(), "Id", "UrunTipi");
            return View(kullanan);
        }


        // GET: OwnerController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kullanan kullanan)
        {
            try
            {
                _service.Delete(kullanan);
                _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
