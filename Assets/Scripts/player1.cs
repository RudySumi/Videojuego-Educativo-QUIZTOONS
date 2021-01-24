using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class player1 : MonoBehaviour
{
    public float speed = 5.0f;
    public float runSpeed = 8.0f;
    public float forceJump = 8.0f;

    public LayerMask capaSuelo;
    public Transform checkSuelo;


    bool onFloor;
    bool run;

    Rigidbody2D rb;
    Animator anim;
    Vector3 escalaPric;

    public AudioSource clip;
    public AudioSource die;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        escalaPric = transform.localScale;      

    }
    private void Update()
    {
        float h;
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            run = true;
        }
        else
        {
            run = false;
        }

        if (run){
            h = Input.GetAxis("Horizontal") * runSpeed;
        }
        else
        {
            h = Input.GetAxis("Horizontal") * speed;
        }
        rb.velocity = new Vector2(h, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && onFloor){
            rb.AddForce(Vector2.up * forceJump);
            anim.SetTrigger("Jump");
            clip.Play();
            
        }
        if(rb.velocity.x > 0){
            transform.localScale = escalaPric;

        }
        else if(rb.velocity.x<0){
            transform.localScale = new Vector3(-escalaPric.x, escalaPric.y, escalaPric.z);
        }

        if(h != 0){
           anim.SetBool("Walk",true);
        }else
        {
            anim.SetBool("Walk", false);
        }
        anim.SetBool("Run", run);
        anim.SetBool("Onfloor",onFloor);
			 		
    }

    private void FixedUpdate(){
        onFloor = Physics2D.OverlapCircle(checkSuelo.position, 0.1f, capaSuelo);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
		
        if ( collision.gameObject.tag == "enemy" ){
			Debug.Log("Muerto");
			//SceneManager.LoadScene("Scene01");
            GameControlScrit.health -=1;
            die.Play();


		}
    }


  
 

}
