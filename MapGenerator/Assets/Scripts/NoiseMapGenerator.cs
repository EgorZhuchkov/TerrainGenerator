using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGenerator : IColorMapGenerator
{
    public Color[] GetMapFromNoise(int width, int height, float[,] noiseMap)
    {
        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }

        return colorMap;
    }
}
