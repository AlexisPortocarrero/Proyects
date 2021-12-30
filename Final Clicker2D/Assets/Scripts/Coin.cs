using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
     private void Start() {
        Rigidbody2D a = gameObject.GetComponent<Rigidbody2D>();
        a.velocity = new Vector2(-1f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Invoke("Distroy", 5f);  
    }

    private void OnMouseDown() {
        Distroy();
    }

    public void Distroy(){
        Destroy(gameObject);
        GameObject.Find("Player").GetComponent<Player>().setGold(1);
    }
}
