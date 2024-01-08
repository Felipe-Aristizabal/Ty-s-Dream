using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Transform personajeAseguir;
    public CharacterController principal;
    public float movementSpeed;
    public float rotationSpeed;
    public bool puedeMorir;
    private Animator anie;
    public float x, y;
    public Menu menu;

    public string nombre;
    public int puntuacion;
    public int enemigosEliminados;
    public float mana;

    // Start is called before the first frame update
    void Start()
    {
        anie = GetComponent<Animator>();
        personajeAseguir = GameObject.FindGameObjectWithTag("Hongo").GetComponent<Transform>();
        puedeMorir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeMorir == true)
        {
            atacado();
            Debug.Log("Dentro del rango");
        }
        else
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);

            anie.SetFloat("VelX", x);
            anie.SetFloat("VelY", y);

            if (transform.position.x < 219)
            {
                transform.position = new Vector3(219, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 344)
            {
                transform.position = new Vector3(344, transform.position.y, transform.position.z);
            }
            if (transform.position.z < 70)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 70);
            }
            if (transform.position.z > 248)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 248);
            }
        }

        if (enemigosEliminados == 5)
        {
            ganar();
        }
    }

    public void atacado()
    {
        anie.SetBool("FueGolpeado", true);
        anie.Play("SerGolpeado");
        Debug.Log("Estoy dentro de atacar");
        gameOver();
    }

    public void gameOver()
    {
        menu = FindObjectOfType<Menu>();
        menu.GameOver();
        Time.timeScale = 0f;
    }

    public void ganar()
    {
        menu = FindObjectOfType<Menu>();
        menu.Ganar();
        Time.timeScale = 0f;
    }

    public bool OnTriggerEnter(Collider other)
    {
        puedeMorir = false;
        if (other.transform.tag == "Enemy")
        {
            puedeMorir = true;           
        }
        return puedeMorir;
    }

    public void OnTriggerExit(Collider other)
    {
        
    }
}
