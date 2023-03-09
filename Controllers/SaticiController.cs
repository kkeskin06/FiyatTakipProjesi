using GoraYazilim.Business;
using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess.Models;
using GoraYazilim.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GoraYazilim.Controllers
{
    public class SaticiController : Controller
    {
        private readonly ISaticiBc saticiBc;

        public SaticiController(ISaticiBc saticiBc)
        {
            this.saticiBc = saticiBc;
        }

        public async Task<IActionResult> Index()
        {
            return View(await saticiBc.GetAll());
        }

        public async Task<IActionResult> GetById(int id)
        {
            return View(await saticiBc.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(DtoSatici satici)
        {
            await saticiBc.Add(satici);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await saticiBc.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            var data = await saticiBc.Find(id);
            return View(data);
        }

        public async Task<IActionResult> Update(DtoSatici satici)
        {
            await saticiBc.Update(satici);

            return RedirectToAction("Index");
        }
    }
}
