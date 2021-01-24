using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Transform transform;
    public SpriteRenderer spriteRender; 
    public Rigidbody2D rigidBody;
	public Animator animator; 



    public float speed = 3f;
    public float forceJump = 6f;
	public bool	canJump = false;

    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.RightArrow) ) {
		  	transform.position += new Vector3(1f, 0, 0) * speed * Time.deltaTime;
			spriteRender.flipX = false;
			//animator.SetBool("Run",true);
			 
		} else if ( Input.GetKey(KeyCode.LeftArrow) ) {
		  	transform.position -= new Vector3(1f, 0, 0) *  speed * Time.deltaTime;
			spriteRender.flipX = true;
			//animator.SetBool("Run",true);
			
		}
		else
		{
			//animator.SetBool("Run",false);	
		}
        if ( Input.GetKeyDown(KeyCode.Space) && canJump ){
		  	rigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
			//animator.SetBool("Jump",true);
			//animator.SetBool("Run",false);
		  			  
		}

    }

    public void OnCollisionEnter2D(Collision2D collision) {
		if ( collision.gameObject.tag == "floor" ){
			canJump = true;
			//animator.SetBool("Jump",false);
		}
       
    }
    public void OnCollisionExit2D(Collision2D collision) {
    if ( collision.gameObject.tag == "floor" ){
        canJump = false;
		//animator.SetBool("Jump",true); 
        }	
    }
}
