using UnityEngine;
[RequireComponent(typeof(MapDisplayer))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private DrawMode drawMode;
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;
    [SerializeField] private int seed;
    [SerializeField] private float noiseScale;
    [SerializeField] private int octaves;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float persistance;
    [SerializeField] private float lacunarity;
    [SerializeField] private Vector2 offset;
    [SerializeField] private bool sharpPixels;
    [SerializeField] private bool autoUpdate;
    [SerializeField] private TerrainType[] terrains;
    
    public bool AutoUpdate
    {
        get { return autoUpdate; }
    }

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        MapDisplayer mapDisplayer = FindObjectOfType<MapDisplayer>();
        if(drawMode == DrawMode.ColorMap)
        {
            mapDisplayer.DrawNoiseMap(noiseMap, new ColorMapGenerator(terrains), sharpPixels);
        }
        else if(drawMode == DrawMode.NoiseMap)
        {
            mapDisplayer.DrawNoiseMap(noiseMap, new NoiseMapGenerator(), sharpPixels);
        }
    }

    private void OnValidate()
    {
        if(mapWidth < 1)
        {
            mapWidth = 1;
        }
        if(mapHeight < 1)
        {
            mapHeight = 1;
        }
        if(lacunarity < 1)
        {
            lacunarity = 1;
        }
        if(octaves < 0)
        {
            octaves = 0;
        }
        if(noiseScale < .01f)
        {
            noiseScale = .01f;
        }
    }
}
