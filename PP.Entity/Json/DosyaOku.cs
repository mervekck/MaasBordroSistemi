using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            List<Personel> personelListesi = new List<Personel>();

            //personel abstract olduğu için json.deseriliaze yapılamaz bu yüzden memur ve yönetici diye ayırmak için jarray kullandım
            JArray jArray = JArray.Parse(json);

            foreach (JObject jObject in jArray)
            {
                string tip = jObject.Value<string>("Tip");
                if (tip == "Yonetici")
                {
                    Yonetici yonetici = jObject.ToObject<Yonetici>();
                    personelListesi.Add(yonetici);
                }
                else if (tip == "Memur")
                {
                    Memur memur = jObject.ToObject<Memur>();
                    personelListesi.Add(memur);
                }
            }

            return personelListesi;
        }
    }
}
