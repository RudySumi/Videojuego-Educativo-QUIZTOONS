using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class player_joystick : MonoBehaviour
{
    public float speed = 5.0f;
    public float runSpeed = 8.0f;
    public float forceJump = 8.0f;
///-----------------------------------//////
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public float runSpeedHorizontal=4;

    public Joystick joystick;

///-----------------------------------//////

    public LayerMask capaSuelo;
    public Transform checkSuelo;

    bool onFloor;
    bool run;

    Rigidbody2D rb;
    Animator anim;
    Vector3 escalaPric;

    public AudioSource clip;
    public AudioSource die;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        escalaPric = transform.localScale;    		
    }

    // Update is called once per frame
    private void Update()
    {
        float h;
        
        run = true;
        h = Input.GetAxis("Horizontal") * runSpeed;
        
    
        run = true;
        h = Input.GetAxis("Horizontal") * runSpeed;
        
		
        rb.velocity = new Vector2(h, rb.velocity.y);
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
        //***************************************//
        //horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        //transform.position+=new Vector3(horizontalMove,0,0)*Time.deltaTime;
    }

    public void Jump(){
        if(onFloor==true)
        {
            rb.AddForce(Vector2.up * forceJump);
            anim.SetTrigger("Jump");
            clip.Play();

        }
        
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

