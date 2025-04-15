using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Data.Migrations;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Utils;
using System.Threading.Tasks;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")] //markalara sadece admin erişebilir
    public class DemirbasController : Controller
    {

        private readonly IDmrbsService _service;
        private readonly IService<Marka> _serviceMarka;
        private readonly IService<Kategori> _serviceKategori;


        public DemirbasController(IDmrbsService service, IService<Marka> serviceMarka, IService<Kategori> serviceKategori)
        {
            _service = service;
            _serviceMarka = serviceMarka;
            _serviceKategori = serviceKategori;

        }


        // GET: DemirbasController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetCustomDmrbsList();
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
            ViewBag.KategoriId = new SelectList(await _serviceKategori.GetAllAsync(), "Id", "Adi");

            return View();
        }

        // POST: DemirbasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Demirbas demirbas, IFormFile Resim1, IFormFile Resim2, IFormFile Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    demirbas.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "/Img/DmBas/");
                    demirbas.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "/Img/DmBas/");
                    demirbas.Resim3 = await FileHelper.FileLoaderAsync(Resim3, "/Img/DmBas/");



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
            ViewBag.KategoriId = new SelectList(await _serviceKategori.GetAllAsync(), "Id", "Adi", demirbas.KategoriId);
            if (demirbas.FaturaTarihi > DateTime.Today)
            {
                ModelState.AddModelError("FaturaTarihi", "Fatura tarihi bugünden ileri olamaz.");
            }

            return View(demirbas);
        }

        // GET: DemirbasController/Edit/5
        public async Task<IActionResult> Edit(int id, Demirbas demirbas)
        {

            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            ViewBag.KategoriId = new SelectList(await _serviceKategori.GetAllAsync(), "Id", "Adi");

            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: DemirbasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Demirbas demirbas, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resim1 is not null)
                    {
                        demirbas.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "/Img/DmBas/");

                    }
                    if (Resim2 is not null)
                    {
                        demirbas.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "/Img/DmBas/");

                    }
                    if (Resim3 is not null)
                    {
                        demirbas.Resim3 = await FileHelper.FileLoaderAsync(Resim3, "/Img/DmBas/");

                    }


                
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
            ViewBag.KategoriId = new SelectList(await _serviceKategori.GetAllAsync(), "Id", "Adi", demirbas.KategoriId);

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
