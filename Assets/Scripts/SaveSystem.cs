using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    public static void save(Data data)
    {
        PlayerPrefs.SetString("data", JsonUtility.ToJson(data));
    }
    public static void load()
    {
        /*JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("data"), data);
        Debug.Log(JsonUtility.ToJson(data));*/
        PlayerPrefs.SetInt("continue", 1);
    }
}
