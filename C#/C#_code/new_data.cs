using System; // Konsol əməliyyatları üçün (Console.Write, Console.ReadLine və s.)
using System.Collections.Generic; // List<T> istifadəsi üçün

class Program
{
    static List<Shexs> shexsler = new List<Shexs>(); // Bütün şəxslərin saxlandığı siyahı
    static int say; // İstifadəçinin daxil edəcəyi şəxs sayı

    static void Main(string[] args) // Proqramın başlanğıc nöqtəsi
    {
        NeceneferDaxilEdilmesi(); // Addım 1: Neçə nəfər olduğunu öyrən
        MelumatlarDaxilEdilmesi(); // Addım 2: Hər şəxsin məlumatlarını al

        Console.WriteLine("\n--- Məlumatlar ---"); // Başlıq çap et
        foreach (var s in shexsler) // Siyahıdakı hər şəxs üçün dövrə vur
        {
            s.Print(); // Həmin şəxsin məlumatlarını ekrana çap et
        }
    }

    // İstifadəçidən neçə nəfər üçün məlumat daxil ediləcəyini alan metod
    static void NeceneferDaxilEdilmesi()
    {
        Console.Write("Neçə nəfər üçün məlumat daxil etmək istəyirsiniz: "); // Sual ver
        while (!int.TryParse(Console.ReadLine(), out say) || say <= 0) // Daxil edilən dəyər tam ədəd və müsbət deyilsə təkrarla
        {
            Console.Write("Yenidən düzgün bir ədəd daxil edin: "); // Xəta mesajı göstər
        }
    }

    // Hər şəxs üçün ad, ata adı, email, telefon və yaş məlumatlarını alan metod
    static void MelumatlarDaxilEdilmesi()
    {
        for (int i = 0; i < say; i++) // say qədər şəxs üçün dövrə vur
        {
            Console.WriteLine($"\n-- {i + 1}-ci nəfər --"); // Neçənci şəxs olduğunu göstər
            var shexs = new Shexs(); // Yeni boş Shexs obyekti yarat

            // --- Ad daxiletməsi ---
            while (true) // Düzgün dəyər daxil edilənə qədər dövrə davam et
            {
                Console.Write("Ad daxil edin: "); // İstifadəçidən ad istə
                string deger = Console.ReadLine(); // Daxil edilən dəyəri oxu
                if (!string.IsNullOrEmpty(deger) && char.IsLetter(deger[0])) // Boş olmamalı və hərf ilə başlamalıdır
                {
                    shexs.Ad = deger; // Şərt ödənilibsə adı təyin et
                    break; // Dövrədən çıx
                }
                Console.WriteLine("Məlumatı düzgün daxil edin."); // Şərt ödənilməyibsə xəta göstər
            }

            // --- Ata adı daxiletməsi ---
            while (true) // Düzgün dəyər daxil edilənə qədər dövrə davam et
            {
                Console.Write("Ata adını daxil edin: "); // İstifadəçidən ata adı istə
                string deger = Console.ReadLine(); // Daxil edilən dəyəri oxu
                if (!string.IsNullOrEmpty(deger) && char.IsLetter(deger[0])) // Boş olmamalı və hərf ilə başlamalıdır
                {
                    shexs.AtaAdi = deger; // Şərt ödənilibsə ata adını təyin et
                    break; // Dövrədən çıx
                }
                Console.WriteLine("Məlumatı düzgün daxil edin."); // Şərt ödənilməyibsə xəta göstər
            }

            // --- Email daxiletməsi ---
            while (true) // Düzgün dəyər daxil edilənə qədər dövrə davam et
            {
                Console.Write("E-poçt ünvanını daxil edin: "); // İstifadəçidən email istə
                string deger = Console.ReadLine(); // Daxil edilən dəyəri oxu
                if (!string.IsNullOrEmpty(deger) && deger.Contains("@") && deger.Contains(".")) // Boş olmamalı, "@" və "." simvolları olmalıdır
                {
                    shexs.Email = deger; // Şərt ödənilibsə emaili təyin et
                    break; // Dövrədən çıx
                }
                Console.WriteLine("Düzgün e-poçt ünvanı daxil edin."); // Şərt ödənilməyibsə xəta göstər
            }

            // --- Telefon daxiletməsi ---
            while (true) // Düzgün dəyər daxil edilənə qədər dövrə davam et
            {
                Console.Write("Telefon nömrəsini daxil edin (10 rəqəm): "); // İstifadəçidən telefon istə
                string deger = Console.ReadLine(); // Daxil edilən dəyəri oxu
                if (deger.Length == 10 && long.TryParse(deger, out long tel)) // Uzunluğu 10 olmalı və tam ədəd olmalıdır
                {
                    shexs.Telefon = tel; // Şərt ödənilibsə telefonu təyin et
                    break; // Dövrədən çıx
                }
                Console.WriteLine("Məlumatı düzgün daxil edin."); // Şərt ödənilməyibsə xəta göstər
            }

            // --- Yaş daxiletməsi ---
            while (true) // Düzgün dəyər daxil edilənə qədər dövrə davam et
            {
                Console.Write("Yaşı daxil edin: "); // İstifadəçidən yaş istə
                if (int.TryParse(Console.ReadLine(), out int yas) && yas > 0) // Tam ədəd və müsbət olmalıdır
                {
                    shexs.Yas = yas; // Şərt ödənilibsə yaşı təyin et
                    break; // Dövrədən çıx
                }
                Console.WriteLine("Yaşı düzgün daxil edin."); // Şərt ödənilməyibsə xəta göstər
            }

            shexsler.Add(shexs); // Bütün məlumatları daxil edilmiş şəxsi siyahıya əlavə et
        }
    }
}

