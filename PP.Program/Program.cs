// See https://aka.ms/new-console-template for more information
using PP.Entity.Abstract;
using PP.Entity.Concrete;
using PP.Entity.Json;


internal class Program
{
    private static void Main(string[] args)
    {
        //DosyaOku
        List<Personel> personelListesi = DosyaOku.PersonelListesi("personeller.json");

        //MaasBordro

    }
}