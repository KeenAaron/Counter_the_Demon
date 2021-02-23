using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    public float RuntimeValue;

    [HideInInspector]
    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }
}
