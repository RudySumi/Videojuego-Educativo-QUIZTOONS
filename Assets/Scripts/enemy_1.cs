using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_1 : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision) {
		
        if ( collision.gameObject.tag == "player" ){
          Debug.Log("Muerto");
			    SceneManager.LoadScene("Scene02");
			  }
    }
}
