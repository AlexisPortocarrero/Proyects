using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public enum Sale{
       coin,
       hongo,
       enemigo
    }

    public Sale tipoObjeto;
    public Rigidbody2D rb2d;
    public int speed = 800;
    public bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if(tipoObjeto == Sale.coin){
            rb2d.velocity = new Vector2(0f, 3f);
            GameObject.Find("HudControler").GetComponent<HudController>().AddScore(200);
            GameObject.Find("HudControler").GetComponent<HudController>().AddCoin();
            Invoke("Distroy", 0.4f);
        }else{
            move = true;
            rb2d.velocity = new Vector2(1f, 7f);
        }

        Invoke("canmove", 0.5f);
    }

    private void FixedUpdate()
    {
        if(move){
            rb2d.AddForce(Vector2.right * speed*Time.deltaTime);
        }
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Mario")){
           GameObject.Find("HudControler").GetComponent<HudController>().AddScore(1000);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Tubo" || other.gameObject.tag == "Enemigo"){
            speed = -speed;
        }
    }

    public void Distroy(){
        Destroy(gameObject);
    }

    public void canmove(){
        move = true;
    }
}
