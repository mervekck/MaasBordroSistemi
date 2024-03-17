using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity.Abstract
{
    public abstract class Personel
    {
        public int PersonelNumarasi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tip { get; set; }
        public abstract decimal MaasHesapla(decimal saatlikUcret, int calismaSaati,decimal Bonus);
    }
}
