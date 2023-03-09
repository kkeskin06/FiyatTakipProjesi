using GoraYazilim.Entity;

namespace GoraYazilim.Models
{
    public class AlturunViewModel
    {
        public AlturunViewModel()
        {
            Alturunler = new List<DtoAltUrun>();
            Urunler = new List<DtoUrun>();
        }

        public List<DtoAltUrun> Alturunler { get; set; }
        public List<DtoUrun> Urunler { get; set; }
       
    }
}
