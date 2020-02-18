using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D GetTexture(int width, int height, Color[] colorMap)
    {
        Texture2D texture = new Texture2D(width, height);

        texture.SetPixels(colorMap);
        texture.filterMode = FilterMode.Point;
        texture.Apply();

        return texture;
    }
}
