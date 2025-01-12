# Öğrenci ve Öğretim Görevlisi Yönetim Sistemi

## 📚 Proje Açıklaması

Bu proje, öğrenciler, öğretim görevlileri ve dersler için basit bir yönetim sistemi sunan bir C# konsol uygulamasıdır. Kullanıcılar, öğrencileri ve öğretim görevlilerini ekleyebilir, listeleyebilir ve dersler oluşturabilirler. Tüm veriler JSON dosyalarına kaydedilir ve uygulama başlatıldığında bu dosyalardan yüklenir. Bu sayede veriler kalıcı olarak saklanır ve her çalıştırmada veri kaybı yaşanmaz.

## 🚀 Özellikler

- **Öğrenci Ekleme ve Listeleme:** Yeni öğrenciler ekleyebilir ve mevcut öğrencileri listeleyebilirsiniz.
- **Öğretim Görevlisi Ekleme ve Listeleme:** Yeni öğretim görevlileri ekleyebilir ve mevcut öğretim görevlilerini listeleyebilirsiniz.
- **Ders Ekleme ve Listeleme:** Dersler oluşturabilir, derslere öğretim görevlisi ve öğrenciler ekleyebilirsiniz.
- **Veri Saklama:** Tüm veriler JSON formatında dosyalara kaydedilir ve uygulama başlatıldığında bu dosyalardan yüklenir.
- **Giriş İşlemi:** Öğrenciler ve öğretim görevlileri sisteme giriş yapabilir.

## 🛠 Teknolojiler

- **C#**
- **.NET 5.0 veya Üzeri**
- **JSON** (veri saklama için)
- **Console Uygulaması**

## 📦 Kurulum

### 1. Gereksinimler

- [.NET SDK](https://dotnet.microsoft.com/download) (versiyon 5.0 veya üstü)

### 2. Projeyi Klonlama

```bash
git clone https://github.com/kullaniciAdi/projeAdi.git
cd projeAdi


3. Projeyi Çalıştırma
	
	dotnet run
```

## Kullanım

Uygulama çalıştırıldığında, aşağıdaki seçeneklerden birini seçerek işlemlerinizi gerçekleştirebilirsiniz:

### Öğrenci Ekleme

1. Öğrenci adını girin.
2. Öğrenci soyadını girin.

### Öğretim Görevlisi Ekleme

1. Öğretmen adını girin.
2. Öğretmen soyadını girin.

### Ders Ekleme

1. Ders adını girin.
2. Ders kredisi girin.
3. Öğretmen ID'sini girin.
4. Öğrenci ID'lerini virgülle ayırarak girin.

### Listeleme

Seçilen kategoriye göre (öğrenci, öğretmen, ders) mevcut kayıtları görüntüleyebilirsiniz.


