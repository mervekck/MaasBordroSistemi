using Newtonsoft.Json;
using PP.Entity.Abstract;
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

            List<Personel> personelListesi = JsonConvert.DeserializeObject<List<Personel>>(json);

            return personelListesi;
        }
    }
}
