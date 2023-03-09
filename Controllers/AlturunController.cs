using GoraYazilim.Business;
using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess.Models;
using GoraYazilim.Entity;
using GoraYazilim.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoraYazilim.Controllers
{
    public class AlturunController : Controller
    {
        private readonly IAlturunBc alturunBc;

        public AlturunController(IAlturunBc alturunBc)
        {
            this.alturunBc = alturunBc;
        }

        public async Task<IActionResult> Index()
        {
          
            return View(await alturunBc.GetAll());
        }

        public async Task<IActionResult> GetById(int id)
        {

            return View(await alturunBc.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(DtoAltUrun alturun)
        {
           
            await alturunBc.Add(alturun);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await alturunBc.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            var data = await alturunBc.Find(id);
            return View(data);
        }

        public async Task<IActionResult> Update(DtoAltUrun alturun)
        {
            await alturunBc.Update(alturun);

            return RedirectToAction("Index");
        }
    }
}
