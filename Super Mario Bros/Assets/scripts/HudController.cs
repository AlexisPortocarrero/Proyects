using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudController : MonoBehaviour
{
    public Text cuentaatras;
    public int tiempo = 190;
    public int scores = 0;
    public Text score;
    public Text coins;
    public int coin = 0;
    public GameObject inicio;

    public GameObject Ganaste;
    public bool ganastes;

    public GameObject textreiniciar;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Invoke("Times", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0){
            textreiniciar.SetActive(true);
        }

        if(Time.timeScale == 1){
            textreiniciar.SetActive(false);
        }

        score.text = " " + scores;
        coins.text = "X" + coin;
        if(Input.GetKey(KeyCode.Return)){

            inicio.SetActive(false);
            Time.timeScale = 1;
        }

        if(ganastes){
            Ganaste.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void Times(){
        cuentaatras.text = "Time: " + tiempo;
        tiempo--;
        Invoke("Times", 1f); 
    }

    public void AddScore(int a){
        scores+=a;
    }
    public void AddCoin(){
        coin++;
    }
}
