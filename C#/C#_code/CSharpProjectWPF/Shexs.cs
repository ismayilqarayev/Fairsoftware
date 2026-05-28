namespace CSharpProjectWPF
{
    // Bir şəxsin bütün məlumatlarını saxlayan sinif
    class Shexs
    {
        private string? _ad;      // Adı saxlayan private sahə
        private string? _ataAdi;  // Ata adını saxlayan private sahə
        private string? _email;   // Emaili saxlayan private sahə
        private long _telefon;   // Telefonu saxlayan private sahə
        private int _yas;        // Yaşı saxlayan private sahə

        // Ad property-si
        public string? Ad
        {
            get { return _ad; }
            set
            {
                if (!string.IsNullOrEmpty(value) && char.IsLetter(value[0]))
                    _ad = value;
                else
                    throw new ArgumentException("Ad düzgün deyil.");
            }
        }

        // AtaAdi property-si
        public string? AtaAdi
        {
            get { return _ataAdi; }
            set
            {
                if (!string.IsNullOrEmpty(value) && char.IsLetter(value[0]))
                    _ataAdi = value;
                else
                    throw new ArgumentException("Ata adı düzgün deyil.");
            }
        }

        // Email property-si
        public string? Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains("@") && value.Contains("."))
                    _email = value;
                else
                    throw new ArgumentException("Email düzgün deyil.");
            }
        }

        // Telefon property-si
        public long Telefon
        {
            get { return _telefon; }
            set
            {
                if (value.ToString().Length == 10)
                    _telefon = value;
                else
                    throw new ArgumentException("Telefon nömrəsi düzgün deyil.");
            }
        }

        // Yas property-si
        public int Yas
        {
            get { return _yas; }
            set
            {
                if (value > 0)
                    _yas = value;
                else
                    throw new ArgumentException("Yaş düzgün deyil.");
            }
        }

        // Şəxsin bütün məlumatlarını bir sətirdə qaytaran metod
        public override string ToString()
        {
            return $"Ad: {Ad}, Ata adı: {AtaAdi}, Email: {Email}, Telefon: {Telefon}, Yaş: {Yas}";
        }
    }
}
