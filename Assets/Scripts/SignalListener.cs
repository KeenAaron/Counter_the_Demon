using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{

    public SignalSender signal; //sera la senyal a la que s'estara cridant en aqeull moment
    public UnityEvent signalEvent;


    //quan una senyal es cridadad pel metode creat a l'script "Signal" 
    public void OnSignalRaised()
    {
        signalEvent.Invoke(); //crida a l'event
    }
    
    private void OnEnable()
    {
        signal.RegisterListener(this);
    }
    private void OnDisable() //desactiva tots els listeners que no son necesaris
    {
        signal.DeRegisterListener(this);
    }
}
