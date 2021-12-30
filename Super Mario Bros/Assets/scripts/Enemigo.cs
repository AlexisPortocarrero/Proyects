using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float speed = -400f;
    private Rigidbody2D rb2d;
    private bool puedenmoverse;
    public bool canjump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if(!canjump) speed = 0;
        if(canjump){
           puedenmoverse = false; 
           moverse(); 
        } 

        if(transform.position.x > GameObject.Find("Main Camera").transform.position.x +13){
            speed = 0;
        }else{
            moverse();
        }
        
        rb2d.AddForce(Vector2.right * speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Tubo" || other.gameObject.tag == "Enemigos"){
            speed = -speed;
        }

        if(other.gameObject.CompareTag("Mario")){
            if(GameObject.Find("mario (Clone)") != null && GameObject.Find("mario (Clone)").transform.position.y > transform.position.y+1){
                GameObject.Find("HudControler").GetComponent<HudController>().AddScore(100);
                Destroy(gameObject);
            }

            if(GameObject.Find("mario(Clone)") != null && GameObject.Find("mario(Clone)").transform.position.y > transform.position.y+1){
                GameObject.Find("HudControler").GetComponent<HudController>().AddScore(100);
                Destroy(gameObject);
            }
            
        }
        if(GameObject.Find("mario (Clone)") != null){
            if(other.gameObject.CompareTag("Mario") && GameObject.Find("mario (Clone)").transform.position.y < transform.position.y+1){
                if(GameObject.Find("mario (Clone)").GetComponent<Mario>().getbig()){
                    GameObject.Find("mario (Clone)").GetComponent<MarioChanges>().hacersepequeño();
                }
            }
        }
        
        if(GameObject.Find("mario(Clone)") != null){
            if(other.gameObject.CompareTag("Mario") && GameObject.Find("mario(Clone)").transform.position.y < transform.position.y+1){
                GameObject.Find("mario(Clone)").GetComponent<Mario>().Death();
            }
        }
        
        
    }

    public void moverse(){
        if(!puedenmoverse){
            speed=-250;
            puedenmoverse = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Piso") || other.gameObject.CompareTag("Tubo") ){
            canjump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Piso") || other.gameObject.CompareTag("Tubo") ){
            canjump = false;
        }
    }
}
