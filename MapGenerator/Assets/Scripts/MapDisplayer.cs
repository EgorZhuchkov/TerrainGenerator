using UnityEngine;

public class MapDisplayer : MonoBehaviour
{
    [SerializeField] private Renderer textureRenderer;
    [SerializeField] private TerrainType[] terrains;

    public void DrawNoiseMap(float[,] noiseMap, DrawMode drawMode)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        Color[] colorMap = null;

        if (drawMode == DrawMode.ColorMap)
        {
            colorMap = GetColorMap(width, height, noiseMap);
        }
        else if(drawMode == DrawMode.NoiseMap)
        {
            colorMap = GetColoredNoiseMap(width, height, noiseMap);
        }

        textureRenderer.sharedMaterial.mainTexture = TextureGenerator.GetTexture(width, height, colorMap);
        textureRenderer.transform.localScale = new Vector3(width, 0, height);
    }

    private Color[] GetColorMap(int width, int height, float[,] noiseMap)
    {
        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < terrains.Length; i++)
                {
                    if((currentHeight >= terrains[i].minMaxHeight.x) && (currentHeight < terrains[i].minMaxHeight.y))
                    {
                        colorMap[y * width + x] = terrains[i].color;
                    }
                }
            }
        }
        return colorMap;
    }
    private Color[] GetColoredNoiseMap(int width, int height, float[,] noiseMap)
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