// Bir şəxsin bütün məlumatlarını saxlayan sinif
class Shexs
{
    private string _ad;      // Adı saxlayan private sahə — birbaşa xaricdən dəyişdirilə bilməz
    private string _ataAdi;  // Ata adını saxlayan private sahə — birbaşa xaricdən dəyişdirilə bilməz
    private string _email;   // Emaili saxlayan private sahə — birbaşa xaricdən dəyişdirilə bilməz
    private long _telefon;   // Telefonu saxlayan private sahə — birbaşa xaricdən dəyişdirilə bilməz
    private int _yas;        // Yaşı saxlayan private sahə — birbaşa xaricdən dəyişdirilə bilməz

    // Ad property-si: oxuma və yoxlamalı yazma əməliyyatını idarə edir
    public string Ad
    {
        get { return _ad; } // _ad sahəsinin dəyərini qaytarır
        set
        {
            if (!string.IsNullOrEmpty(value) && char.IsLetter(value[0])) // Boş olmamalı və hərf ilə başlamalıdır
                _ad = value; // Şərt ödənilibsə dəyəri saxla
            else
                throw new ArgumentException("Ad düzgün deyil."); // Şərt ödənilməyibsə xəta at
        }
    }

    // AtaAdi property-si: oxuma və yoxlamalı yazma əməliyyatını idarə edir
    public string AtaAdi
    {
        get { return _ataAdi; } // _ataAdi sahəsinin dəyərini qaytarır
        set
        {
            if (!string.IsNullOrEmpty(value) && char.IsLetter(value[0])) // Boş olmamalı və hərf ilə başlamalıdır
                _ataAdi = value; // Şərt ödənilibsə dəyəri saxla
            else
                throw new ArgumentException("Ata adı düzgün deyil."); // Şərt ödənilməyibsə xəta at
        }
    }

    // Email property-si: oxuma və yoxlamalı yazma əməliyyatını idarə edir
    public string Email
    {
        get { return _email; } // _email sahəsinin dəyərini qaytarır
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Contains("@") && value.Contains(".")) // Boş olmamalı, "@" və "." olmalıdır
                _email = value; // Şərt ödənilibsə dəyəri saxla
            else
                throw new ArgumentException("Email düzgün deyil."); // Şərt ödənilməyibsə xəta at
        }
    }

    // Telefon property-si: oxuma və yoxlamalı yazma əməliyyatını idarə edir
    public long Telefon
    {
        get { return _telefon; } // _telefon sahəsinin dəyərini qaytarır
        set
        {
            if (value.ToString().Length == 10) // Rəqəm sayı dəqiq 10 olmalıdır
                _telefon = value; // Şərt ödənilibsə dəyəri saxla
            else
                throw new ArgumentException("Telefon nömrəsi düzgün deyil."); // Şərt ödənilməyibsə xəta at
        }
    }

    // Yas property-si: oxuma və yoxlamalı yazma əməliyyatını idarə edir
    public int Yas
    {
        get { return _yas; } // _yas sahəsinin dəyərini qaytarır
        set
        {
            if (value > 0) // Yaş mütləq müsbət olmalıdır
                _yas = value; // Şərt ödənilibsə dəyəri saxla
            else
                throw new ArgumentException("Yaş düzgün deyil."); // Şərt ödənilməyibsə xəta at
        }
    }

    // Şəxsin bütün məlumatlarını bir sətirdə konsola çap edən metod
    public void Print()
    {
        Console.WriteLine($"Ad: {Ad}, Ata adı: {AtaAdi}, Email: {Email}, Telefon: {Telefon}, Yaş: {Yas}");
    }
}