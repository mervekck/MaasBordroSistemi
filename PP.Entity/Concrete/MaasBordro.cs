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
        public string PersonelIsmi { get; set; }
        public int CalismaSaati { get; set; }
        public decimal AnaOdeme { get; set; }
        public decimal Mesai { get; set; }
        public decimal ToplamOdeme { get; set; }
        public string Ay { get; set; }
        public MaasBordro(string ay)
        {
            Ay = ay;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static void Kaydet(List<MaasBordro> maasBordroListesi, string dosyaAdi)
        {
            string json = JsonConvert.SerializeObject(maasBordroListesi, Formatting.Indented);
            File.WriteAllText(dosyaAdi, json);
        }
    }
}
