using PP.Entity.Abstract;
using PP.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity.Concrete
{
    public class Memur : Personel
    {
        public Derece Derece { get; set; }
        public decimal MemurSaatlikUcretHesapla()
        {
            return 500 * ((int)Derece + ((int)Derece * 5m / 100));
        }
        public override decimal MaasHesapla(decimal saatlikUcret, int calismaSaati, decimal Bonus)
        {

            decimal Maas=0;
            try
            {
                if (calismaSaati < 181 && calismaSaati > 0)
                {
                    Maas = (saatlikUcret * calismaSaati);
                }
                else if (calismaSaati > 180)
                {
                    Maas = (saatlikUcret * 180) + ((saatlikUcret * 1.5m) * (calismaSaati - 180));
                }
            }
            catch (Exception)
            {

                throw new Exception("Lütfen çalışma saati doğru giriniz.");
            }
            return Maas;
        }

    }
}
