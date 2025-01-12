using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

// Base Class
public abstract class Kisi
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }

    public Kisi(int id, string ad, string soyad)
    {
        Id = id;
        Ad = ad;
        Soyad = soyad;
    }

    public abstract void BilgiGoster();
}

// Interface
public interface ILogin
{
    void Login();
}

// Ogrenci Class
public class Ogrenci : Kisi, ILogin
{
    public List<Ders> Dersler { get; set; } = new List<Ders>();

    public Ogrenci(int id, string ad, string soyad) : base(id, ad, soyad) { }

    public override void BilgiGoster()
    {
        Console.WriteLine($"[Ogrenci] {Id} - {Ad} {Soyad}");
    }

    public void Login()
    {
        Console.WriteLine($"Ogrenci {Ad} {Soyad} sisteme giriş yaptÄ±.");
    }

    public static void SaveToFile(List<Ogrenci> ogrenciler)
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "ogrenciler.json");
        if(!File.Exists(filePath))
        {
            File.Create(filePath);
        }
        var json = JsonSerializer.Serialize(ogrenciler, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public static List<Ogrenci> LoadFromFile()
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "ogrenciler.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            return new List<Ogrenci>();
        }
        var json = File.ReadAllText(filePath);
        if (json == "")
        {
            return new List<Ogrenci>();
        }
        return JsonSerializer.Deserialize<List<Ogrenci>>(json);
    }
}

// OgretimGorevlisi Class
public class OgretimGorevlisi : Kisi, ILogin
{
    public List<Ders> VerilenDersler { get; set; } = new List<Ders>();

    public OgretimGorevlisi(int id, string ad, string soyad) : base(id, ad, soyad) { }

    public override void BilgiGoster()
    {
        Console.WriteLine($"[Ogretim Gorevlisi] {Id} - {Ad} {Soyad}");
    }

    public void Login()
    {
        Console.WriteLine($"Ogretim Gorevlisi {Ad} {Soyad} sisteme giriş yaptı.");
    }

    public static void SaveToFile(List<OgretimGorevlisi> ogretimGorevlileri)
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "ogretmenler.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
        var json = JsonSerializer.Serialize(ogretimGorevlileri, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public static List<OgretimGorevlisi> LoadFromFile()
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "ogretmenler.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            return new List<OgretimGorevlisi>();
        }
        var json = File.ReadAllText(filePath);
        if(json == "")
        {
            return new List<OgretimGorevlisi>();
        }
        return JsonSerializer.Deserialize<List<OgretimGorevlisi>>(json);
    }
}

// Ders Class
public class Ders
{
    public string Ad { get; set; }
    public double Kredi { get; set; }
    public OgretimGorevlisi OgretimGorevlisi { get; set; }
    public List<Ogrenci> KayitliOgrenciler { get; set; } = new List<Ogrenci>();

    public Ders(string ad, double kredi, OgretimGorevlisi ogretimGorevlisi)
    {
        Ad = ad;
        Kredi = kredi;
        OgretimGorevlisi = ogretimGorevlisi;
    }

    public void AddOgrenci(Ogrenci ogrenci)
    {
        KayitliOgrenciler.Add(ogrenci);
    }

    public static void SaveToFile(List<Ders> dersler)
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "dersler.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
        var json = JsonSerializer.Serialize(dersler, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public static List<Ders> LoadFromFile()
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "dersler.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            return new List<Ders>();
        }
        var json = File.ReadAllText(filePath);
        if (json == "")
        {
            return new List<Ders>();
        }
        return JsonSerializer.Deserialize<List<Ders>>(json);
    }

    public void BilgiGoster()
    {
        Console.WriteLine($"Ders Adı: {Ad}, Kredi: {Kredi}, Ogretim Gorevlisi: {OgretimGorevlisi.Ad} {OgretimGorevlisi.Soyad}");
        Console.WriteLine("Kayitli Ogrenciler:");
        foreach (var ogrenci in KayitliOgrenciler)
        {
            Console.WriteLine($"- {ogrenci.Ad} {ogrenci.Soyad}");
        }
    }
}

// Program
class Program
{
    static void Main(string[] args)
    {
        List<Ogrenci> ogrenciler = Ogrenci.LoadFromFile();
        List<OgretimGorevlisi> ogretimGorevlileri = OgretimGorevlisi.LoadFromFile();
        List<Ders> dersler = Ders.LoadFromFile();

        while (true)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("""
                (1)Öğrenci Ekle
                (2)Öğrenci Listele
                (3)Öğretmen Ekle
                (4)Öğretmen Listele
                (5)Ders Ekle
                (6)Ders Listele
                (7)Çıkış
                Bir kod giriniz :
                """);
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Öğrenci Adı giriniz : ");
                    string ogrenciAdi = Console.ReadLine();
                    Console.WriteLine("Öğrenci Soyadı giriniz : ");
                    string ogrenciSoyadi = Console.ReadLine();
                    ogrenciler.Add(new Ogrenci(ogrenciler.Count() + 1, ogrenciAdi, ogrenciSoyadi));
                    Ogrenci.SaveToFile(ogrenciler);
                    Console.Clear();
                    break;
                case "2":
                    foreach (var ogrenci in ogrenciler)
                    {
                        ogrenci.BilgiGoster();
                    }
                    break;
                case "3":
                    Console.WriteLine("Öğretmen Adı giriniz : ");
                    string ogretmenAdi = Console.ReadLine();
                    Console.WriteLine("Öğretmen Soyadı giriniz : ");
                    string ogretmenSoyadi = Console.ReadLine();
                    ogretimGorevlileri.Add(new OgretimGorevlisi(ogretimGorevlileri.Count() + 1, ogretmenAdi, ogretmenSoyadi));
                    OgretimGorevlisi.SaveToFile(ogretimGorevlileri);
                    Console.Clear();
                    break;
                case "4":
                    foreach (var ogretimGorevlisi in ogretimGorevlileri)
                    {
                        ogretimGorevlisi.BilgiGoster();
                    }
                    break;
                case "5":
                    Console.WriteLine("Ders Adı giriniz:");
                    string dersAdi = Console.ReadLine();
                    Console.WriteLine("Ders Kredisi giriniz:");
                    string kredi = Console.ReadLine();
                    Console.WriteLine("Öğretmen ID giriniz:");
                    int ogretmenId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Öğrenci ID'lerini giriniz (Her id değerinin arasına boşluk bırakmadan ',' ile ayırınız) :");
                    string ogrenciNumaralari = Console.ReadLine();
                    Ders ders = new Ders(dersAdi, double.Parse(kredi), ogretimGorevlileri.First(x => x.Id == ogretmenId));
                    foreach (var ogrenciId in ogrenciNumaralari.Split(','))
                    {
                        ders.AddOgrenci(ogrenciler.First(x => x.Id == int.Parse(ogrenciId)));
                    }
                    dersler.Add(ders);
                    Ders.SaveToFile(dersler);
                    Console.Clear();
                    break;
                case "6":
                    foreach (var currentDers in dersler)
                    {
                        Console.WriteLine("****************************************");
                        currentDers.BilgiGoster();
                    }
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
