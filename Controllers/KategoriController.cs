using GoraYazilim.Business.Interface;
using GoraYazilim.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GoraYazilim.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriBc kategoriBc;

        public KategoriController(IKategoriBc kategoriBc)
        {
            this.kategoriBc = kategoriBc;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.kategoriBc.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(DtoKategori kategori)
        {
            await kategoriBc.Add(kategori);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await kategoriBc.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            var data = await kategoriBc.Find(id);
            return View(data);
        }

        public async Task<IActionResult> Update(DtoKategori kategori)
        {
            await kategoriBc.Update(kategori);

            return RedirectToAction("Index");
        }

    }
}
