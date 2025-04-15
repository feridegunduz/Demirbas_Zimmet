using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using System.Threading.Tasks;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class KategoriController : Controller
    {
        private readonly IService<Kategori> _service;

        public KategoriController(IService<Kategori> service)
        {
            _service = service;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            var kategoriler = await _service.GetAllAsync();
            return View(kategoriler);
        }

        // Ekleme GET
        public IActionResult Create()
        {
            return View();
        }

        // Ekleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(kategori);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // Güncelleme GET
        public async Task<IActionResult> Edit(int id)
        {
            var kategori = await _service.FindAsync(id);
            return View(kategori);
        }

        // Güncelleme POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _service.Update(kategori);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // Silme GET
        public async Task<IActionResult> Delete(int id)
        {
            var kategori = await _service.FindAsync(id);
            return View(kategori);
        }

        // Silme POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategori = await _service.FindAsync(id);
            _service.Delete(kategori);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
