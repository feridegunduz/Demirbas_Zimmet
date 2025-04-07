using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.DataProtection.KeyManagement;


namespace OtoServisSatis.WebUI.Controllers
{
    public class DmrbsDetayController : Controller
    {

        private readonly IDmrbsService _serviceDemirbas;


        public DmrbsDetayController(IDmrbsService serviceDemirbas)
        {
            _serviceDemirbas = serviceDemirbas;
        }


        public async Task<IActionResult> IndexAsync(int Id)
        {
            var model = await _serviceDemirbas.GetCustomDmrbs(Id);

            return View(model);
        }


        [Route("zimmetli-demirbaslar")]
        public async Task<IActionResult> List()
        {
            var model = await _serviceDemirbas.GetCustomDmrbsList(c=>c.ZimmetliMi); //zimmetli olanları listele

            return View(model);
           
        }
        
        

        public async Task<IActionResult> Ara(string q)
        {
            var model = await _serviceDemirbas.GetCustomDmrbsList(c => c.UrunTipi.Contains(q) || c.Marka.Adi.Contains(q) ); //zimmetli olanları listele

            return View(model);
        }
    }
}

