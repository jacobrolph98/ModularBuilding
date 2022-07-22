using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShapeData
{
    public SerializableVector3 position, rotation, scale;
    public int availableShapeIndex;

    public ShapeData(Vector3 pos, Vector3 rot, Vector3 size, int index)
    {
        position = new SerializableVector3(pos);
        rotation = new SerializableVector3(rot);
        scale = new SerializableVector3(size);
        availableShapeIndex = index;
    }
}
