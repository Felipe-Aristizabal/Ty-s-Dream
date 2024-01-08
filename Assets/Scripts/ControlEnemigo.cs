using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControlEnemigo : MonoBehaviour
{
    public string descripcionEnemigo;
    private ControlPersonaje controlPersonaje;
    public float vida;

    void Start()
    {
        controlPersonaje = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPersonaje>();
    }

    public void recibirDaño(float dañoRecibido)
    {
        vida -= dañoRecibido;
        if (vida <= 0)
        {
            controlPersonaje.enemigosEliminados += 1;
            if (descripcionEnemigo == "Hongo")
            {
                controlPersonaje.puntuacion += 500;
                Destroy(gameObject);
            }else if (descripcionEnemigo == "HongoGrande")
            {
                controlPersonaje.puntuacion += 1000;
                Destroy(gameObject);
            }
        }
    }
}
