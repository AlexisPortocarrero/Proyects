using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int coins = 0;
    private int daño = 10;
    private int dps = 0;
    public Slider slider;
    Animator anim;
    public Text gold;
    public Text dpis;
    public Text dmigs;


    // Start is called before the first frame update
    void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();
        aliados();
        coins = PlayerPrefs.GetInt("Coins", 0);
        daño = PlayerPrefs.GetInt("Daño", 10);
        dps = PlayerPrefs.GetInt("DPS", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Atacar();
        monedas();
    }

    public void Atacar(){
        if(Input.GetMouseButtonDown(0)){
            anim.SetTrigger("Atacando");
        }
    }

    public int GetDamage(){
        return daño;
    }

    public void setGold(int a){
        coins += a;
        PlayerPrefs.SetInt("Coins", coins);
    }
    public void SetDamage(int a ){
        daño += a;
        PlayerPrefs.SetInt("Daño", daño);
    }

    public void monedas(){
        gold.text = " " + coins;
        dpis.text = "DPS: " + dps;
        dmigs.text = "Daño Actual: " + daño;
    }

    public void aliados(){
        slider.value -=  dps;
        Invoke("aliados", 5f);
    }

    public void SetDPS(int a){
        dps += a;
        PlayerPrefs.SetInt("DPS", dps);
    }

    public int GetGold(){
        return coins;
    }
}
