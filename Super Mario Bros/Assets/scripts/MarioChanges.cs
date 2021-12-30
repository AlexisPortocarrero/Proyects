using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioChanges : MonoBehaviour
{
    public GameObject mariogrande;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Hongo" && !GetComponent<Mario>().getbig()){

            Instantiate(mariogrande, transform.position,transform.rotation);
            GameObject.Find("Main Camera").GetComponent<Camara>().SetMario(GameObject.Find("mario (Clone)"));
            GameObject.Find("mario (Clone)").GetComponent<Mario>().AmIbig(true);
            Destroy(gameObject);
        }
    }

    public void hacersepequeño(){
        Instantiate(mariogrande, transform.position,transform.rotation);
        GameObject.Find("Main Camera").GetComponent<Camara>().SetMario(GameObject.Find("mario (Clone)"));
        GameObject.Find("mario (Clone)").GetComponent<Mario>().AmIbig(false);

        Destroy(gameObject);
    }
}
