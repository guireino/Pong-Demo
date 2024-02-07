using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour{

    private Rigidbody2D rb;
    private GameObject ball;
    public Vector2 limits = new Vector2(-4.5f, 4.5f);
    public float speed = 3f;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); // Encontra o objeto da bola na cena
    }

    // Update is called once per frame
    void Update(){

        if(ball != null){
            
            // Limita a posição Y para cima e para baixo
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y);
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);

            // Move gradualmente para a posição Y da bola
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }
}
