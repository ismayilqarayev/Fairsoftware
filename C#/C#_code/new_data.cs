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


                                                                
//----------------------------------------------------------------
// Bu proqram istifadəçidən bir neçə şəxsin məlumatlarını daxil etməsini tələb edir və sonra həmin məlumatları ekrana çap edir. Hər bir məlumat daxil edilərkən müəyyən doğrulamalar aparılır, məsələn, ad və ata adı hərf ilə başlamalıdır, email ünvanı "@" və "." içermelidir, telefon nömrəsi 10 rəqəmli olmalıdır və yaş müsbət bir tam ədəd olmalıdır.
// date 31.05.2026
// 11:15 PM

using System;
using System.Collections.Generic;

// =====================================================
//  Şəxs sinifi — bir nəfərin bütün məlumatı bir yerdə
// =====================================================
class Şəxs
{
    public string Ad         { get; set; }
    public string AtaAdı     { get; set; }
    public string Email      { get; set; }
    public long   Telefon    { get; set; }
    public int    Yaş        { get; set; }

    // Konstruktor
    public Şəxs(string ad, string ataAdı, string email, long telefon, int yaş)
    {
        Ad      = ad;
        AtaAdı  = ataAdı;
        Email   = email;
        Telefon = telefon;
        Yaş     = yaş;
    }

    // Məlumatı çap et
    public void Göstər()
    {
        Console.WriteLine($"Ad: {Ad}, Ata adı: {AtaAdı}, " +
                          $"Email: {Email}, Telefon: {Telefon}, Yaş: {Yaş}");
    }
}

// =====================================================
//  Reyestr sinifi — siyahını idarə edir
// =====================================================
class Reyestr
{
    private List<Şəxs> şəxslər = new List<Şəxs>();

    // Yeni şəxs əlavə et
    public void ƏlavəEt(Şəxs ş)
    {
        şəxslər.Add(ş);
    }

    // Hamısını göstər
    public void HamısınıGöstər()
    {
        if (şəxslər.Count == 0)
        {
            Console.WriteLine("Siyahı boşdur.");
            return;
        }

        Console.WriteLine("\n===== Şəxslər Siyahısı =====");
        for (int i = 0; i < şəxslər.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            şəxslər[i].Göstər();
        }
    }
}

// =====================================================
//  Giriş sinifi — istifadəçidən məlumat oxuyur
// =====================================================
class Giriş
{
    // Yalnız hərf ilə başlayan ad oxu
    public static string AdOxu(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);
            string dəyər = Console.ReadLine();

            if (!string.IsNullOrEmpty(dəyər) && char.IsLetter(dəyər[0]))
                return dəyər;

            Console.WriteLine("⚠  Düzgün ad daxil edin.");
        }
    }

    // Düzgün email oxu
    public static string EmailOxu(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);
            string dəyər = Console.ReadLine();

            if (!string.IsNullOrEmpty(dəyər) &&
                dəyər.Contains("@") && dəyər.Contains("."))
                return dəyər;

            Console.WriteLine("⚠  Düzgün e-poçt daxil edin (@ və . olmalıdır).");
        }
    }

    // 10 rəqəmli telefon oxu
    public static long TelefonOxu(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);
            string dəyər = Console.ReadLine();

            if (dəyər.Length == 10 && long.TryParse(dəyər, out long telefon))
                return telefon;

            Console.WriteLine("⚠  Telefon 10 rəqəmli olmalıdır.");
        }
    }

    // Müsbət tam ədəd oxu
    public static int TamSayOxu(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);

            if (int.TryParse(Console.ReadLine(), out int dəyər) && dəyər > 0)
                return dəyər;

            Console.WriteLine("⚠  Düzgün müsbət ədəd daxil edin.");
        }
    }
}

// =====================================================
//  Main
// =====================================================
class Program
{
    static void Main(string[] args)
    {
        Reyestr reyestr = new Reyestr();

        int say = Giriş.TamSayOxu("Neçə nəfər üçün məlumat daxil etmək istəyirsiniz? ");

        for (int i = 0; i < say; i++)
        {
            Console.WriteLine($"\n--- {i + 1}-ci şəxs ---");

            string ad      = Giriş.AdOxu    ("Ad:       ");
            string ataAdı  = Giriş.AdOxu    ("Ata adı:  ");
            string email   = Giriş.EmailOxu ("E-poçt:   ");
            long   telefon = Giriş.TelefonOxu("Telefon:  ");
            int    yaş     = Giriş.TamSayOxu ("Yaş:      ");

            // Bir şəxs — bir obyekt
            Şəxs ş = new Şəxs(ad, ataAdı, email, telefon, yaş);
            reyestr.ƏlavəEt(ş);
        }

        reyestr.HamısınıGöstər();
    }
}
