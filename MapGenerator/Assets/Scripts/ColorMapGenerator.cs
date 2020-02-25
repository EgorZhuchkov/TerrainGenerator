using System;
using UnityEngine;

public class ColorMapGenerator : IColorMapGenerator
{
    private TerrainType[] terrains;
    public ColorMapGenerator(TerrainType[] terrainTypes)
    {
        terrains = terrainTypes;
        Array.Sort(terrains);
    }
    public Color[] GetMapFromNoise(int width, int height, float[,] noiseMap)
    {
        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < terrains.Length; i++)
                {
                    if (currentHeight <= terrains[i].height)
                    {
                        colorMap[y * width + x] = terrains[i].color;
                        break;
                    }
                }
            }
        }
        return colorMap;
    }
}
