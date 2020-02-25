using UnityEngine;

public interface IColorMapGenerator
{
    Color[] GetMapFromNoise(int width, int height, float[,] noiseMap);
}
