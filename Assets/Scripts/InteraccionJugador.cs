using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteraccionJugador : MonoBehaviour
{
    private Transform origenDisparo;
    public float distanciaRayo;
    public float dañoAtaque;
    private Animator anim;
    public ControlPersonaje controlPersonaje;
    EnemigosAI animDaño;
    private float velocidadPrevia;
    private bool puedeAtacar;
    public RaycastHit hit;
    public TextMeshProUGUI contadorMana;
    public GameObject cannonball;
    public float fuerza;

    void Start()
    {
        puedeAtacar = true;
        origenDisparo = transform.Find("OrigenDisparo");
        anim = GetComponent<Animator>();
        controlPersonaje = GetComponent<ControlPersonaje>();
        velocidadPrevia = controlPersonaje.movementSpeed;
        controlPersonaje.mana = 500;
        contadorMana.text = (""+controlPersonaje.mana);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(origenDisparo.position, origenDisparo.forward * distanciaRayo, Color.red);
        if (controlPersonaje.mana > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && (puedeAtacar == true))
            {
                controlPersonaje.mana -= 10;
                puedeAtacar = false;
                controlPersonaje.movementSpeed = 0;
                anim.SetTrigger("Atacar");
            }
            contadorMana.text = ("" + controlPersonaje.mana);
        }
    }   
    public void lanzarAtaque()
    {
        GameObject projectile = (GameObject)Instantiate(cannonball, origenDisparo.transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * fuerza);
        
            if (Physics.Raycast(origenDisparo.position, origenDisparo.forward, out hit, distanciaRayo))
            {
                if (hit.transform.tag == "Enemy")
                {
                    // Si dentro del rayo que lanza detecta un objeto con el tag 'enemy', obtiene el script de controlEnemigo
                    // Esto se hace para restarle la vida a cada enemigo
                    ControlEnemigo enemigoQueRecibeDaño = hit.transform.GetComponent<ControlEnemigo>();
                    Debug.DrawRay(origenDisparo.position, origenDisparo.forward * distanciaRayo, Color.green);
                    EnemigosAI animDaño = hit.transform.GetComponent<EnemigosAI>();
                    animDaño.animacionDaño();
                    //Ejecuta el método 'recibirDaño' dentro del script 'ControlEnemigo' del enemigo al que se le apunta
                    enemigoQueRecibeDaño.recibirDaño(dañoAtaque);

                }
            }
    }

    public void detenerAnimacionAtaque()
    {
        anim.SetBool("Atacar", false);
        controlPersonaje.movementSpeed = velocidadPrevia;
        puedeAtacar = true;
    }
}

