using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour{

    public GameManager gameManager;
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public float speedUp = 1.1f;

    public void ResetBall(){

        //se posição da ball fica na 0 ela volta inicio.
        transform.position = Vector3.zero;

        if (rb == null){
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = startingVelocity; // dando velocidade inicial para bola
        }
    }

    public void OnCollisionEnter2D(Collision2D col) {
        
        //quando ball bater wall
        if(col.gameObject.CompareTag("Wall")){
            
            //mudando trajetória da bola
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;

        }

        //quando ball bater no player ou enemy
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy")){
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp; //add speed
        }

        if(col.gameObject.CompareTag("WallEnemy")){
            gameManager.ScorePlayer();
            ResetBall();
        }else if (col.gameObject.CompareTag("WallPlayer")){
            gameManager.ScoreEnemy();
            ResetBall();
        }

    }

}