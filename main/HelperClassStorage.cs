using System;

namespace main
{
    public static class HelperClassStorage
    {
        public static void MaxAvgMinFromArray(float[,] floater)
                {
                    float total = 0;
                    float min = 300;
                    float max = 0;
                    float count = Settings.X * Settings.Y;
                    foreach (var floaty in floater)
                    {
                        if (floaty<min)
                        {
                            min = floaty;
                        }
        
                        if (floaty>max)
                        {
                            max = floaty;
                        }
                        total += floaty;
                    }
        
                    Console.WriteLine(total / count);
                    Console.WriteLine(min);
                    Console.WriteLine(max);
                }
    }
}