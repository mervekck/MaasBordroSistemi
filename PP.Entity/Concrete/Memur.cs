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
        public override decimal MaasHesapla(decimal saatlikUcret, int calismaSaati)
        {
            if (saatlikUcret <= 500)
            {
                throw new Exception("Saatlik ücret 500 TL den düşük olmamalı.");
            }
            SaatlikUcret = 500 * ((int)Derece + ( (int)Derece * (5/100))); //saatlik ücret min 500 tl olarak belirlenir ve dereceye göre derecenin yüzde 5 i kadar derece artar ve saatlik ücreti arttır

            decimal Maas;

            if (calismaSaati < 181 && calismaSaati > 0)
            {
                Maas = (saatlikUcret * calismaSaati);
            }
            else if (calismaSaati > 180)
            {
                Maas = (saatlikUcret * 180) + ( (saatlikUcret * 1.5m) * (calismaSaati - 180) ) ;
            }
            else
            {
                throw new Exception("Lütfen çalışma saati giriniz.");
            }
            return Maas;
        }
    }
}
