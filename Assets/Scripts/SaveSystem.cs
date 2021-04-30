using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    public static void save(Data data)
    {
        Debug.Log(JsonUtility.ToJson(data));
    }
    public static void load()
    {

    }
}
