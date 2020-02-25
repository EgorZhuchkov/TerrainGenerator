using System;
using UnityEngine;

[System.Serializable]
public class TerrainType : IComparable
{
    public string name;
    public float height;
    public Color color;

    public int CompareTo(object o)
    {
        TerrainType p = o as TerrainType;
        if (p != null)
            return this.height.CompareTo(p.height);
        else
            throw new Exception("Невозможно сравнить два объекта");
    }
}
