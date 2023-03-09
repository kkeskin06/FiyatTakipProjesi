using GoraYazilim.Entity;
using Microsoft.EntityFrameworkCore;

namespace GoraYazilim.Models
{
    public class UrunViewModel
    {
        public UrunViewModel()
        {
            Kategoriler = new List<DtoKategori>();
            Urunler = new List<DtoUrun>();
        }

        public List<DtoKategori> Kategoriler { get; set; }
        public List<DtoUrun> Urunler { get; set; }

          
    }
}
