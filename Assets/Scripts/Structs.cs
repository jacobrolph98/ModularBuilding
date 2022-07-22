using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SerializableVector3
{
    public float x, y, z;

    public SerializableVector3(int i, int j, int k)
    {
        x = i;
        y = j;
        z = k;
    }

    public SerializableVector3(Vector3 val)
    {
        x = val.x;
        y = val.y;
        z = val.z;
    }
}