using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigosAI : MonoBehaviour
{
    public Transform personajeAseguir;
    public Animator anim;
    public float distanciaDeDeteccion;
    public float velocidadCaminando;
    public float velocidadCorriendo;

    private NavMeshAgent agente;
    public Transform[] recorrido;
    private int indiceRecorrido;
    public Vector3 objetivoRecorrido;

    // Start is called before the first frame update
    void Start()
    {
        personajeAseguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Caminar", true);
        detectarEnemigo();
    }

    // Update is called once per frame
    void Update()
    {
        detectarEnemigo();
    }

    public void detectarEnemigo()
    {
        if (Vector3.Distance(transform.position, personajeAseguir.position) < distanciaDeDeteccion)
        {
            agente.speed = velocidadCorriendo;
            agente.destination = personajeAseguir.position;
        }
        else
        {

            if (Vector3.Distance(transform.position, objetivoRecorrido) > 1)
            {
                agente.speed = velocidadCaminando;
                hacerRecorrido();
            }
            else if (Vector3.Distance(transform.position, objetivoRecorrido) < 1)
            {
                actualizarIndiceRecorrido();
                hacerRecorrido();
            }
        }
    }

    public void actualizarIndiceRecorrido()
    {
        indiceRecorrido++;

        if (indiceRecorrido == recorrido.Length)
        {
            indiceRecorrido = 0;
        }
    }

    public void hacerRecorrido()
    {
        objetivoRecorrido = recorrido[indiceRecorrido].position;
        agente.SetDestination(objetivoRecorrido);
    }

    public void animacionDaño()
    {
        Debug.Log("Animación");
        anim.Play("DañoRecibido");
    }
}
