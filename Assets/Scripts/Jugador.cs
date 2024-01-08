using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private string nombre;
    private int puntuacion;

    public Jugador()
    {
    }

    public Jugador(string nombre, int puntuacion)
    {
        this.nombre = nombre;
        this.puntuacion = puntuacion;
    }

    /**
     * Get the value of puntuacion
     *
     * @return the value of puntuacion
     */
    public int getPuntuacion()
    {
        return puntuacion;
    }

    /**
     * Set the value of puntuacion
     *
     * @param puntuacion new value of puntuacion
     */
    public void setPuntuacion(int puntuacion)
    {
        this.puntuacion = puntuacion;
    }

    /**
     * Get the value of nombre
     *
     * @return the value of nombre
     */
    public string getNombre()
    {
        return nombre;
    }

    /**
     * Set the value of nombre
     *
     * @param nombre new value of nombre
     */
    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string toString()
    {
        return "Jugador{" + "nombre=" + nombre + ", puntuacion=" + puntuacion + '}';
    }
}
