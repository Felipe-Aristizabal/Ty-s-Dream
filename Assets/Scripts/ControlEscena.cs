using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlEscena : MonoBehaviour
{
    public ControlPersonaje controlPersonaje;
    public TMP_InputField nombreJugador;
    public GestionDatos xml;

    public void guardarNombre()
    {
        controlPersonaje.nombre = nombreJugador.text;
        controlPersonaje.puntuacion = (int) (controlPersonaje.puntuacion +(controlPersonaje.mana * 1.5));
        xml.guardarXML(controlPersonaje);
    }
}
