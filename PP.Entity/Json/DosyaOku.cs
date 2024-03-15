using Newtonsoft.Json;
using PP.Entity.Abstract;
using PP.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PP.Entity.Json
{
    public static class DosyaOku
    {
        public static List<Personel> PersonelListesi(string dosyaYolu)
        {
            string json = File.ReadAllText(dosyaYolu);

            List<Yonetici> yoneticiler = JsonConvert.DeserializeObject<List<Yonetici>>(json);
            List<Memur> memurlar = JsonConvert.DeserializeObject<List<Memur>>(json);

            List<Personel> personelListesi = new List<Personel>();
            personelListesi.AddRange(yoneticiler);
            personelListesi.AddRange(memurlar);

            return personelListesi;
        }
    }
}
