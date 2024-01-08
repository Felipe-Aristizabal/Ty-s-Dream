using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class GestionDatos : MonoBehaviour
{
    private ControlPersonaje controlPersonaje;
    private Transform nombreJugador1;
    private LinkedList<Jugador> listaJugadores;

    // Start is called before the first frame update
    void Start()
    {
        controlPersonaje = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPersonaje>();

        nombreJugador1 = transform.Find("Nombre jugador 1");
        listaJugadores = new LinkedList<Jugador>();

        Debug.Log("Puntuacion inicial: " + controlPersonaje.puntuacion);
        Debug.Log("Mana inicial: " + controlPersonaje.mana);
    }

    public void guardarXML(ControlPersonaje controlPersonaje)
    {
        XmlDocument documentoXML = new XmlDocument();

        // Asigno el nombre del jugador como atributo de la etiqueta "Jugador".
        XmlElement jugadorElement = documentoXML.CreateElement("Jugador");
        jugadorElement.SetAttribute("nombre", controlPersonaje.nombre);

        // Asigno la puntuaci�n del jugador como elemento de la etiqueta "Puntuacion".
        XmlElement puntuacionElement = documentoXML.CreateElement("Puntuacion");
        puntuacionElement.InnerText = controlPersonaje.puntuacion.ToString();
        jugadorElement.AppendChild(puntuacionElement);  // Agrego puntuacion a la etiqueta del jugador.

        // Si ya existe fichero XML creado, procedo a escribir sobre el archivo que ya existe
        if (File.Exists(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml"))
        {
            documentoXML.Load(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml");
            XmlNodeList nodeLisRoot = documentoXML.GetElementsByTagName("Root");
            XmlNode root = nodeLisRoot[0];

            // Guardo la puntuaci�n que tenga el personaje en ese momento.
            puntuacionElement.InnerText = controlPersonaje.puntuacion.ToString();
            jugadorElement.AppendChild(puntuacionElement);
            root.AppendChild(jugadorElement);

            documentoXML.Save(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml");
        }
        else
        {
            XmlElement root = documentoXML.CreateElement("Root");
            root.AppendChild(jugadorElement);

            documentoXML.AppendChild(root); //A�ado finalmente la etiqueta ra�z al documento xml
            documentoXML.Save(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml");
            if (File.Exists(Application.dataPath + $"PartidaGuardada{nombreJugador1}.xml"))
            {
                Debug.Log("Archivo XML GUARDADO");
            }
        }
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

}