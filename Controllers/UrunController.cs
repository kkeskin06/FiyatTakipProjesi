using GoraYazilim.Business;
using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess.Models;
using GoraYazilim.Entity;
using GoraYazilim.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoraYazilim.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunBc urunBc;
        private readonly IKategoriBc kategoriBc;
        public UrunController(IUrunBc urunBc, IKategoriBc kategoriBc)
        {
            this.urunBc = urunBc;
            this.kategoriBc = kategoriBc;
        }


        public async Task<IActionResult> Index()
        {
            var model = new UrunViewModel()
            {
                Urunler = await urunBc.GetAll(),
                Kategoriler = await kategoriBc.GetAll(),
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(DtoUrun urun)
        {
            await urunBc.Add(urun);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await urunBc.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await urunBc.Find(id);
            return View(data);
        }

        public async Task<IActionResult> Update(DtoUrun urun)
        {
            await urunBc.Update(urun);
            return RedirectToAction("Index");
        }

    }
}
