using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    public float RuntimeValue;

    public float maxHearths;

    //public float maxValue;

    [HideInInspector]
    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
        maxHearths = initialValue;
    }

    public void setHeartContainer()
    {
        //++this.initialValue;
        ++this.maxHearths;

        //this.RuntimeValue = this.RuntimeValue + (this.maxValue - this.initialValue);
        this.RuntimeValue = maxHearths;
    }

    public void setPlayerHealth()
    {
        this.maxHearths += 2;
        //this.initialValue += 2;
        //this.RuntimeValue = this.RuntimeValue + (this.maxValue - this.initialValue); 

        this.RuntimeValue = maxHearths;
    }
}
