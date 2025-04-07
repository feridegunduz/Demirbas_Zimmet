using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Models;

namespace OtoServisSatis.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _service;
        private readonly IDmrbsService _serviceDemirbas;


        public HomeController(IService<Slider> service, IDmrbsService serviceDemirbas)
        {
            _service = service;
            _serviceDemirbas = serviceDemirbas;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel
                { 

                Sliders = await _service.GetAllAsync(),
                Demirbaslar = await _serviceDemirbas.GetCustomDmrbsList()

            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
