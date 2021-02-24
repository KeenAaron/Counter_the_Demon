using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    // Para almacenar el punto de destino
    public GameObject target;

    void Awake ()
    {
        // Si queremos podemos esconder el debug de los Warps
        GetComponent<SpriteRenderer> ().enabled = false;
        transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = false;
    }

    void OnTriggerEnter2D (Collider2D other) {

        if (other.gameObject.CompareTag("Player"))
        {
            // Actualizamos la posición
            other.transform.position = target.transform.GetChild (0).transform.position;

        }
    }
}
