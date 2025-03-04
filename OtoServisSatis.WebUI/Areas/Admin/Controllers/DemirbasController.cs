using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using System.Threading.Tasks;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DemirbasController : Controller
    {

        private readonly IService<Demirbas> _service;
        private readonly IService<Marka> _serviceMarka;

        public DemirbasController(IService<Demirbas> service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }


        // GET: DemirbasController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: DemirbasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DemirbasController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: DemirbasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Demirbas demirbas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(demirbas);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Demirbaş eklenirken hata oluştu.");
                }
            }

            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");

            return View(demirbas);
        }

        // GET: DemirbasController/Edit/5
        public async Task<IActionResult> Edit(int id, Demirbas demirbas)
        {

            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: DemirbasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Demirbas demirbas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(demirbas);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Demirbaş eklenirken hata oluştu.");
                }
            }

            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(demirbas);
        }

        // GET: DemirbasController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: DemirbasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Demirbas demirbas)
        {
            try
            {
                _service.Delete(demirbas);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
