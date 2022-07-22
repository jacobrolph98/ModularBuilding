using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    private static string path = Application.persistentDataPath + "/worlds/";

    /// <summary>
    /// Save shapes that exist in the world space to disk
    /// </summary>
    public static void SaveShapes()
    {
        // find all shapes in world space
        GameObject[] shapesInWorldspace = GameObject.FindGameObjectsWithTag("Shape");
        int length = shapesInWorldspace.Length;
        ShapeData[] shapeData = new ShapeData[length];
        for (int i = 0; i < length; i++)
        {
            int index = 0; // Default Cylinder
            if (shapesInWorldspace[i].name.Contains("Cube"))
                index = 1;
            else if (shapesInWorldspace[i].name.Contains("Sphere"))
                index = 2;
            // Store retrieved data in serializable class
            shapeData[i] = new ShapeData(shapesInWorldspace[i].transform.position, shapesInWorldspace[i].transform.localEulerAngles, shapesInWorldspace[i].transform.localScale, index);
        }
        // Compile data together in one object
        WorldData data = new WorldData(shapeData);
        // Write world data
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path + "world.world", FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// Read shape data from disk
    /// </summary>
    /// <returns>Data about existing shapes if any</returns>
    public static WorldData LoadShapes()
    {
        if (File.Exists(path + "world.world"))
        {
            // Read world data
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path + "world.world", FileMode.Open);
            WorldData data = formatter.Deserialize(stream) as WorldData;
            stream.Close();
            return data;
        }
        return new WorldData();
    }
}
