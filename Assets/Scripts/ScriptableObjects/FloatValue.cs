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
    //cuando se carga todo el proyecto
    public void OnBeforeSerialize()
    {

    }

    //cuando deja de cargarse todo el proyecto
    public void OnAfterDeserialize()
    {
        this.RuntimeValue = this.initialValue;
        this.maxHearths = this.initialValue;
    }

    //sumar numero de corazones que deben aparecer ya que se ha aumentado debido 
    //a algun evento como acabar con un jefe (se suma 1 al numero de corazones max y se rellenan)
    public void setHeartContainer(float sumHearths)
    {
        //++this.initialValue;
        this.maxHearths += sumHearths;

        //this.RuntimeValue = this.RuntimeValue + (this.maxValue - this.initialValue);
        this.RuntimeValue = this.maxHearths;
    }

    //sumar los puntos de vida ya que se han aumentado debido a matar u jefe. (se suma 2 a la vida maxima y se pone al maximo)
    public void setPlayerHealth(float sumHearths)
    {
        this.maxHearths += sumHearths;
        //this.initialValue += 2;
        //this.RuntimeValue = this.RuntimeValue + (this.maxValue - this.initialValue); 

        this.RuntimeValue = this.maxHearths;
    }

    //metodo para calcular la vida restaurada 
    public void recoverPlayerHealth()
    {
        if (this.RuntimeValue < this.maxHearths) {
            ++this.RuntimeValue;
        }
    }
}
