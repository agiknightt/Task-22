using System;
using System.IO;

namespace Task_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isPlaying = true;

            int playerX, playerY;            
            int playerDX = 0, playerDY = 1;

            char[,] map = ReadMap("map1.txt", out playerX, out playerY);

            DrawMap(map);            

            while (isPlaying)
            {
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('$');
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerDX = -1; playerDY = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            playerDX = 1; playerDY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            playerDX = 0; playerDY = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            playerDX = 0; playerDY = 1;
                            break;
                    }
                    if(map[playerX + playerDX, playerY + playerDY] != '*')
                    {
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write(" ");

                        playerX += playerDX;
                        playerY += playerDY;

                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('$');
                    }
                }                
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }            
        }

        static char[,] ReadMap(string mapName, out int playerX, out int playerY)
        {
            playerX = 0;
            playerY = 0;
            string[] newFile = File.ReadAllLines($"maps/{mapName}");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                    if (map[i, j] == '$')
                    {
                        playerX = i;
                        playerY = j;
                    }                    
                }
            }
            return map;
        }
    }
}
