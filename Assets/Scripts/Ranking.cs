using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using TMPro;

public class Ranking : MonoBehaviour
{
    private TextMeshProUGUI nombreJugador1;
    private TextMeshProUGUI nombreJugador2;
    private TextMeshProUGUI nombreJugador3;
    private TextMeshProUGUI puntuacionJugador1;
    private TextMeshProUGUI puntuacionJugador2;
    private TextMeshProUGUI puntuacionJugador3;
   

    LinkedList<Jugador> listaJugadores;
    int puntuacionPrimerPuesto = 0;
    int puntuacionSegundoPuesto = 0;
    int puntuacionTercerPuesto = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        listaJugadores = new LinkedList<Jugador>();

        nombreJugador1 = GameObject.Find("Nombre jugador 1").GetComponent<TextMeshProUGUI>();
        nombreJugador2 = GameObject.Find("Nombre jugador 2").GetComponent<TextMeshProUGUI>();
        nombreJugador3 = GameObject.Find("Nombre jugador 3").GetComponent<TextMeshProUGUI>();

        puntuacionJugador1 = GameObject.Find("Puntuacion jugador 1").GetComponent<TextMeshProUGUI>();
        puntuacionJugador2 = GameObject.Find("Puntuacion jugador 2").GetComponent<TextMeshProUGUI>();
        puntuacionJugador3 = GameObject.Find("Puntuacion jugador 3").GetComponent<TextMeshProUGUI>();
        Debug.Log("Cargar Datos");
        cargarXML();
        ordenarRanking();

    }
    public void cargarXML()
    {
        string nombreJugador = "";
        int puntuacion = 0;

        if (File.Exists(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml"))
        {
            XmlDocument documentoXML = new XmlDocument();
            documentoXML.Load(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml");

            // Obtiene una nodeList con todos las etiquetas que tengan el nombre de 'BarraMana'
            XmlNodeList jugadorElement = documentoXML.GetElementsByTagName("Jugador");

            for (int i = 0; i < jugadorElement.Count; i++)
            {
                XmlNode node = jugadorElement[i];
                nombreJugador = node.Attributes["nombre"].Value;

                XmlNodeList puntuacionElement = documentoXML.GetElementsByTagName("Puntuacion");
                puntuacion = int.Parse(puntuacionElement[i].InnerText);

                Jugador nuevoJugador = new Jugador(nombreJugador, puntuacion);

                listaJugadores.AddLast(nuevoJugador);

            }
        }
        else
        {
            Debug.Log("No se encontr� partida guardada");
        }
    }

    public void ordenarRanking()
    {

        foreach (Jugador jugador in listaJugadores)
        {
            string nombre = jugador.getNombre();
            int puntuacion = jugador.getPuntuacion();

            string nombreTemp = "";
            int puntuacionTemp = 0;

            string nombreTemp1 = "";
            int puntuacionTemp1 = 0;

            Debug.Log("Jugador: " + nombre + ", Puntuaci�n: " + puntuacion);

            if(puntuacion > puntuacionTercerPuesto)
            {
                if(puntuacion> puntuacionSegundoPuesto)
                {

                    if (puntuacion > puntuacionPrimerPuesto)
                    {
                        // Almaceno los datos del primer y segundo puesto existentes
                        nombreTemp = nombreJugador1.text;
                        puntuacionTemp = int.Parse(puntuacionJugador1.text);
                        nombreTemp1 = nombreJugador2.text;
                        puntuacionTemp1 = int.Parse(puntuacionJugador2.text);

                        puntuacionPrimerPuesto = puntuacion;
                        puntuacionJugador1.text = puntuacionPrimerPuesto.ToString();
                        nombreJugador1.text = nombre;

                        // Le asigno el segundo lugar al que estaba de primero
                        puntuacionSegundoPuesto = puntuacionTemp;
                        nombreJugador2.text = nombreTemp;
                        puntuacionJugador2.text = puntuacionTemp.ToString();

                        // Le asigno al tercer lugar el que estaba de segundo
                        puntuacionTercerPuesto = puntuacionTemp1;
                        nombreJugador3.text = nombreTemp1;
                        puntuacionJugador3.text = puntuacionTemp1.ToString();

                    }
                    else
                    {
                        // Almaceno la informaci�n del segundo lugar que ser� pasado a tercer puesto
                        nombreTemp1 =  nombreJugador2.text;
                        puntuacionTemp1 = int.Parse(puntuacionJugador2.text);

                        puntuacionSegundoPuesto = puntuacion;
                        puntuacionJugador2.text = puntuacionSegundoPuesto.ToString();
                        nombreJugador2.text = nombre;

                        // Agrego los valores del segundo lugar al tercero
                        puntuacionTercerPuesto = puntuacionTemp1;
                        nombreJugador3.text = nombreTemp1;
                        puntuacionJugador3.text = puntuacionTemp1.ToString();
                    }
                }
                else
                {
                    puntuacionTercerPuesto = puntuacion;
                    puntuacionJugador3.text = puntuacionTercerPuesto.ToString();
                    nombreJugador3.text = nombre;
                }

            }

        }
        Debug.Log("Primer puesto: " + puntuacionPrimerPuesto);
        Debug.Log("Segundo puesto: " + puntuacionSegundoPuesto);
        Debug.Log("Tercer puesto: " + puntuacionTercerPuesto);

    }
}
