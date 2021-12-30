using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mario : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool jumping;
    public bool canjump;
    public float jumpForce = 6.5f;
    Rigidbody2D rb2d;
    Animator anim;
    public bool mariogrande = false;
    public bool amideath = false;
    public bool candie = false;

    private AudioSource saltosonido;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        saltosonido = GetComponent<AudioSource>();
        if(GetComponent<CapsuleCollider2D>().size.y >2 ) mariogrande =true;
        Invoke("Inicio",2f);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocidad", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("PuedeSaltar", canjump);
        anim.SetBool("Muerto", amideath);

        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            if (!jumping)
            {
                saltosonido.Play();
                jumping = true;
                canjump = false;
            }
        }

        if (Input.GetMouseButton(0) && amideath)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        if(transform.position.y < -5){
            Death();
        }

    }

    private void FixedUpdate()
    {
    
        float h = Input.GetAxisRaw("Horizontal");
        if(!canjump) speed = 5;
        if(canjump) speed = 30;
        rb2d.AddForce(Vector2.right * speed * h);
        if (h > 0.1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(h<-0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (jumping)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = false;
        }

        if(transform.position.x < GameObject.Find("Main Camera").transform.position.x -12){
            transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x-12, transform.position.y, 0);
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

    public void AmIbig(bool a){
        mariogrande = a;
    }

    public bool getbig(){
        return mariogrande;
    }

    public void Death(){
        if(candie){
            amideath = true;
            speed = 0;
            Time.timeScale = 0;
        }
        
    }

    public void Inicio(){
        candie = true; 
    }
}
