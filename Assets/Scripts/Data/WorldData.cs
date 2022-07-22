using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData
{
    public ShapeData[] shapes;

    public WorldData(ShapeData[] data)
    {
        shapes = data;
    }

    public WorldData() { }
}
