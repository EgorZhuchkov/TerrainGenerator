using UnityEngine;

public class MapDisplayer : MonoBehaviour
{
    [SerializeField] private Renderer textureRenderer;

    public void DrawNoiseMap(float[,] noiseMap, IColorMapGenerator generator, bool sharpPixels)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        Color[] colorMap = null;

        colorMap = generator.GetMapFromNoise(width, height, noiseMap);

        textureRenderer.sharedMaterial.mainTexture = TextureGenerator.GetTexture(width, height, colorMap, sharpPixels);
        textureRenderer.transform.localScale = new Vector3(width, 0, height);
    }
}
