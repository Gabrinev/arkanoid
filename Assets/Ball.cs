using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100.0f;
    
    void Start()
    {
        GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
    }

    float hitFactor (Vector2 ballPos, Vector2 racketPos,
        float racketWith){
            return (ballPos.x - racketPos.x) / racketWith;
        }
    
    void OnCollisionEnter2D(Collision2D col){
        
        if (col.gameObject.name == "racket"){

            float x=hitFactor(transform.position,
            col.transform.position,
            col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * (speed * 1.2f);
        }
    }
}
