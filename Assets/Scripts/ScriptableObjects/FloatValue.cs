using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    public float RuntimeValue;

    //public float maxValue;

    [HideInInspector]
    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
       //maxValue = initialValue;
    }

    public void setHeartContainer()
    {
        //++this.initialValue;
        //++this.maxValue;

        //this.RuntimeValue = this.RuntimeValue + (this.maxValue - this.initialValue);
        ++this.RuntimeValue;
    }

    public void setPlayerHealth()
    {
        //this.maxValue += 2;
        //this.initialValue += 2;
        //this.RuntimeValue = this.RuntimeValue + (this.maxValue - this.initialValue); 

        this.RuntimeValue += 2;
    }
}
