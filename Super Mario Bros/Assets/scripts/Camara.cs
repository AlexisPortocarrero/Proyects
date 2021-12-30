using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject mario;

    void Update()
    {
        if(mario == null){
            mario = GameObject.Find("mario (Clone)");
        }

        if(mario == null){
            mario = GameObject.Find("mario(Clone)");
        }

        if(mario.transform.position.x > transform.position.x - 5){
            transform.position = new Vector3(mario.transform.position.x+5,transform.position.y,transform.position.z);
        }
    }

    public void SetMario(GameObject a){
        mario = a;
    }
}
