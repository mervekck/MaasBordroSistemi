using Newtonsoft.Json;
using PP.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity.Concrete
{
    public class MaasBordro
    {
        public void BordroOlustur(List<Personel> personelListesi, decimal saatlikUcret, int calismaSaati)
        {
            foreach (var personel in personelListesi)
            {
                decimal maas = personel.MaasHesapla(saatlikUcret, calismaSaati);
            }
        }

        public List<Personel> AzCalisanRaporu(List<Personel> personelListesi, int calismaSaati)
        {
            List<Personel> azCalisanlar = new List<Personel>();
            foreach (var personel in personelListesi)
            {
                if (calismaSaati < 150)
                {
                    azCalisanlar.Add(personel);
                }
            }
            return azCalisanlar;
        }

    }
}
