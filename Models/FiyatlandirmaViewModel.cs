using GoraYazilim.DataAccess;
using GoraYazilim.Entity;

namespace GoraYazilim.Models
{
    public class FiyatlandirmaViewModel
    {
        public FiyatlandirmaViewModel()
        {
            Fiyatlandirmalar = new List<DtoFiyatlandirma>();
            Saticilar = new List<DtoSatici>();
            Urunler = new List<DtoUrun>();
        }

        public List<DtoFiyatlandirma> Fiyatlandirmalar { get; set; }

        public List<DtoSatici> Saticilar { get; set; }
       public List<DtoUrun> Urunler { get; set; }
    }
}
