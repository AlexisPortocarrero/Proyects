using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Atacar();
    }

    public void Atacar(){
        if(Input.GetMouseButtonDown(0)){
            anim.SetTrigger("Atacando");
        }
    }

}
