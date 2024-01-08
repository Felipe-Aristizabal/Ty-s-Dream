using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject UIPausa;
    public GameObject UIGameOver;
    public GameObject UIGanar;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;      
    }

    // Update is called once per frame
    void Update()
    {

    }
 
    public void Pausa()
    {
        CerrarUI();
        UIPausa.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        CerrarUI();
        UIGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CerrarUI()
    {  
        UIGameOver.SetActive(false);
        UIPausa.SetActive(false);
        UIGanar.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Ganar()
    {
        CerrarUI();
        UIGanar.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
