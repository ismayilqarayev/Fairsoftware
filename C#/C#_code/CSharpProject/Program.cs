using System;
using System.Collections.Generic;

class Program
{
    static List<Shexs> shexsler = new List<Shexs>();
    static int say;

    static void Main(string[] args)
    {
        NeceneferDaxilEdilmesi();
        MelumatlarinGosterilmesi();
    }

    static void NeceneferDaxilEdilmesi()
    {
        Console.WriteLine("Neçə nəfər üçün məlumat daxil ediləcək?");
        while(!int.TryParse(Console.ReadLine(), out say) || say <= 0)
        {
            Console.WriteLine("Lütfən müsbət bir ədəd daxil edin.");
        }
    }

    static void MelumatlarinGosterilmesi()
    {
        for (int i = 0; i < say; i++)
        {
            Console.WriteLine($"\n--{i + 1}-ci nefer--");
            var shexs = new Shexs();

            while(true)
            {
                Console.Write("Ad: daxil edin: ");
                shexs.Ad = Console.ReadLine();
                
            }
        }
    }
}

class Shexs
{
    private string _ad;
    private string _ataAdi;
    private string _email;
    private long _telefon;
    private int _yas;

    public string Ad
}