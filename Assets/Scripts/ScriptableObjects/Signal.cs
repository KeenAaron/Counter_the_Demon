using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//al crear un joc que diferents objectes interactuen entre si es molt facil crear conexions molt rigides
//entre aquets mateixos, pero ixo pot provocar que quan hi ha un error, tot el projecte es trenca jaque apareix un error
//de "NullReferenceException", per arreglar aixo es poden afegir lineas al codi per comprobar que l'objecte a que s'esta 
//apuntant existeix pero quan es fa referencia a mes d'un objecte aparexien multiples "NullReferenceException" i aixo provoca
//que el codi es torni molt mes llarg i molt mes dificil d'entendre. Per solucionar aixo es una bona idea utilitzar un "Observer",
//esun objecte al joc que veu les coses passar i utilitzaaquesta informacio per dirli als altres objectes qeu fer
//per evitar aquestes conexions rigides crearem un tercer objecte que nomes existira dins del codi que seran les señals (signal)
//per tant l'observador envira una señal a tots els objectes als que es faci referencia en aqeull moment per revisar que tota la informacio es correcte
//Es un sisetma molt flexible que sobretot ajuda a no trencar el joc a l'horade eliminar objectes que existeixen a l'escena
//hhghg
//
[CreateAssetMenu] //aixi ens permet crear un "Signal Sender" (sera qui envii totes les senyals)
public class SignalSender : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();
    //creem una llista de senyals que contindra totes les coses de les que reb senyals

    //
    public void Raise()
    {
        //recorrera la llista de signalListeners y cridara al metode creat a l'script SignalListener
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            //recorrem la llista cap enrere per asegurarnse de qye si en algun moment un listeneres esborrat no causa un error de indexoutofrange exception
            listeners[i].OnSignalRaised();
        }
    }
    
    //afegeix un nou listener a la llista
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    //eliminia un listener de la llista
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
