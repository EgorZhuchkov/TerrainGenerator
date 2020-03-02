using UnityEngine;

public class MapDisplayer : MonoBehaviour
{
    [SerializeField] private Renderer textureRenderer;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;

    public void DrawNoiseMap(float[,] noiseMap, IColorMapGenerator generator, bool sharpPixels)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        Color[] colorMap = null;

        colorMap = generator.GetMapFromNoise(width, height, noiseMap);

        textureRenderer.sharedMaterial.mainTexture = TextureGenerator.GetTexture(width, height, colorMap, sharpPixels);
        textureRenderer.transform.localScale = new Vector3(width, 0, height);
    }

    public void DrawMesh(float[,] noiseMap, IColorMapGenerator colorMapGenerator, bool sharpPixels, float meshHeightMultiplier, AnimationCurve meshHeightCurve)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Color[] colorMap = null;
        colorMap = colorMapGenerator.GetMapFromNoise(width, height, noiseMap);

        MeshData meshData = MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve);

        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRenderer.sharedMaterial.mainTexture = TextureGenerator.GetTexture(width, height, colorMap, sharpPixels);
    }
}
