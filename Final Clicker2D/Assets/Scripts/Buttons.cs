using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject Tienda;
    public bool TiendaAbierta;

    public GameObject Settings;
    public bool SettingsAbierto;

    public GameObject Perfil;
    public bool PerfilAbierto;

    public Player player;
    public Button a100g;
    public Button a50g;
    public GameObject ario;
    public GameObject nigger;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void AbrirTienda(){
        if(!TiendaAbierta){
            Tienda.SetActive(true);
        }
    }

    public void CerrarTienda(){
        Tienda.SetActive(false);
    }

    public void AbrirSettings(){
        if(!SettingsAbierto){
            Settings.SetActive(true);
        }  
    }

    public void CerrarSettings(){
        Settings.SetActive(false);
    }

    public void AbrirPerfil(){
        if(!PerfilAbierto){
            Perfil.SetActive(true);
        }  
    }

    public void CerrarPerfil(){
        Perfil.SetActive(false);
    }

    public void addDaño(){
        if(player.GetGold()>= 5){
            player.SetDamage(5);
            player.setGold(-5);
        }
        
    }

    public void addDps(){
        if(player.GetGold()>=50){
          player.SetDPS(50);
            Destroy(a50g);  
            player.setGold(-50);
            ario.SetActive(true);
        }
        
    }

    public void addDps2(){
        if(player.GetGold()>= 100){
           player.SetDPS(100);
            Destroy(a100g); 
            player.setGold(-100);
            nigger.SetActive(true);
        }
        
    }
}
