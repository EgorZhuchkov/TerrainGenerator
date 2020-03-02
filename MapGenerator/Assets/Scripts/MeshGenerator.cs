using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float [,] heightMap, float heightMultiplier, AnimationCurve heightCurve)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        float topLeftX = (width - 1) / -2f;
        float topLeftY = (height - 1) / 2f;

        MeshData meshData = new MeshData(width, height);
        int vertIndex = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                meshData.verts[vertIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightMap[x, y]) * heightMultiplier, topLeftY - y);
                meshData.uvs[vertIndex] = new Vector2(x / (float)width, y / (float)height);

                if(x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle(vertIndex, vertIndex + 1, vertIndex + width + 1);
                    meshData.AddTriangle(vertIndex, vertIndex + width + 1, vertIndex + width);
                }

                vertIndex++;
            }
        }

        return meshData;
    }
}

public class MeshData
{
    public Vector3[] verts;
    public int[] tris;
    public Vector2[] uvs;

    private int triangleIndex;

    public MeshData(int width, int height)
    {
        verts = new Vector3[width * height];
        tris = new int[(width - 1) * (height - 1) * 6];
        uvs = new Vector2[width * height];

    }

    public void AddTriangle(int firstVert, int secondVert, int thirdVert)
    {
        tris[triangleIndex] = firstVert;
        tris[triangleIndex + 1] = secondVert;
        tris[triangleIndex + 2] = thirdVert;

        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }
}
