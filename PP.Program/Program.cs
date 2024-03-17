// See https://aka.ms/new-console-template for more information
using PP.Entity.Abstract;
using PP.Entity.Concrete;
using PP.Entity.Enums;
using PP.Entity.Json;


internal class Program
{
    private static void Main(string[] args)
    {
        //DosyaOku
        var personelListesi = DosyaOku.PersonelListesi("personel.json");
        List<MaasBordro> maasBordroListesi = new List<MaasBordro>();

        foreach (var personel in personelListesi)
        {
            Console.WriteLine($"Personel Adı: {personel.Ad} {personel.Soyad}");
            Console.WriteLine($"Unvanı: {personel.Tip}");

            decimal maas = 0;
            decimal mesai = 0;
            int calismaSaati = 0;
            if (personel.Tip == "Yonetici")
            {
                if (personel is Yonetici)
                {
                    var yonetici = (Yonetici)personel;
                    Console.Write("Yöneticinin Çalışma Saati: ");
                    calismaSaati = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Yöneticinin Saatlik Ücreti: ");
                    decimal saatlikUcret = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Yöneticinin Bonus Ücreti: ");
                    decimal bonus = Convert.ToDecimal(Console.ReadLine());
                    maas = yonetici.MaasHesapla(saatlikUcret, calismaSaati, bonus);
                    mesai = bonus;
                }
                
            }
            else if (personel.Tip == "Memur")
            {
                if (personel is Memur)
                {
                    var memur = (Memur)personel;
                    Console.Write("Memurun Çalışma Saati: ");
                    calismaSaati = Convert.ToInt32(Console.ReadLine());
                    decimal bonus = 0;
                    decimal saatlikUcret = memur.MemurSaatlikUcretHesapla();
                    maas = memur.MaasHesapla(saatlikUcret, calismaSaati, bonus);
                    if (calismaSaati > 180)
                    {
                        mesai = (calismaSaati - 180) * saatlikUcret * 1.5m;
                    }
                }
            }
            else
            {
                Console.Write("Tipi düzeltiniz ");
            }
            DateTime simdikiTarih = DateTime.Now;
            string ay = simdikiTarih.ToString("MMMM yyyy").ToUpper();
            var maasBordro = new MaasBordro(ay)
            {
                PersonelIsmi = $"{personel.Ad} {personel.Soyad}",
                CalismaSaati = calismaSaati,
                AnaOdeme = maas,
                Mesai = mesai,
                ToplamOdeme = maas + mesai
            };

            maasBordroListesi.Add(maasBordro);
            Console.WriteLine($"Maaş: {maas:C}\n");
        }
        MaasBordro.Kaydet(maasBordroListesi, "maasbordro.json");

        Console.WriteLine("MaasBordro.json Dosyasındaki Bilgiler:");
        foreach (var bordro in maasBordroListesi)
        {
            Console.WriteLine($"Personel Adı: {bordro.PersonelIsmi}");
            Console.WriteLine($"Çalışma Saati: {bordro.CalismaSaati}");
            Console.WriteLine($"Ana Ödeme: {bordro.AnaOdeme:C}");
            Console.WriteLine($"Mesai: {bordro.Mesai:C}");
            Console.WriteLine($"Toplam Ödeme: {bordro.ToplamOdeme:C}");
            Console.WriteLine();
        }
        Console.WriteLine("MaasBordro.json Dosyasındaki 150 Saatten Az Çalışan Bilgileri:");
        foreach (var bordro in maasBordroListesi)
        {
            if (bordro.CalismaSaati < 150)
            {
                Console.WriteLine($"Personel Adı: {bordro.PersonelIsmi}");
                Console.WriteLine($"Çalışma Saati: {bordro.CalismaSaati}");
                Console.WriteLine($"Ana Ödeme: {bordro.AnaOdeme:C}");
                Console.WriteLine($"Mesai: {bordro.Mesai:C}");
                Console.WriteLine($"Toplam Ödeme: {bordro.ToplamOdeme:C}");
                Console.WriteLine();
            }
        }
    }
    

}