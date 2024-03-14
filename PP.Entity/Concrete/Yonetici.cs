using PP.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity.Concrete
{
    public class Yonetici : Personel
    {
        public decimal Bonus { get; set; }
        public override decimal MaasHesapla(decimal saatlikUcret, int calismaSaati)
        {
            decimal Maas;

            if (saatlikUcret < 500)
            {
                throw new Exception("Yoneticilerin saatlik ücreti 500 TL'den az olamaz.");
            }
            if (Bonus < 0)
            {
                throw new Exception("Yoneticilerin Bonus olarak ek ücreti olmalıdır");
            }

            Maas = (saatlikUcret * calismaSaati)+Bonus;
            return Maas;
        }
    }
}
