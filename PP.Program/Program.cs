// See https://aka.ms/new-console-template for more information
using PP.Entity.Abstract;
using PP.Entity.Concrete;
using PP.Entity.Json;


internal class Program
{
    private static void Main(string[] args)
    {
        //DosyaOku
        var personelListesi = DosyaOku.PersonelListesi("personel.json");

        foreach (var personel in personelListesi)
        {
            Console.WriteLine($"Personel Adı: {personel.Ad} {personel.Soyad}");
            Console.WriteLine($"Unvanı: {personel.Tip}");

            int calismaSaati;
            decimal saatlikUcret;
            decimal bonus;
            decimal maas = 0;
            if (personel.Tip == "Yonetici")
            {
                Console.Write("Yöneticinin Çalışma Saati: ");
                calismaSaati = Convert.ToInt32(Console.ReadLine());
                Console.Write("Yöneticinin Saatlik Ücreti: ");
                saatlikUcret = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Yöneticinin Bonus Ücreti: ");
                bonus = Convert.ToDecimal(Console.ReadLine());
                maas = ((Yonetici)personel).MaasHesapla(saatlikUcret, calismaSaati, bonus);
            }
            else if (personel.Tip == "Memur")
            {
                Console.Write("Memurun Çalışma Saati: ");
                calismaSaati = Convert.ToInt32(Console.ReadLine());
                Memur memur = personel as Memur;
                bonus = 0;
                saatlikUcret = memur.SaatlikUcret; 
                maas = memur.MaasHesapla(saatlikUcret, calismaSaati, bonus);
            }
            
            Console.WriteLine($"Maaş: {maas:C}\n");

            
        }

        ////MaasBordro
        //MaasBordro maasBordro = new MaasBordro();
        //maasBordro.BordroOlustur(personelListesi, saatlikUcret, calismaSaati);

        //List<Personel> azCalisanlar = maasBordro.AzCalisanRaporu(personelListesi, calismaSaati);
        //Console.WriteLine("\nAz Çalışan Personeller:");
        //foreach (var azCalisan in azCalisanlar) // Döngüde farklı bir değişken adı kullanın
        //{
        //    Console.WriteLine($"Adı: {azCalisan.Ad} {azCalisan.Soyad}, Çalışma Saati: {calismaSaati}");
        //}
    }
}