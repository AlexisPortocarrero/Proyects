using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] enemigos;
    private GameObject enemigoActual;
    private int NivelActual = 1;
    private int enemigospn = 0;
    private Player player;
    public Slider slider;
    public Text vida;
    public Text Ene;
    public Text Nivel;
    public GameObject Coin;
    public bool Final;

    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.Find("Player").GetComponent<Player>();
        NivelActual = PlayerPrefs.GetInt("NivelActual", 1);
    }

    // Update is called once per frame
    void Update()
    {

        if(enemigoActual == null){
            CrearEnemigo();
            enemigospn+=1;
        }

        if(enemigospn == 10){
            NivelActual += 1;
            PlayerPrefs.SetInt("NivelActual", NivelActual);
            enemigospn = 0;
        }

        if(slider.value <= 0){
                if(enemigoActual == GameObject.Find("Boss(Clone)")){
                    Destroy(enemigoActual);
                    NivelActual = 12;
                    PlayerPrefs.SetInt("NivelActual", NivelActual);
                    SceneManager.LoadScene("Final");
                }
                Destroy(enemigoActual);
                Instantiate(Coin);
            }

        Muerte();
        VidaActual();
    }

    public void CrearEnemigo(){
        int aux = Random.Range(1,4);
        if(NivelActual != 11){
           if(aux == 1){
                Instantiate(enemigos[0]); 
                enemigoActual = GameObject.Find("slime(Clone)");
            }
            if(aux == 2){
                Instantiate(enemigos[1]);
                enemigoActual = GameObject.Find("Tigre(Clone)");
            }

            if(aux == 3){
                Instantiate(enemigos[2]);
                enemigoActual = GameObject.Find("Ave(Clone)");
            } 
        }else{
            if(enemigospn == 9){
                Instantiate(enemigos[5]);
                enemigoActual = GameObject.Find("Boss(Clone)");
            }else{
                 if(aux == 1){
                Instantiate(enemigos[3]); 
                enemigoActual = GameObject.Find("Clown(Clone)");
            }
            if(aux == 2){
                Instantiate(enemigos[3]); 
                enemigoActual = GameObject.Find("Clown(Clone)");
            }
            if(aux == 3){
                Instantiate(enemigos[4]); 
                enemigoActual = GameObject.Find("Dienton(Clone)");
            }
            }
           

        }
        
        ResetSlider();
    }

    public int GetNivelActual(){
        return NivelActual;
    }

    public void Muerte(){
    
        if(Input.GetMouseButtonDown(0)){
            slider.value -=  player.GetDamage();
        }
    }


    public void VidaActual(){
        int aux = (int)(slider.value); 
        vida.text = " " + aux;
        Ene.text = enemigospn + "/10";
        Nivel.text = "-" + NivelActual;
    }

    public void ResetSlider(){
        if(enemigospn == 10){
            slider.maxValue = (NivelActual * 250) + 50;  
            slider.value = slider.maxValue;
        }else{
            slider.maxValue = (NivelActual * 50) + 50;  
            slider.value = slider.maxValue;
        }
    }
}
