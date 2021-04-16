using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
                        // camelCase standardı kullanılmıştır
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 35;
            Console.WindowWidth = 49;
            Harita yolumuz = new Harita();
            KontrolVeKurallar hareketimiz = new KontrolVeKurallar();
            bool baslasinMi=hareketimiz.baslangicSec();
            int gBasmaSayisi = 0;
            yolumuz.yolOustur();
            baslangic:
                if (baslasinMi == true)                     
                {                                           
                    hareketimiz.baslangicSec();
                }                                           
                else                                        
                {
                    hareketimiz.ciz();
                    yolumuz.yolCizBombasiz(yolumuz.yolluHarita);
                    hareketimiz.bomba1koor(yolumuz);
                    hareketimiz.bomba2koor(yolumuz);
                    hareketimiz.skorYaz();
                    hareketimiz.basKoor();
                    hareketimiz.aracKoor();
                    ConsoleKeyInfo basilanTus;
                    do
                    {
                        basilanTus = Console.ReadKey();
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (basilanTus.Key == ConsoleKey.G)
                        {
                            gBasmaSayisi++;
                            if (gBasmaSayisi % 2 == 0)
                            {
                                hareketimiz.hareketEt(basilanTus);
                                hareketimiz.ciz();
                                hareketimiz.skor--;
                                hareketimiz.bomba1koor(yolumuz);
                                hareketimiz.bomba2koor(yolumuz);
                                hareketimiz.aracKoor();
                                yolumuz.yolCizBombasiz(yolumuz.yolluHarita);
                                hareketimiz.duvaraCarptiMi(yolumuz, basilanTus);
                                hareketimiz.skorYaz();
                                hareketimiz.oyunBittiMi(yolumuz);

                                while (hareketimiz.oyunBittiMi(yolumuz) == true)
                                {
                                    if (hareketimiz.oyunBittiMi(yolumuz) == true)
                                    {
                                        hareketimiz.basariliMi(hareketimiz.oyunBittiMi(yolumuz));
                                    }
                                }

                                while (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                {
                                    if (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                    {
                                        hareketimiz.oyunSonuMesaji(hareketimiz.duvaraCarptiMi(yolumuz, basilanTus));
                                        break;
                                    }
                                }
                            }
                            else if (gBasmaSayisi % 2 == 1)
                            {
                                hareketimiz.hareketEt(basilanTus);
                                hareketimiz.ciz();
                                hareketimiz.skor--;
                                hareketimiz.bomba1koor(yolumuz);
                                hareketimiz.bomba2koor(yolumuz);
                                hareketimiz.aracKoor();
                                yolumuz.yolCiz(yolumuz.yolluHarita);
                                hareketimiz.duvaraCarptiMi(yolumuz, basilanTus);
                                hareketimiz.skorYaz();
                                hareketimiz.oyunBittiMi(yolumuz);

                                while (hareketimiz.oyunBittiMi(yolumuz) == true)
                                {
                                    if (hareketimiz.oyunBittiMi(yolumuz) == true)
                                    {
                                        hareketimiz.basariliMi(hareketimiz.oyunBittiMi(yolumuz));
                                    }
                                }

                                while (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                {
                                    if (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                    {
                                        hareketimiz.oyunSonuMesaji(hareketimiz.duvaraCarptiMi(yolumuz, basilanTus));
                                        break;
                                    }
                                }
                            }
                        }
                        else if(basilanTus.Key==ConsoleKey.W || basilanTus.Key == ConsoleKey.D || basilanTus.Key == ConsoleKey.S || basilanTus.Key == ConsoleKey.A)
                        {
                            if (gBasmaSayisi % 2 == 0)
                            {
                                hareketimiz.hareketEt(basilanTus);
                                hareketimiz.ciz();
                                //hareketimiz.skor++;
                                hareketimiz.bomba1koor(yolumuz);
                                hareketimiz.bomba2koor(yolumuz);
                                hareketimiz.aracKoor();
                                yolumuz.yolCizBombasiz(yolumuz.yolluHarita);
                                hareketimiz.duvaraCarptiMi(yolumuz, basilanTus);
                                hareketimiz.skorYaz();
                                hareketimiz.oyunBittiMi(yolumuz);

                                while (hareketimiz.oyunBittiMi(yolumuz) == true)
                                {
                                    if (hareketimiz.oyunBittiMi(yolumuz) == true)
                                    {
                                        hareketimiz.basariliMi(hareketimiz.oyunBittiMi(yolumuz));
                                    }
                                }

                                while (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                {
                                    if (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                    {
                                        hareketimiz.oyunSonuMesaji(hareketimiz.duvaraCarptiMi(yolumuz, basilanTus));
                                        break;
                                    }
                                }
                                while (hareketimiz.basaDonduMu() == true)
                                {
                                    goto baslangic;
                                }
                            }
                            else if (gBasmaSayisi % 2 == 1)
                            {
                                hareketimiz.hareketEt(basilanTus);
                                hareketimiz.ciz();
                                //hareketimiz.skor++;
                                hareketimiz.bomba1koor(yolumuz);
                                hareketimiz.bomba2koor(yolumuz);
                                hareketimiz.aracKoor();
                                yolumuz.yolCiz(yolumuz.yolluHarita);
                                hareketimiz.duvaraCarptiMi(yolumuz, basilanTus);
                                hareketimiz.skorYaz();
                                hareketimiz.oyunBittiMi(yolumuz);

                                while (hareketimiz.oyunBittiMi(yolumuz) == true)
                                {
                                    if (hareketimiz.oyunBittiMi(yolumuz) == true)
                                    {
                                        hareketimiz.basariliMi(hareketimiz.oyunBittiMi(yolumuz));
                                    }
                                }

                                while (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                {
                                    if (hareketimiz.duvaraCarptiMi(yolumuz, basilanTus) == true)
                                    {
                                        hareketimiz.oyunSonuMesaji(hareketimiz.duvaraCarptiMi(yolumuz, basilanTus));
                                        break;
                                    }
                                }
                                while (hareketimiz.basaDonduMu() == true)
                                {
                                    goto baslangic;
                                }
                            }
                        }
                    } while (basilanTus.Key != ConsoleKey.Escape);
                }
        }
    }
}
