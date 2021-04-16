using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace progOdev
                            // camelCase standardı kullanılmıştır
{
    class KontrolVeKurallar
    {
        Harita yolumuz = new Harita();
        public int X = 0;
        public int Y = 0;
        public int baslangicKoorX = 0;
        //public int baslangicKoorY = 9;
        public double skor = .5;


        public void ciz()
        {
            Console.Clear();
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.White;
            Console.Write("K");
        }
        public void hareketEt(ConsoleKeyInfo tus)
        {
            if (tus.Key == ConsoleKey.S)
            {
                Y += 1;
                Console.SetCursorPosition(X, Y);
                //skor+=0.5;
            }
            else if (tus.Key == ConsoleKey.W)
            {
                Y -= 1;
                Console.SetCursorPosition(X, Y);
                //skor += 0.5;
            }
            else if (tus.Key == ConsoleKey.A)
            {
                X -= 1;
                Console.SetCursorPosition(X, Y);
                //skor += 0.5;
            }
            else if (tus.Key == ConsoleKey.D)
            {
                X += 1;
                Console.SetCursorPosition(X, Y);
                //skor += 0.5;
            }
            if (Y == 10)
            {
                skor -= 2;
                Y = 9;
            }
        }

        public bool baslangicSec()
        {
            bool baslangic = true;
            while (baslangic)
            {
                Console.Write("Baslangic İçin 1-2-3 Sayilarindan Birini Seciniz\n");
                string secim = Console.ReadLine();
                if (secim == "1")
                {
                    X = yolumuz.sayiBir();
                    Y = yolumuz.baslangicKoorY;
                    baslangicKoorX = yolumuz.sayiBir();
                    //baslangicKoorY = yolumuz.baslangicKoorY;
                    baslangic = false;
                }
                else if (secim == "2")
                {
                    X = yolumuz.sayiİki();
                    Y = yolumuz.baslangicKoorY;
                    baslangicKoorX = yolumuz.sayiİki();
                    //baslangicKoorY = yolumuz.baslangicKoorY;
                    baslangic = false;
                }
                else if (secim == "3")
                {
                    X = yolumuz.sayiUc();
                    Y = yolumuz.baslangicKoorY;
                    baslangicKoorX = yolumuz.sayiUc();
                    //baslangicKoorY = yolumuz.baslangicKoorY;
                    baslangic = false;
                }
                else
                    baslangic = true;
            }
            return baslangic;
        }

        public bool basaDonduMu()
        {
            bool basageldiMi = false;
            if (X==baslangicKoorX && Y==yolumuz.baslangicKoorY)
            {
                basageldiMi = true;
            }
            else
                basageldiMi = false;
            basSor(basageldiMi);
            return basageldiMi;
        }

        public void basSor(bool sonuc)
        {
            if (sonuc == true)
            {
                Console.Clear();
                baslangicSec();
            }
        }

        public bool oyunBittiMi(Harita duvar)
        {
            bool bitti = false;
            if(Y==0 && duvar.haritaBombali[X, Y] == "1")
            {
                bitti = true;
            }
            basariliMi(bitti);
            return bitti;
        }

        public void basariliMi(bool sonuc)
        {
            if (sonuc == true)
            {
                Console.Clear();
                Console.SetCursorPosition(3, 5);
                Console.WriteLine("Tebrikler, Mayına Çarpmadan Oyunu Bitirdin!");
                Console.SetCursorPosition(18, 6);
                Console.WriteLine("Skorun: {0}", skor);
                Console.SetCursorPosition(5, 7);
                Console.WriteLine("(Oyun 2 sn Sonra Kendiliğinden Kapanacak)");
                Thread.Sleep(2000);     //3 sn bekletir
                Environment.Exit(0);    //oyunu kapatır
            }
        }

        public bool duvaraCarptiMi(Harita duvar,ConsoleKeyInfo sonBasilanTus)
        {
            bool bombayaCarptiMi = false;
            if (duvar.haritaBombali[X, Y] == "0")
            {

                if (sonBasilanTus.Key == ConsoleKey.A)
                {
                    skor -= .5;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Duvara Çarptın!!!");
                    skor -= 1;
                    X = X++;
                    Console.SetCursorPosition(X++, Y);
                    //Console.WriteLine("K");
                    bombayaCarptiMi = false;
                }
                else if (sonBasilanTus.Key == ConsoleKey.D)
                {
                    skor -= .5;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Duvara Çarptın!!!");
                    skor -= 1;
                    X = X--;
                    Console.SetCursorPosition(X--, Y);
                    //Console.WriteLine("K");
                    bombayaCarptiMi = false;
                }
                else if (sonBasilanTus.Key == ConsoleKey.W)
                {
                    skor -= .5;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Duvara Çarptın!!!");
                    skor -= 1;
                    Y = Y++;
                    Console.SetCursorPosition(X, Y++);
                    //Console.WriteLine("K");
                    bombayaCarptiMi = false;
                }
                else if (sonBasilanTus.Key == ConsoleKey.S)
                {
                    skor -= .5;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Duvara Çarptın!!!");
                    skor -= 1;
                    Y = Y--;
                    Console.SetCursorPosition(X, Y--);
                    //Console.WriteLine("K");
                    bombayaCarptiMi = false;
                }
            }
            else if(duvar.haritaBombali[X, Y] == "1")
            {
                skor += .5;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("K");
                bombayaCarptiMi = false;
            }
            else if (duvar.haritaBombali[X, Y] == "2")
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("K");
                bombayaCarptiMi = true;
            }
            oyunSonuMesaji(bombayaCarptiMi);
            return bombayaCarptiMi;
        }

        public void oyunSonuMesaji(bool bittiMi)
        {
            if (bittiMi == true)
            {
                Console.Clear();
                Console.SetCursorPosition(9, 5);
                Console.WriteLine("Mayına Çarptın, Oyun Bitti");
                Console.SetCursorPosition(18, 6);
                Console.WriteLine("Skorun: {0}", (int)skor);
                Console.SetCursorPosition(4, 7);
                Console.WriteLine("(Oyun 2 sn Sonra Kendiliğinden Kapanacak)");
                Thread.Sleep(2000);     //2 sn bekletir
                Environment.Exit(0);    //oyunu kapatır
            }
        }

        public void bomba1koor(Harita bomba)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Birinci Bombanın Koordinatları " + "X: " + bomba.bombaKoorX1 + " " + "Y: " + bomba.bombaKoorY1);
        }

        public void aracKoor()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("Arac Pozisyonu "+"X: "+X+" "+"Y: "+Y);
        }

        public void bomba2koor(Harita bomba)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 24);
            Console.WriteLine("İkinci Bombanın Koordinatları " + "X: " + bomba.bombaKoorX2 + " " + "Y: " + bomba.bombaKoorY2);
        }

        public void skorYaz()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Skor: " + (int)skor);
        }
        public void basKoor()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 30);
            Console.Write("Baslangıç X: {0} - Başlangıç Y: {1}", baslangicKoorX, yolumuz.baslangicKoorY);
        }
    }
}
