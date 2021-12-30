using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Historia : MonoBehaviour
{
    public int num = 0;
    public GameObject[] textos;

    public void NextHistoria(){
        textos[num].SetActive(false);
        if(num < textos.Length-1){
            num++;
            textos[num].SetActive(true);
        }else{
            SceneManager.LoadScene("SampleScene");
        }
    }
}
