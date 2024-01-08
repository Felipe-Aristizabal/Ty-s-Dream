using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public void Load(string NombreEscena)
    {
     
        SceneManager.LoadScene(NombreEscena);
        if (NombreEscena == "SampleScene")
        {
            SceneManager.LoadScene(NombreEscena);
        }
    }
    public void salirDelJuego()
    {
        Application.Quit();
    }
}
