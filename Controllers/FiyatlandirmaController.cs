using GoraYazilim.Business;
using GoraYazilim.Business.Interface;
using GoraYazilim.Entity;
using GoraYazilim.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoraYazilim.Controllers
{
    public class FiyatlandirmaController : Controller
    {
        private readonly IFiyatlandirmaBc fiyatlandirmaBc;
        private readonly IUrunBc urunBc;
        private readonly ISaticiBc saticiBc;

        public FiyatlandirmaController(IFiyatlandirmaBc fiyatlandirmaBc, IUrunBc urunBc, ISaticiBc saticiBc)
        {
            this.fiyatlandirmaBc = fiyatlandirmaBc;
            this.urunBc = urunBc;
            this.saticiBc = saticiBc;
        }
        public async Task<IActionResult> Index()
        {
            return View(await fiyatlandirmaBc.GetAll());
        }

        public async Task<IActionResult> GetById(int id)
        {
            return View(await fiyatlandirmaBc.GetById(id));
        }

        public async Task<IActionResult> GetBySaticiId(int id)
        {
            var model = new FiyatlandirmaViewModel()
            {
                Fiyatlandirmalar = await fiyatlandirmaBc.GetBySaticiId(id),
               // Urunler = await urunBc.GetAll(),
                Saticilar = await saticiBc.GetAll(),
            };

            return View(model);
        }
        public IActionResult Create()
        {
            
            return View();
        }

        public async Task<IActionResult> Add(DtoFiyatlandirma fiyatlandirma)
        {
            
            await fiyatlandirmaBc.Add(fiyatlandirma);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await fiyatlandirmaBc.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            var data = await fiyatlandirmaBc.Find(id);
            return View(data);
        }

        public async Task<IActionResult> Update(DtoFiyatlandirma fiyatlandirma)
        {
            await fiyatlandirmaBc.Update(fiyatlandirma);

            return RedirectToAction("Index");
        }
    }
}
