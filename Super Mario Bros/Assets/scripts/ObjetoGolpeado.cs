using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoGolpeado : MonoBehaviour
{
    public enum Objeto{
        Signo,
        bloque,
        usado
    }

    public Objeto tipoObjeto;
    public GameObject usado;
    public GameObject objetotirado;
    public GameObject particula;
    private AudioSource monedasonido;


    private void OnCollisionEnter2D(Collision2D other)
    {
    
         if(other.gameObject.CompareTag("Mario")){
            if(GameObject.Find("mario (Clone)") != null && GameObject.Find("mario (Clone)").transform.position.y < transform.position.y+0.3){
                Action();
            }

            if(GameObject.Find("mario(Clone)") != null && GameObject.Find("mario(Clone)").transform.position.y < transform.position.y+0.3){
                Action();
            }
            
        }
    }

    private void Action(){
        if(tipoObjeto == Objeto.Signo){
            monedasonido = GetComponent<AudioSource>();
            monedasonido.Play();
            Instantiate(objetotirado, new Vector4(transform.position.x, transform.position.y +1, transform.position.z, 0), transform.rotation);
            Instantiate(usado, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(GameObject.Find("mario (Clone)")!=null){
            if(tipoObjeto == Objeto.bloque &&  GameObject.Find("mario (Clone)").GetComponent<Mario>().getbig() ){
                Instantiate(particula, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        
        
    }
}
