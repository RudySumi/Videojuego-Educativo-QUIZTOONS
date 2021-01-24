using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    //public Animator animator;
    public float jumpForce = 20f;

    public void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.CompareTag("player") ){
                collision.gameObject.GetComponent<Rigidbody2D>().velocity= (Vector2.up*jumpForce);
                //animator.Play("jumptrampoline");
            }
        }
}
