using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    public static void Save(Data data)
    {
        PlayerPrefs.SetString("data", JsonUtility.ToJson(data));
    }
    public static void Load()
    {
        PlayerPrefs.SetInt("continue", 1);
    }
}
