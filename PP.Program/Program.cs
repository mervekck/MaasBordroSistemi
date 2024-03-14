﻿// See https://aka.ms/new-console-template for more information
using PP.Entity.Abstract;
using PP.Entity.Concrete;
using PP.Entity.Json;


internal class Program
{
    private static void Main(string[] args)
    {
        //DosyaOku
        var personelListesi = DosyaOku.PersonelListesi("personeller.json");

        foreach (var personel in personelListesi)
        {
            Console.WriteLine($"Personel Adı: {personel.Ad} {personel.Soyad}");
            Console.WriteLine($"Unvanı: {personel.Tip}");
            Console.Write("Çalışma Saati: ");
            int calismaSaati = Convert.ToInt32(Console.ReadLine());
            Console.Write("Saatlik Ücreti: ");
            decimal saatlikUcret = Convert.ToDecimal(Console.ReadLine());

            // Maaşı hesapla ve ekrana yazdır
            decimal maas = personel.MaasHesapla(saatlikUcret,calismaSaati);
            Console.WriteLine($"Maaş: {maas:C}\n");
        }

        //MaasBordro

    }
}