using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progOdev
                        // camelCase standardı benimsenmiştir
{
    class Harita
    {
        public int baslangicKoorY = 9;
        public int bombaKoorX1, bombaKoorX2;
        public int bombaKoorY1, bombaKoorY2;
        //public string[,] haritaBombasiz = new string[10, 10];
        public string[,] yolluHarita = new string[10, 10];
        public string[,] haritaBombali = new string[10, 10];
        

        public int sayiBir()
        {
            Random sayiGen = new Random();
            int sayi1 = sayiGen.Next(1, 2);
            return sayi1;
        }

        public int sayiİki()
        {
            Random sayiGen = new Random();
            int sayi2 = sayiGen.Next(5, 6);
            return sayi2;
        }
        public int sayiUc()
        {
            Random sayiGen = new Random();
            int sayi3 = sayiGen.Next(8, 9);
            return sayi3;
        }
        public int sayiDort()
        {
            Random sayiGen = new Random();
            int sayi4 = sayiGen.Next(1, 5);
            return sayi4;
        }

        public int sayiBes()
        {
            Random sayiGen = new Random();
            int sayi5 = sayiGen.Next(6, 9);
            return sayi5;
        }

        public void yolOustur()
        {
            var harita = new string[10, 10];
            int satirBoyut = harita.GetLength(0);
            int sutunBoyut = harita.GetLength(1);
            Random sayiGen = new Random();
            for (int i = 0; i < sutunBoyut; i++)
            {
                for (int j = 0; j < satirBoyut; j++)
                {
                    if(i==0 || j==satirBoyut-1)
                    {
                        harita[i, j] = "0";            
                    }
                    else
                    {
                        harita[i, j] = sayiGen.Next(0, 2).ToString();
                        //harita[i, j] = "0";
                    }      
                }
            }
            yolluHarita = randomYolYap(harita);
            haritaBombali = bombaEkle(harita);
        }

        public string[,] randomYolYap(string[,] map)
        {
            Random sayigen = new Random();
            for(int i = 0; i < 10; i++)              //i sütun, j satır
            {
                for (int j = 9; j >= 0; j--)
                {
                    if (j == 9)
                    {
                        if (i == sayiBir() || i == sayiİki() || i == sayiUc())
                        {
                            map[i, j] = "1";
                        }
                        else
                            map[i, j] = "0";
                    }
                    else if (j == 8)
                    {
                        if (i == sayiBir() || i == sayiİki() || i == sayiUc())
                        {
                            map[i, j] = "1";
                            map[i, j - 1] = "1";
                            map[i, j + 1] = "1";
                        }
                        else
                            map[i, j] = "0";
                    }
                    else if (j == 0)
                    {
                        if (i == sayiDort() || i == sayiBes())
                        {
                            map[i, j] = "1";
                            map[i, j + 1] = "1";
                        }
                        else
                        {
                            map[i, j] = "0";
                        }
                    }
                    else if(i > 1 && i < 8)
                    {
                        if (map[i, j] == "1")
                        {
                            int randomSayi = sayigen.Next(3, 4);  //1=> sağ üst 2=> sol üst 3=> üst
                            /*if (randomSayi == 3)
                            {
                               map[i, j + 1] = "1";
                                
                            }*/
                        }
                        else
                            map[i, j] = "0";
                    }
                    else if (i == 8)
                    {
                        if (map[i, j] == "1")
                        {
                            int randomSayi = sayigen.Next(1, 3); //1 => sol üst 2 => üst
                            if (randomSayi == 1)
                            {
                                map[i - 1, j] = "1";
                                map[i - 1, j - 1] = "1";
                            }
                            else if (randomSayi == 2)
                            {
                                map[i, j - 1] = "1";
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        if (map[i, j] == "1")
                        {
                            int randomSayi = sayigen.Next(1, 3); //1 => sağ üst 2 => üst
                            if (randomSayi == 1)
                            {
                                map[i + 1, j] = "1";
                                map[i + 1, j - 1] = "1";
                            }
                            else if (randomSayi == 2)
                            {
                                map[i, j - 1] = "1";
                            }
                        }
                    }
                    else if (j == 8)
                    {
                        if (map[i, j] == "1")
                        {
                            if (i == 1)
                            {
                                map[i, j] = "1";
                                map[i + 1, j - 1] = "1";
                                map[i, j - 1] = "1";
                            }
                            else if (i == 8)
                            {
                                map[i - 1, j] = "1";
                                map[i - 1, j - 1] = "1";
                                map[i, j - 1] = "1";
                            }
                        }
                    }
                    else
                    {
                        map[i, j] = "0";
                    }
                }
            }
            return map;
        }

        public string[,] yolCiz(string[,] harita)
        {
            int satirBoyut = harita.GetLength(0);
            int sutunBoyut = harita.GetLength(1);
            for (int i = 0; i < satirBoyut; i++)
            {
                for (int j = 0; j < sutunBoyut; j++)
                {
                    if (harita[i, j] == "1")
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(harita[i, j]);
                    }
                    else if (harita[i, j] == "2")
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(harita[i, j]);
                    }
                    else if(harita[i,j]=="0")
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(harita[i, j]);
                    }
                }
                Console.WriteLine("\n");
            }
            return harita;
        }

        public string[,] yolCizBombasiz(string[,] harita)
        {
            int satirBoyut = harita.GetLength(0);
            int sutunBoyut = harita.GetLength(1);
            for (int i = 0; i < satirBoyut; i++)
            {
                for (int j = 0; j < sutunBoyut; j++)
                {
                    if (harita[i, j] == "1")
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(harita[i, j]);
                    }
                    else if (harita[i, j] == "2")
                    {
                        //harita[i, j] = "1";
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Green;
                        //Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("1");
                    }
                    else if(harita[i,j]=="0")
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(harita[i, j]);
                    }
                }
            }
            return harita;
        }

        public string[,] bombaEkle(string[,] yol)
        {
            Random sayiGen = new Random();
            int bombaSayisi = 0;
            while (bombaSayisi<1)
            {
                int randomSatir1 = sayiGen.Next(1, 8);     //ilk ve son satıra mayın gelmemesi gerektiğinden 0 yerine 1 ile başladık
                int randomSutun1 = sayiGen.Next(1, 7);
                if (yol[randomSatir1, randomSutun1] == "1")
                {
                    yol[randomSatir1, randomSutun1] = "2";
                    bombaKoorX1 = randomSatir1;
                    bombaKoorY1 = randomSutun1;
                    bombaSayisi++;
                }

            }
            while(bombaSayisi>0 && bombaSayisi < 2)
            {
                int randomSatir2 = sayiGen.Next(1, 8);
                int randomSutun2 = sayiGen.Next(1, 7);
                if (yol[randomSatir2, randomSutun2] == "1")
                {
                    yol[randomSatir2, randomSutun2] = "2";
                    bombaKoorX2 = randomSatir2;
                    bombaKoorY2 = randomSutun2;
                    bombaSayisi++;
                }
            }
            return yol;
        }
    }
}
